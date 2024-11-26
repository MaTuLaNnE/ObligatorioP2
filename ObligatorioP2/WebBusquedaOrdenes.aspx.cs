using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioP2
{
    public partial class WebBusquedaOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtOrden == null)
            {
               
            }

            Orden orden = BaseDeDatos.BuscadorDeOrden(Convert.ToInt32(txtOrden.Text));

            lblInfoCliente.Text = orden.NombreCliente;
            lblInfoTecnico.Text = orden.NombreTecnico;

            BLComentarios.DataSource = orden.ListaComentarios;
            BLComentarios.DataBind();

            lblEstado.Text = orden.Estado;
            lblEstado.CssClass = orden.Estado.Replace(" ", "");



        }
    }
}