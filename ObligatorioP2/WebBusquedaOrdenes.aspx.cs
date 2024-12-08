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
            if (!IsPostBack)
            {
                lblCli.Visible = false;
                lblTec.Visible = false;
                lblEst.Visible = false;
                lblComentarios.Visible = false;
                lblInfoCliente.Visible = false;
                lblInfoTecnico.Visible = false;
                BLComentarios.Visible = false;
                lblEstado.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int NroOrden = Convert.ToInt32(txtOrden.Text);


            Orden orden = BaseDeDatos.BuscadorDeOrden(NroOrden);

            if (NroOrden <= 0 || Convert.ToInt32(NroOrden) > BaseDeDatos.UltimoNumeroDeOrden || orden == null)
            {
                lblCli.Visible = false;
                lblTec.Visible = false;
                lblEst.Visible = false;
                lblComentarios.Visible = false;
                lblInfoCliente.Visible = false;
                lblInfoTecnico.Visible = false;
                BLComentarios.Visible = false;
                lblEstado.Visible = false;
                lblConfirmacion.Visible = true;
                lblConfirmacion.Text = "No existe ninguna orden con el número de orden indicado";
                return;
            }
            else
            {
                lblCli.Visible = true;
                lblTec.Visible = true;
                lblEst.Visible = true;
                lblComentarios.Visible = true;
                lblInfoCliente.Visible = true;
                lblInfoTecnico.Visible = true;
                BLComentarios.Visible = true; 
                lblEstado.Visible = true;
                lblConfirmacion.Visible = false;
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