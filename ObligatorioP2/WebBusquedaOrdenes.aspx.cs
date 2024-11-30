using Microsoft.Ajax.Utilities;
using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            int NroOrden = Convert.ToInt32(txtOrden.Text);


            Orden orden = BaseDeDatos.BuscadorDeOrden(NroOrden);

            if (NroOrden <= 0 || Convert.ToInt32(NroOrden) > BaseDeDatos.UltimoNumeroDeOrden || orden == null)
            {
                lblEstado.Text = "kk con patas";
                return;
            }
            else
            {



                lblInfoCliente.Text = orden.NombreCliente;
                lblInfoTecnico.Text = orden.NombreTecnico;

                BLComentarios.DataSource = orden.ListaComentarios;
                BLComentarios.DataBind();

                lblEstado.Text = orden.Estado;
                lblEstado.CssClass = orden.Estado.Replace(" ", "");
            }


        }
    }
}