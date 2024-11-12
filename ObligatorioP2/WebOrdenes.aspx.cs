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
                }

                // Enlazar los DropDownLists
                DDClientes.DataSource = BaseDeDatos.ListaClientes;
                DDClientes.DataTextField = "Nombre";
                DDClientes.DataValueField = "Nombre"; // Asumí que "Nombre" es la clave, puedes cambiarlo si es diferente
                DDClientes.DataBind();

                DDTecnicos.Items.Insert(0, new ListItem("-- Select --", ""));
                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataValueField = "Nombre"; // Similar al anterior
                DDTecnicos.DataBind();



                CargarOrdenesEnTabla();
            }
        }

        public static List<int> HistorialOrdenes = new List<int>();
        public List<string> listaComents = new List<string>();
        private void CargarOrdenesEnTabla()
        {
            // Asegúrate de que las columnas de la GridView están configuradas correctamente
            TablaOrdenes.DataSource = BaseDeDatos.ListaOrdenes;
            TablaOrdenes.DataBind();
        }

        protected void CmdCrearOrden(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DDClientes.Text) || string.IsNullOrEmpty(DDTecnicos.Text))
            {

                lblError.Text = "Debes agregar un Cliente y/o Tecnico";
                lblError.Visible = true;

            }
            else
            {
                var a = CrearNroOrden();
                var b = DDClientes.SelectedValue;
                var c = DDTecnicos.SelectedValue;
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
                lblError.Visible = false;
            }
        }

        public int CrearNroOrden()
        {

            int NroOrden = 0;

            for (int i = 0; i <= BaseDeDatos.ListaOrdenes.Count; i++)
            {
                HistorialOrdenes.Add(i);

                while (HistorialOrdenes.Contains(i))
                {
                    i++;
                }

                NroOrden = i;
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

        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
            {
                BaseDeDatos.ListaOrdenes.RemoveAt(index);
                lblError.Visible = true;
                lblError.Text = "Orden eliminada correctamente";
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Text = "OUT del rango.";
                return;
            }

            TablaOrdenes.EditIndex = -1;
            CargarOrdenesEnTabla();

        }

        protected void TablaOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                BtnActualizar.Visible = true;
                lblError.Visible = false;

                if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
                {
                    
                    Orden orden = BaseDeDatos.ListaOrdenes[index];

                    DDClientes.Text = orden.NombreCliente;
                    DDTecnicos.Text = orden.NombreTecnico;
                    ddlTipoServicio.Text = orden.TipoDeServicio;
                    DDEstado.SelectedValue = orden.Estado;

                    //rfvNombre.Enabled = false;
                    //rfvApellido.Enabled = false;
                    //rfcCI.Enabled = false;

                    // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
                    Session["OrdenIndex"] = index;
                }
            }
            if (e.CommandName == "MostrarComments")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                btnAgregarComments.Visible = true;
                ListComents.Visible = true;

                if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
                {

                    Orden orden = BaseDeDatos.ListaOrdenes[index];

                    RequiredFieldValidator1.Enabled = false;
                    rfvDesc.Enabled = false;

                    BLComentarios.DataSource = orden.ListaComentarios;
                    BLComentarios.DataBind();

                    Session["OrdenIndex"] = index;
                }
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


                //    lblError.Visible = true;
                //    lblError.Text = "Orden actualizada correctamente";

                lblError.Visible = true;
                lblError.Text = "Orden actualizada correctamente";


                //rfvNombre.Enabled = true;
                //rfvApellido.Enabled = true;
                //rfcCI.Enabled = true;

                CargarOrdenesEnTabla();

            }

        }


        public List<string> GenerarLista(params string[] comentarios)
        {
            List<string> lista = new List<string>();
            foreach (string comentario in comentarios)
            {
                lista.Add(comentario);
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

                lblError.Visible = true;
                lblError.Text = "Comentario agregado correctamente";

                RequiredFieldValidator1.Enabled = false;
                rfvDesc.Enabled = false;

                BLComentarios.DataSource = orden.ListaComentarios;
                BLComentarios.DataBind();
            }
        }
    }

}
