using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioP2
{
    public partial class WebTecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.ListaTecnico.Count == 0)
                {
                    BaseDeDatos.PrecargarBD();
                }
                TablaTecnico1.DataSource = BaseDeDatos.ListaTecnico;
                TablaTecnico1.DataBind();
            }
        }

        protected void CmdCrear(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlTipoServicio.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Debe seleccionar una Especialidad";
            }
            else
            {
                var a = txtNombre.Text;
                var b = txtApellido.Text;
                var c = txtCI.Text;
                var d = ddlTipoServicio.Text;


                Tecnico miTecnico = new Tecnico(a, b, c, d);

                miTecnico.Nombre = a;
                miTecnico.Apellido = b;
                miTecnico.CI = c;
                miTecnico.Especialidad = d;
                lblError.Visible = true;
                lblError.Text = "Tecnico creado correctamente";

                BaseDeDatos.ListaTecnico.Add(miTecnico);

                TablaTecnico1.DataSource = BaseDeDatos.ListaTecnico;
                TablaTecnico1.DataBind();

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCI.Text = "";
                ddlTipoServicio.ClearSelection();
                ddlTipoServicio.AutoPostBack = true;
            }

        }



        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaTecnico.Count)
            {
                BaseDeDatos.ListaTecnico.RemoveAt(index);
                lblError.Visible = true;
                lblError.Text = "Tecnico eliminado correctamente";
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "OUT del rango.";
                return;
            }

            TablaTecnico1.EditIndex = -1;
            TablaTecnico1.DataSource = BaseDeDatos.ListaTecnico;
            TablaTecnico1.DataBind();
        }

        protected void TablaTecnico1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                BtnActualizar.Visible = true;
                lblError.Visible = false;

                if (index >= 0 && index < BaseDeDatos.ListaTecnico.Count)
                {


                    Tecnico tecnico = BaseDeDatos.ListaTecnico[index];

                    txtNombre.Text = tecnico.Nombre;
                    txtApellido.Text = tecnico.Apellido;
                    txtCI.Text = tecnico.CI;
                    ddlTipoServicio.SelectedValue = tecnico.Especialidad;


                    rfvNombre.Enabled = false;
                    rfvApellido.Enabled = false;
                    rfcCI.Enabled = false;

                    // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
                    Session["TecnicoIndex"] = index;
                }
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que existe un índice almacenado en sesión
            if (Session["TecnicoIndex"] != null && !string.IsNullOrEmpty(ddlTipoServicio.Text))
            {
                int index = (int)Session["TecnicoIndex"];

                Tecnico tecnico = BaseDeDatos.ListaTecnico[index];

                tecnico.Nombre = txtNombre.Text;
                tecnico.Apellido = txtApellido.Text;
                tecnico.CI = txtCI.Text;
                tecnico.Especialidad = ddlTipoServicio.SelectedValue;

                // Limpia 
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCI.Text = "";
                ddlTipoServicio.ClearSelection();
                lblError.Visible = true;
                lblError.Text = "Tecnico actualizado correctamente";


                rfvNombre.Enabled = true;
                rfvApellido.Enabled = true;
                rfcCI.Enabled = true;


                TablaTecnico1.DataSource = BaseDeDatos.ListaTecnico;
                TablaTecnico1.DataBind();
                Session.Remove("TecnicoIndex");
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Debe seleccionar una Especialidad";
                return;
            }


        }

    }
}