using Microsoft.Ajax.Utilities;
using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ObligatorioP2
{
    public partial class WebOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Corregir al cargar datos
                if (BaseDeDatos.ListaTecnico.Count == 0 || BaseDeDatos.ListaClientes.Count == 0)
                {

                    BaseDeDatos.PrecargarBD();
                }

                // Enlazar los DDL
                DDClientes.DataSource = BaseDeDatos.ListaClientes;
                DDClientes.DataTextField = "Nombre";
                DDClientes.DataValueField = "Nombre";
                DDClientes.DataBind();


                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataValueField = "Nombre";
                DDTecnicos.DataBind();


                CargarOrdenesEnTabla();
            }



        }


        public List<string> listaComents = new List<string>();

        private void CargarOrdenesEnTabla()
        {
            BaseDeDatos.OrdenesxTecnico.Clear();

            Tecnico tecnicoActual = BaseDeDatos.Token;

            for (int i = 0; i < BaseDeDatos.ListaOrdenes.Count; i++)
            {
                Orden orden = BaseDeDatos.ListaOrdenes[i];


                if (tecnicoActual.Nombre == orden.NombreTecnico || tecnicoActual.esAdmin)
                {
                    BaseDeDatos.OrdenesxTecnico.Add(orden);
                }
            }


            TablaOrdenes.DataSource = BaseDeDatos.OrdenesxTecnico;
            TablaOrdenes.DataBind();

        }


        protected void CmdCrearOrden(object sender, EventArgs e)
        {

            EsconderLabels();

            if (string.IsNullOrEmpty(DDClientes.Text) || string.IsNullOrEmpty(DDTecnicos.Text))
            {

                lblError.Text = "Debes agregar un Cliente y/o Tecnico";
                lblError.Visible = true;
                lblConfirmacion.Visible = false;

            }
            else
            {
                string cliente = DDClientes.SelectedValue;

                Tecnico tecnicoActual = BaseDeDatos.Token;
                string tecnico = tecnicoActual.Nombre;

                string servicio = ddlTipoServicio.Text;
                string desc = txtDesc.Text;
                DateTime fecha = DateTime.Now.Date;
                string estado = DDEstado.SelectedValue = "PENDIENTE";
                string comentario = txtComentario.Text;

                listaComents = GenerarLista(comentario);

                Orden miOrden = BaseDeDatos.crearOrden(cliente, tecnico, servicio, desc, fecha, estado, listaComents);


                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden creada correctamente";




                CargarOrdenesEnTabla();

                LimpiarCampos();

            }
        }







        private void LimpiarCampos()
        {
            ddlTipoServicio.ClearSelection();
            DDEstado.ClearSelection();
            txtComentario.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }

        private void EsconderLabels()
        {
            lblCreadoCorrectamente.Visible = false;
            lblConfirmacion.Visible = false;
            lblError.Visible = false;
        }

        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            EsconderLabels();

            if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
            {
                BaseDeDatos.ListaOrdenes.RemoveAt(index);
                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden eliminada correctamente";
                BtnActualizar.Visible = false;
                lblEstado.Visible = false;
                DDEstado.Visible = false;
                LimpiarCampos();
            }
            else
            {
                lblError.Text = "OUT del rango.";
                return;
            }

            btnCrearOrden.Visible = true;


            CargarOrdenesEnTabla();

        }

        protected void TablaOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EsconderLabels();

            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {

                for (int i = 0; i < BaseDeDatos.ListaOrdenes.Count; i++)
                {
                    if (i >= TablaOrdenes.Rows.Count)
                    {
                        break; // Sale si el indice excede las filas
                    }

                    GridViewRow fila = TablaOrdenes.Rows[i];

                    if (fila == null)
                    {
                        continue; // Pasa si la fila es null
                    }

                    Button btnMostrarEditAbiertos = (Button)fila.FindControl("btnEditar");
                    Button btnMostrarCancelAbiertos = (Button)fila.FindControl("btnCancel");

                    btnMostrarEditAbiertos.Visible = true;
                    btnMostrarCancelAbiertos.Visible = false;
                }


                lblEstado.Visible = true;
                DDEstado.Visible = true;
                BtnActualizar.Visible = true;
                btnCrearOrden.Visible = false;
                lblConfirmacion.Visible = false;
                btnAgregarComments.Visible = false;


                lblError.Visible = true;
                lblError.Text = "Editando...";



                GridViewRow row = TablaOrdenes.Rows[index];

                Button btnMostrarEdit = (Button)row.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)row.FindControl("btnCancel");

                if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
                {

                    Orden orden = BaseDeDatos.ListaOrdenes[index];

                    btnMostrarEdit.Visible = false;
                    btnMostrarCancel.Visible = true;

                    DDClientes.Text = orden.NombreCliente;
                    DDTecnicos.Text = orden.NombreTecnico;
                    ddlTipoServicio.Text = orden.TipoDeServicio;
                    DDEstado.SelectedValue = orden.Estado;
                    txtDesc.Text = orden.DescripcionProblema;

                    RequiredFieldValidator1.Enabled = false;
                    rfvDesc.Enabled = false;


                    // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
                    Session["OrdenIndex"] = index;
                }
            }
            if (e.CommandName == "CancelEdit")
            {
                index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = TablaOrdenes.Rows[index];

                Button btnMostrarEdit = (Button)row.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)row.FindControl("btnCancel");

                btnMostrarEdit.Visible = true;
                btnMostrarCancel.Visible = false;

                lblEstado.Visible = false;
                DDEstado.Visible = false;

                RequiredFieldValidator1.Enabled = true;
                rfvDesc.Enabled = true;

                BtnActualizar.Visible = false;
                btnCrearOrden.Visible = true;
                LimpiarCampos();

            }
            if (e.CommandName == "MostrarComments")
            {
                index = Convert.ToInt32(e.CommandArgument);

                for (int i = 0; i < BaseDeDatos.ListaOrdenes.Count; i++)
                {
                    if (i >= TablaOrdenes.Rows.Count)
                    {
                        break; // Sale si el indice excede el maximo
                    }

                    GridViewRow fila = TablaOrdenes.Rows[i];

                    if (fila == null)
                    {
                        continue; // Pasa si la fila es null
                    }

                    Button btnMostrarCommentsAbiertos = (Button)fila.FindControl("btnMostrarComments");
                    Button btnOcultarCommentsAbiertos = (Button)fila.FindControl("btnOcultarComments");

                    btnMostrarCommentsAbiertos.Visible = true;
                    btnOcultarCommentsAbiertos.Visible = false;
                }

                GridViewRow row = TablaOrdenes.Rows[index];
                Button btnMostrarComments = (Button)row.FindControl("btnMostrarComments");
                Button btnOcultarComments = (Button)row.FindControl("btnOcultarComments");

                btnAgregarComments.Visible = true;
                ListComents.Visible = true;
                btnCrearOrden.Visible = false;
                BtnActualizar.Visible = false;

                if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
                {
                    CargarOrdenesEnTabla();

                    Orden orden = BaseDeDatos.OrdenesxTecnico[index];

                    RequiredFieldValidator1.Enabled = false;
                    rfvDesc.Enabled = false;

                    BLComentarios.Visible = true;
                    BLComentarios.DataSource = orden.ListaComentarios;
                    BLComentarios.DataBind();

                    btnMostrarComments.Visible = false;
                    btnOcultarComments.Visible = true;
                    LimpiarCampos();

                    Session["OrdenIndex"] = index;
                }
            }
            if (e.CommandName == "OcultarComments")
            {
                index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = TablaOrdenes.Rows[index];

                Button btnMostrarComments = (Button)row.FindControl("btnMostrarComments");
                Button btnOcultarComments = (Button)row.FindControl("btnOcultarComments");


                btnOcultarComments.Visible = false;
                btnMostrarComments.Visible = true;


                RequiredFieldValidator1.Enabled = true;
                rfvDesc.Enabled = true;

                ListComents.Visible = false;
                BLComentarios.Visible = false;
                btnAgregarComments.Visible = false;
                btnCrearOrden.Visible = true;
            }

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // nos aseguramos de que existe un índice almacenado en sesión
            if (Session["OrdenIndex"] != null)
            {
                int index = (int)Session["OrdenIndex"];


                Orden orden = BaseDeDatos.ListaOrdenes[index];

                orden.NombreCliente = DDClientes.Text;
                orden.NombreTecnico = DDTecnicos.Text;
                orden.TipoDeServicio = ddlTipoServicio.Text;
                orden.Estado = DDEstado.Text;


                lblConfirmacion.Visible = true;
                lblConfirmacion.Text = "Orden actualizada correctamente";
                lblCreadoCorrectamente.Visible = false;
                btnCrearOrden.Visible = true;
                lblEstado.Visible = false;
                DDEstado.Visible = false;
                lblError.Visible = false;
                BtnActualizar.Visible = false;


                RequiredFieldValidator1.Enabled = true;
                rfvDesc.Enabled = true;

                CargarOrdenesEnTabla();

            }

        }


        public List<string> GenerarLista(params string[] comentarios)
        {

            List<string> lista = new List<string>();

            if (comentarios[0] == "")
            {
                lista.Add("No hay comentarios que mostrar");
            }
            else
            {
                foreach (string comentario in comentarios)
                {
                    lista.Add(comentario);
                }
            }

            return lista;

        }

        protected void btnAgregarComments_Click(object sender, EventArgs e)
        {

            if (Session["OrdenIndex"] != null)
            {
                int index = (int)Session["OrdenIndex"];

                Orden orden = BaseDeDatos.ListaOrdenes[index];

                string comentario = txtComentario.Text;

                orden.ListaComentarios.Add(comentario);

                lblConfirmacion.Visible = true;
                lblConfirmacion.Text = "Comentario agregado correctamente";

                RequiredFieldValidator1.Enabled = false;
                rfvDesc.Enabled = false;

                BLComentarios.DataSource = orden.ListaComentarios;
                BLComentarios.DataBind();
            }
        }


    }

}
