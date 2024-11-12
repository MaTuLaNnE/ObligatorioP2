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
                lblConfirmacion.Visible = false;

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
                lblConfirmacion.Visible = false;
                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden creada correctamente";

                BaseDeDatos.ListaOrdenes.Add(miOrden);



                CargarOrdenesEnTabla();

                LimpiarCampos();
                lblError.Visible = false;
            }
        }

        //public int CrearNroOrden() // ??????????????????????????????????????????????????????????????????????????  funca eso?
        //{
        //    int NroOrden = 0;

        //    for (int i = 0; i <= BaseDeDatos.ListaOrdenes.Count; i++)
        //    {
        //        if (!HistorialOrdenes.Contains(i))
        //        {
        //            HistorialOrdenes.Add(i);
        //        }
        //        if (BaseDeDatos.ListaOrdenes.Count < HistorialOrdenes.Count)
        //        {
        //            NroOrden = HistorialOrdenes.Count; // nuevo para probar || cuenta todas las ordenes y le suma una para q sea la ultima siempre
        //        }
        //    }


        //    return NroOrden;
        //}

        //public int CrearNroOrden()
        //{
        //    int NroOrden = 0;

        //    for (int i = 0; i <= BaseDeDatos.ListaOrdenes.Count; i++)
        //    {

        //        if (!HistorialOrdenes.Contains(i) && !BaseDeDatos.ListaOrdenes.Exists(Orden => Orden.NroOrden == i))
        //        {
        //            HistorialOrdenes.Add(NroOrden); //Se marca como usado
        //            NroOrden = i;
        //            break;
        //        }
        //    }
        //    if (NroOrden == 0 && BaseDeDatos.ListaOrdenes.Count > 0)
        //    {
        //        NroOrden = BaseDeDatos.ListaOrdenes.Max(orden => orden.NroOrden) + 1;
        //    }

        //    HistorialOrdenes.Add(NroOrden); //Se marca como usado

        //    return NroOrden;
        //}


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

        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
            {
                BaseDeDatos.ListaOrdenes.RemoveAt(index);
                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Orden eliminada correctamente";
                BtnActualizar.Visible = false;
                lblConfirmacion.Visible = false;
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

                lblEstado.Visible = true;
                DDEstado.Visible = true;
                BtnActualizar.Visible = true;
                btnCrearOrden.Visible = false;
                lblConfirmacion.Visible = false;

                lblError.Visible = true;
                lblError.Text = "Editando...";

                if (index >= 0 && index < BaseDeDatos.ListaOrdenes.Count)
                {

                    Orden orden = BaseDeDatos.ListaOrdenes[index];

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

                lblConfirmacion.Visible = true;
                lblConfirmacion.Text = "Orden actualizada correctamente";
                lblCreadoCorrectamente.Visible = false;
                btnCrearOrden.Visible = true;
                lblEstado.Visible = false;
                DDEstado.Visible = false;
                lblError.Visible = false;


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
