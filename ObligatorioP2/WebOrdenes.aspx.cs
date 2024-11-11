using ObligatorioP2.Models;
using System;
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

                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataValueField = "Nombre"; // Similar al anterior
                DDTecnicos.DataBind();

                CargarOrdenesEnTabla();
            }
        }

        private void CargarOrdenesEnTabla()
        {
            // Asegúrate de que las columnas de la GridView están configuradas correctamente
            TablaOrdenes.DataSource = BaseDeDatos.ListaOrdenes;
            TablaOrdenes.DataBind();
        }

        protected void CmdCrearOrden(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DDClientes.SelectedValue) || string.IsNullOrEmpty(DDTecnicos.SelectedValue))
            {
                lblError.Text = "Debes seleccionar un Cliente y/o Técnico";
                lblError.Visible = true;
            }
            else
            {
                // Obtener los valores de los campos
                var cliente = DDClientes.SelectedValue;
                var tecnico = DDTecnicos.SelectedValue;
                var tipoServicio = ddlTipoServicio.SelectedValue;
                var fecha = DateTime.Now;
                var estado = DDEstado.SelectedValue;

                // Crear la orden
                Orden nuevaOrden = new Orden(1, cliente, tecnico, tipoServicio, fecha, estado);
                BaseDeDatos.ListaOrdenes.Add(nuevaOrden);

                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden creada correctamente";

                CargarOrdenesEnTabla();
                LimpiarCampos();
                lblError.Visible = false;
            }
        }

        private void LimpiarCampos()
        {
            DDClientes.SelectedIndex = -1;
            DDTecnicos.SelectedIndex = -1;
            ddlTipoServicio.SelectedIndex = -1;
            DDEstado.SelectedIndex = -1;
        }

        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
            {
                BaseDeDatos.ListaOrdenes.RemoveAt(index);
                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden eliminada correctamente";
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Text = "Índice fuera de rango.";
                return;
            }

            // Reemplazar la línea de actualización de GridView
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

                    DDClientes.SelectedValue = orden.NombreCliente;
                    DDTecnicos.SelectedValue = orden.NombreTecnico;
                    ddlTipoServicio.SelectedValue = orden.TipoDeServicio;
                    DDEstado.SelectedValue = orden.EstadoEnString;

                    // Guardar el índice de la orden en sesión
                    Session["OrdenIndex"] = index;
                }
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (Session["OrdenIndex"] != null)
            {
                int index = (int)Session["OrdenIndex"];

                // Actualizar la orden
                Orden orden = BaseDeDatos.ListaOrdenes[index];

                orden.NombreCliente = DDClientes.SelectedValue;
                orden.NombreTecnico = DDTecnicos.SelectedValue;
                orden.TipoDeServicio = ddlTipoServicio.SelectedValue;
                orden.EstadoEnString = DDEstado.SelectedValue;

                LimpiarCampos();

                lblError.Visible = true;
                lblError.Text = "Orden actualizada correctamente";
                lblCreadoCorrectamente.Visible = false;

                // Actualizar la tabla
                CargarOrdenesEnTabla();

                Session.Remove("OrdenIndex");
                BtnActualizar.Visible = false;
            }
        }
    }
}
