using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioP2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if(BaseDeDatos.Token != null)
                {

                    Tecnico tecnico = BaseDeDatos.Token;


                    if (tecnico.CI == "50140797" && tecnico.Clave == "1111")
                    {
                        chau.Visible = true;
                        return;
                    }
                    else
                    {
                        chau.Visible = false;
                        return;
                    }

                }
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            BaseDeDatos.Token = null;
            Response.Redirect("Login.aspx");
            BaseDeDatos.OrdenesxTecnico.Clear();
        }


    }
}