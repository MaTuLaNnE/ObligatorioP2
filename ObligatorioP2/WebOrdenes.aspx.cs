using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (BaseDeDatos.ListaTecnico.Count == 0 && BaseDeDatos.ListaTecnico.Count == 0)
                {
                    BaseDeDatos.PrecargarBD();


                    //ListaComentarios.DataSource = Ordenes
                    //ListaComentarios.DataBind();
                }

                DDClientes.DataSource = BaseDeDatos.ListaClientes;
                DDClientes.DataTextField = "Nombre";
                DDClientes.DataBind();

                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataBind();

            }
        }

        private void CargarOrdenesEnTabla()
        {
            //    TablaOrdenes.DataSource = BaseDeDatos.ListaOrdenes;
            //    TablaOrdenes.DataBind();
        }

        private void CmdCrear(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(DDClientes.Text) || string.IsNullOrEmpty(DDTecnicos.Text))
            //{

            //    lblError.Text = "Debes agregar un Cliente y/o Tecnico";
            //    lblError.Visible = true;

            //}
            //else
            //{
            //    var a = DDClientes.Text;
            //    var b = DDTecnicos.Text;
            //    var c = ddlTipoServicio.Text;
            //    var d = DDEstado.Text;

            //    Orden miOrden = new Orden(a, b, c, d);

            //    miOrden.NombreCliente = a;
            //    miOrden.NombreTecnico = b;
            //    miOrden.TipoDeServicio = c;
            //    miOrden.Estado = d;
            //    lblCreadoCorrectamente.Visible = true;
            //    lblCreadoCorrectamente.Text = "Orden creada correctamente";

            //    BaseDeDatos.ListaOrdenes.Add(miOrden);



            //    CargarOrdenesEnTabla();

            //    LimpiarCampos();
            //    lblError.Visible = false;
            //}
        }

        private void LimpiarCampos()
        {
            DDClientes.Text = "";
            DDTecnicos.Text = "";
            ddlTipoServicio.Text = "";
            DDEstado.Text = "";

        }


        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            //int index = e.RowIndex;

            //if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
            //{
            //    BaseDeDatos.ListaOrdenes.RemoveAt(index);
            //    lblError.Visible = true;
            //    lblError.Text = "Orden eliminada correctamente";
            //    BtnActualizar.Visible = false;
            //}
            //else
            //{
            //    lblError.Text = "OUT del rango.";
            //    return;
            //}

            //TablaOrdenes.EditIndex = -1;
            //CargarOrdenesEnTabla();

        }

        protected void TablaOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Editar")
            //{

            //    int index = Convert.ToInt32(e.CommandArgument);

            //    BtnActualizar.Visible = true;
            //    lblError.Visible = false;

            //    if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
            //    {

            //        Orden orden = BaseDeDatos.ListaOrdenes[index];

            //        DDClientes.Text = orden.NombreCliente;
            //        DDTecnicos.Text = orden.NombreTecnico;
            //        ddlTipoServicio.Text = orden.TipoDeServicio;
            //        DDEstado.Text = orden.Estado;

            //        //rfvNombre.Enabled = false;
            //        //rfvApellido.Enabled = false;
            //        //rfcCI.Enabled = false;

            //        // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
            //        Session["OrdenIndex"] = index;
            //    }
            //}
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que existe un índice almacenado en sesión
            //if (Session["OrdenIndex"] != null)
            //{
            //    int index = (int)Session["OrdenIndex"];


            //    Orden orden = BaseDeDatos.ListaOrdenes[index];

            //    orden.NombreCliente = txtNombreCliente.Text;
            //    orden.NombreTecnico = txtTecnico.Text;
            //    orden.TipoDeServicio = txtTipoDeServicio.Text;
            //    orden.Estado = txtEstado.Text;


            //    LimpiarCampos();

            //    lblError.Visible = true;
            //    lblError.Text = "Orden actualizada correctamente";


            //    //rfvNombre.Enabled = true;
            //    //rfvApellido.Enabled = true;
            //    //rfcCI.Enabled = true;

            //    CargarOrdenesEnTabla();

            //    Session.Remove("OrdenIndex");
            //    BtnActualizar.Visible = false;

        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {

        }
    }
}
