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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.ListaTecnico.Count == 0)
                {
                    BaseDeDatos.PrecargarBD();
                }
            }

        }

        protected void CmdLogIn(object sender, EventArgs e)
        {
            var a = txtCI.Text;
            var b = txtClave.Text;

           
            for (int i = 0; i < BaseDeDatos.ListaTecnico.Count; i++)
            {
                Tecnico tecnico = BaseDeDatos.ListaTecnico[i];

                
                if (tecnico.CI == a && tecnico.Clave == b)
                {
                    BaseDeDatos.Token.Add(tecnico);
                    Response.Redirect("WebOrdenes.aspx");
                    return; 
                }

            }
            lblError.Visible = true;
            lblError.Text = "Datos de Ingreso Incorrectos";

        }

    }
}