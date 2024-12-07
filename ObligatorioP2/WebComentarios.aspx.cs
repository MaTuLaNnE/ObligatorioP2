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
    public partial class WebComentarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.ListaTecnico.Count == 0 || BaseDeDatos.ListaClientes.Count == 0)
                {
                    BaseDeDatos.PrecargarBD();

                }
                CargarComentarios();
            }

        }



        public void CargarComentarios()
        {
            if (Session["OrdenIndex"] != null)
            {
                int index = (int)Session["OrdenIndex"];

                Orden ordenSeleccionada = BaseDeDatos.OrdenesxTecnico[index];

                Orden ordenEnLista = BaseDeDatos.ListaOrdenes.FirstOrDefault(orden => orden.NroOrden == ordenSeleccionada.NroOrden);

                BLComentarios.Visible = true;
                BLComentarios.DataSource = ordenEnLista.ListaComentarios;
                BLComentarios.DataBind();
            }
            else
            {
                BLComentarios.Visible = false;

            }
        }


        protected void btnAgregarComments_Click(object sender, EventArgs e)
        {

            if (Session["OrdenIndex"] != null)
            {
                int index = (int)Session["OrdenIndex"];

                Orden ordenSeleccionada = BaseDeDatos.OrdenesxTecnico[index];

                Orden ordenEnLista = BaseDeDatos.ListaOrdenes.FirstOrDefault(orden => orden.NroOrden == ordenSeleccionada.NroOrden);

                string comentario = txtComentario.Text;

                ordenSeleccionada.ListaComentarios.Add(comentario);

                ordenSeleccionada.ListaComentarios.RemoveAt(0);

                lblConfirmacion.Visible = true;
                lblConfirmacion.Text = "Comentario agregado correctamente";

                BLComentarios.DataSource = ordenEnLista.ListaComentarios;
                BLComentarios.DataBind();
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            rfvComentario.Enabled = false;
            Response.Redirect("WebOrdenes.aspx");
        }



    }
}