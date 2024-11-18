using Microsoft.Ajax.Utilities;
using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioP2
{
    public partial class WebOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Corregir la condición de cargar datos
                if (BaseDeDatos.ListaTecnico.Count == 0 || BaseDeDatos.ListaClientes.Count == 0)
                {
                    BaseDeDatos.PrecargarBD();

                    //PRUEBAAAAAAAAA
                    for (int i = 0; i < BaseDeDatos.ListaOrdenes.Count; i++) //Cuenta cuantas ordnes creadas hay
                    {
                        HistorialOrdenes.Add(HistorialOrdenes.Count + 1);
                    }
                }

                // Enlazar los DropDownLists
                DDClientes.DataSource = BaseDeDatos.ListaClientes;
                DDClientes.DataTextField = "Nombre";
                DDClientes.DataValueField = "Nombre"; // Asumí que "Nombre" es la clave, puedes cambiarlo si es diferente
                DDClientes.DataBind();


                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataValueField = "Nombre"; // Similar al anterior
                DDTecnicos.DataBind();



                CargarOrdenesEnTabla();
            }
        }

        public static List<int> HistorialOrdenes = new List<int>();
        public List<string> listaComents = new List<string>();


        public  List<Orden> OrdenesxTecnico = new List<Orden>();

        private void CargarOrdenesEnTabla()
        {


            Tecnico tecnicoActual = BaseDeDatos.Token[0];


            for (int i = 0; i < BaseDeDatos.ListaOrdenes.Count; i++)
            {
                Orden orden = BaseDeDatos.ListaOrdenes[i];


                if (tecnicoActual.Nombre == orden.NombreTecnico)
                {
                    OrdenesxTecnico.Add(orden);
                }
            }


            TablaOrdenes.DataSource = OrdenesxTecnico;
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
                var a = CrearNroOrden();
                var b = DDClientes.SelectedValue;

                Tecnico tecnicoActual = BaseDeDatos.Token[0];
                var c = tecnicoActual.Nombre;

                var d = ddlTipoServicio.Text;
                var ea = txtDesc.Text;
                var f = DateTime.Now.Date;
                var g = DDEstado.SelectedValue = "PENDIENTE";
                var comentario = txtComentario.Text;

                listaComents = GenerarLista(comentario);

                Orden miOrden = new Orden(a, b, c, d, ea, f, g, listaComents);

                miOrden.NroOrden = a;
                miOrden.NombreCliente = b;
                miOrden.NombreTecnico = c;
                miOrden.TipoDeServicio = d;
                miOrden.DescripcionProblema = ea;
                miOrden.FechaCreacion = f;
                miOrden.Estado = g;
                miOrden.ListaComentarios = listaComents;

                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden creada correctamente";

                BaseDeDatos.ListaOrdenes.Add(miOrden);



                CargarOrdenesEnTabla();

                LimpiarCampos();

            }
        }


        public int CrearNroOrden()
        {

            int NroOrden = 0;
            int NumMaxOrden = HistorialOrdenes.LastOrDefault();

            if (NumMaxOrden > HistorialOrdenes.Count)
            {
                NroOrden = NumMaxOrden;
                NumMaxOrden += 1;
                HistorialOrdenes.Add(NumMaxOrden);
            }
            else if (NumMaxOrden == HistorialOrdenes.Count)
            {
                NroOrden = NumMaxOrden + 1;
                NumMaxOrden += 1;
                HistorialOrdenes.Add(NroOrden);
            }
            else
            {
                NroOrden = HistorialOrdenes.Count;
                NumMaxOrden = HistorialOrdenes.Count + 1;
            }

            return NroOrden;
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


            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                for (int i = 0; i < OrdenesxTecnico.Count; i++)
                {
                    GridViewRow ala = TablaOrdenes.Rows[i];

                    Button btnMostrarEditAbiertos = (Button)ala.FindControl("btnEditar");
                    Button btnMostrarCancelAbiertos = (Button)ala.FindControl("btnCancel");

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
                int index = Convert.ToInt32(e.CommandArgument);

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
                int index = Convert.ToInt32(e.CommandArgument);

                for (int i = 0; i < OrdenesxTecnico.Count; i++)
                {
                    GridViewRow kk = TablaOrdenes.Rows[i];
                    Button btnOcultarCommentsAbiertos = (Button)kk.FindControl("btnOcultarComments");
                    Button btnMostrarCommentsAbiertos = (Button)kk.FindControl("btnMostrarComments");

                    btnOcultarCommentsAbiertos.Visible = false;
                    btnMostrarCommentsAbiertos.Visible = true;

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

                    Orden orden = BaseDeDatos.ListaOrdenes[index];

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
                int index = Convert.ToInt32(e.CommandArgument);

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
            // Asegúrate de que existe un índice almacenado en sesión
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
                btnCrearOrden.Visible = true;


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
