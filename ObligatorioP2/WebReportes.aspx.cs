using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioP2
{
    public partial class WebReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarReportesEnTabla();



        }
        private void CargarReportesEnTabla()
        {
            TablaReportes.DataSource = BaseDeDatos.OrdenesxTecnico;
            TablaReportes.DataBind();
        }
    }
}