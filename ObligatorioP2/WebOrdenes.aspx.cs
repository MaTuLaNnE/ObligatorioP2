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

                if (BaseDeDatos.ListaTecnico.Count == 0 || BaseDeDatos.ListaClientes.Count == 0)
                {
                    BaseDeDatos.PrecargarBD();

                }


                if (BaseDeDatos.Token.esAdmin)
                {
                    lblNombreTecnico.Visible = true;
                    DDTecnicos.Visible = true;
                }

                CargarListaOrdenesXtecnico();

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

            TablaOrdenes.DataSource = BaseDeDatos.OrdenesxTecnico;
            TablaOrdenes.DataBind();

        }

        private void CargarListaOrdenesXtecnico()
        {
            BaseDeDatos.OrdenesxTecnico.Clear();

            foreach (var orden in BaseDeDatos.ListaOrdenes)
            {
                // Si es admin, puede ver todas las órdenes
                if (BaseDeDatos.Token.esAdmin || orden.NombreTecnico == BaseDeDatos.Token.Nombre)
                {

                    BaseDeDatos.OrdenesxTecnico.Add(orden);

                }
            }
        }


        protected void CmdCrearOrden(object sender, EventArgs e)
        {

            EsconderLabels();

            if (string.IsNullOrEmpty(DDClientes.Text) || string.IsNullOrEmpty(DDTecnicos.Text) || string.IsNullOrEmpty(ddlTipoServicio.Text))
            {
                if (string.IsNullOrEmpty(ddlTipoServicio.Text))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    lblError.Text = "Debe seleccionar un servicio";
                    lblConfirmacion.Visible = false;
                }
                else
                {
                    lblError.Text = "Debes agregar un Cliente y/o Tecnico";
                    lblError.Visible = true;
                    lblConfirmacion.Visible = false;
                }


            }
            else
            {
                string cliente = DDClientes.SelectedValue;
                string tecnico;

                if (BaseDeDatos.Token.esAdmin)
                {
                    tecnico = DDTecnicos.SelectedValue;
                }
                else
                {
                    Tecnico tecnicoActual = BaseDeDatos.Token;
                    tecnico = tecnicoActual.Nombre;
                }



                string servicio = ddlTipoServicio.Text;
                string desc = txtDesc.Text;
                DateTime fecha = DateTime.Now.Date;
                string estado = DDEstado.SelectedValue = "PENDIENTE";
                string comentario = txtComentario.Text;

                listaComents = GenerarLista(comentario);

                Orden miOrden = BaseDeDatos.crearOrden(cliente, tecnico, servicio, desc, fecha, estado, listaComents);

                BaseDeDatos.OrdenesxTecnico.Add(miOrden);

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
            EsconderLabels();

            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.OrdenesxTecnico.Count)
            {
                Orden ordenSeleccionada = BaseDeDatos.OrdenesxTecnico[index];

                Orden ordenEnLista = BaseDeDatos.ListaOrdenes.FirstOrDefault(orden => orden.NroOrden == ordenSeleccionada.NroOrden);

                BaseDeDatos.ListaOrdenes.Remove(ordenEnLista);
                BaseDeDatos.OrdenesxTecnico.RemoveAt(index);

                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden eliminada correctamente";


                LimpiarCampos();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Índice fuera de rango.";
            }

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
                        break;
                    }

                    GridViewRow fila = TablaOrdenes.Rows[i];

                    if (fila == null)
                    {
                        continue;
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
                lblComentario.Visible = false;
                txtComentario.Visible = false;


                lblError.Visible = true;
                lblError.Text = "Editando...";



                GridViewRow row = TablaOrdenes.Rows[index];

                Button btnMostrarEdit = (Button)row.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)row.FindControl("btnCancel");


                if (index >= 0 && index < BaseDeDatos.OrdenesxTecnico.Count)
                {
                    Orden orden = BaseDeDatos.OrdenesxTecnico[index];

                    for (int i = 0; i < BaseDeDatos.ListaOrdenes.Count; i++)
                    {

                        Orden ordenEncontrada = BaseDeDatos.ListaOrdenes[i];

                        if (orden.NroOrden == ordenEncontrada.NroOrden)
                        {
                            btnMostrarEdit.Visible = false;
                            btnMostrarCancel.Visible = true;

                            DDClientes.Text = orden.NombreCliente;
                            DDTecnicos.Text = orden.NombreTecnico;
                            ddlTipoServicio.Text = orden.TipoDeServicio;
                            DDEstado.SelectedValue = orden.Estado;
                            txtDesc.Text = orden.DescripcionProblema;

                            RequiredFieldValidator1.Enabled = false;
                            rfvDesc.Enabled = false;

                            int UBiLista = i;

                            // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
                            Session["OrdenIndex"] = UBiLista;
                            break;
                        }
                    }

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
                lblComentario.Visible = true;
                txtComentario.Visible = true;

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

                if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
                {
                    Session["OrdenIndex"] = index;
                    Response.Redirect("WebComentarios.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Índice inválido.";
                }



            }
 

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {

            if (Session["OrdenIndex"] != null && !string.IsNullOrEmpty(DDClientes.Text) && !string.IsNullOrEmpty(DDTecnicos.Text) && !string.IsNullOrEmpty(ddlTipoServicio.Text))
            {
                int index = (int)Session["OrdenIndex"];

                Orden orden = BaseDeDatos.ListaOrdenes[index];

                orden.NombreCliente = DDClientes.Text;
                orden.NombreTecnico = DDTecnicos.Text;
                orden.TipoDeServicio = ddlTipoServicio.Text;
                orden.Estado = DDEstado.Text;

                Orden ordenEnTecnico = BaseDeDatos.OrdenesxTecnico.FirstOrDefault(o => o.NroOrden == orden.NroOrden);
                if (ordenEnTecnico != null)
                {
                    ordenEnTecnico.NombreCliente = orden.NombreCliente;
                    ordenEnTecnico.NombreTecnico = orden.NombreTecnico;
                    ordenEnTecnico.TipoDeServicio = orden.TipoDeServicio;
                    ordenEnTecnico.Estado = orden.Estado;
                    ordenEnTecnico.DescripcionProblema = orden.DescripcionProblema;
                }

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
            else
            {
                if (string.IsNullOrEmpty(ddlTipoServicio.Text))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    lblError.Text = "Debe seleccionar un servicio";
                    lblConfirmacion.Visible = false;
                }
                else
                {
                    lblError.Text = "Debes agregar un Cliente y/o Tecnico";
                    lblError.Visible = true;
                    lblConfirmacion.Visible = false;
                }
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


    }

}
