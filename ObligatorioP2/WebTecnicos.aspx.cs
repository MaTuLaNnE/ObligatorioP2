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

            if (BaseDeDatos.Token == null || !BaseDeDatos.Token.esAdmin)
            {
                Response.Redirect("WebNoAdmin.aspx");
            }
            else
            {
                
                if (!IsPostBack)
                {
                    if (BaseDeDatos.ListaTecnico.Count == 0)
                    {
                        BaseDeDatos.PrecargarBD();
                    }
                    CargarClientesEnTabla();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCI.Text = "";
            txtClave.Text = "";
            ddlTipoServicio.ClearSelection();
            ddlTipoServicio.AutoPostBack = true;
        }

        private void EsconderLabels()
        {
            lblError.Visible = false;
        }

        private void CargarClientesEnTabla()
        {
            TablaTecnico1.DataSource = BaseDeDatos.ListaTecnico;
            TablaTecnico1.DataBind();
        }

        protected void CmdCrear(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlTipoServicio.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                lblError.Text = "Debe seleccionar una Especialidad";
            }
            else
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string ci = txtCI.Text;
                if (!CorroborarCI(ci))
                {

                    lblError.Text = "Debes agregar un documento valido";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    return;
                }

                string servicio = ddlTipoServicio.Text;

                string clave = txtClave.Text;


                Tecnico miTecnico = new Tecnico(nombre, apellido, ci, servicio, clave);

                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Tecnico creado correctamente";

                BaseDeDatos.ListaTecnico.Add(miTecnico);

                LimpiarCampos();

                CargarClientesEnTabla();


            }

        }



        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaTecnico.Count)
            {
                BaseDeDatos.ListaTecnico.RemoveAt(index);
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Tecnico eliminado correctamente";
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "OUT del rango.";
                return;
            }

            btnCrearTecnico.Visible = true;

            TablaTecnico1.EditIndex = -1;
            CargarClientesEnTabla();
            LimpiarCampos();

        }

        protected void TablaTecnico1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                for (int i = 0; i < BaseDeDatos.ListaTecnico.Count; i++)
                {
                    GridViewRow filaApagar = TablaTecnico1.Rows[i];

                    Button btnMostrarEditAbiertos = (Button)filaApagar.FindControl("btnEditar");
                    Button btnMostrarCancelAbiertos = (Button)filaApagar.FindControl("btnCancel");

                    btnMostrarEditAbiertos.Visible = true;
                    btnMostrarCancelAbiertos.Visible = false;

                }

                BtnActualizar.Visible = true;
                btnCrearTecnico.Visible = false;


                lblError.Visible = true;
                lblError.Text = "Editando...";



                GridViewRow fila = TablaTecnico1.Rows[index];

                Button btnMostrarEdit = (Button)fila.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)fila.FindControl("btnCancel");

                if (index >= 0 && index < BaseDeDatos.ListaTecnico.Count)
                {


                    Tecnico tecnico = BaseDeDatos.ListaTecnico[index];

                    btnMostrarEdit.Visible = false;
                    btnMostrarCancel.Visible = true;

                    txtNombre.Text = tecnico.Nombre;
                    txtApellido.Text = tecnico.Apellido;
                    txtCI.Text = tecnico.CI;
                    ddlTipoServicio.SelectedValue = tecnico.Especialidad;
                    txtClave.Text = tecnico.Clave;


                    rfvNombre.Enabled = false;
                    rfvApellido.Enabled = false;
                    rfcCI.Enabled = false;
                    rfcClave.Enabled = false;

                    // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
                    Session["TecnicoIndex"] = index;
                }
            }

            if (e.CommandName == "CancelEdit")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = TablaTecnico1.Rows[index];

                Button btnMostrarEdit = (Button)row.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)row.FindControl("btnCancel");

                btnMostrarEdit.Visible = true;
                btnMostrarCancel.Visible = false;

                lblError.Visible = false;

                rfvNombre.Enabled = true;
                rfvApellido.Enabled = true;
                rfcCI.Enabled = true;
                rfcClave.Enabled = true;

                BtnActualizar.Visible = false;
                btnCrearTecnico.Visible = true;

                LimpiarCampos();

            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que existe un índice almacenado en sesión
            if (Session["TecnicoIndex"] != null && !string.IsNullOrEmpty(ddlTipoServicio.Text))
            {
                int index = (int)Session["TecnicoIndex"];

                if (!CorroborarCI(txtCI.Text))
                {
                    lblError.Text = "Debes agregar un documento valido";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    return;
                }

                Tecnico tecnico = BaseDeDatos.ListaTecnico[index];

                tecnico.Nombre = txtNombre.Text;
                tecnico.Apellido = txtApellido.Text;
                tecnico.CI = txtCI.Text;
                tecnico.Especialidad = ddlTipoServicio.SelectedValue;
                tecnico.Clave = txtClave.Text;

                LimpiarCampos();
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Tecnico actualizado correctamente";
                btnCrearTecnico.Visible = true;


                rfvNombre.Enabled = true;
                rfvApellido.Enabled = true;
                rfcCI.Enabled = true;


                CargarClientesEnTabla();
                Session.Remove("TecnicoIndex");
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Debe seleccionar una Especialidad";
                return;
            }

        }

        public bool CorroborarCI(string ci)
        {
            // Verificar que la cédula tenga exactamente 8 caracteres y que todos sean dígitos
            if (string.IsNullOrEmpty(ci) || ci.Length != 8 || !ci.All(char.IsDigit))
            {
                return false;
            }


            for (int i = 0; i < BaseDeDatos.ListaTecnico.Count; i++)
            {
                Tecnico tecnico = BaseDeDatos.ListaTecnico[i];

                if (ci == tecnico.CI)
                {
                    return false;
                }

            }

            // Valores para la validación
            int[] valores = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;

            // Sumar el resultado de multiplicar los 8 primeros dígitos por los valores correspondientes
            for (int i = 0; i < valores.Length; i++)
            {
                int valor = int.Parse(ci[i].ToString());
                suma += valor * valores[i];
            }

            // Calcular el dígito verificador
            int residuo = suma % 10;
            int digitoVerificadorCalculado = (residuo == 0) ? 0 : 10 - residuo;
            int digitoActual = int.Parse(ci[7].ToString());

            return digitoVerificadorCalculado == digitoActual; // Comparar el dígito calculado con el ingresado
        }



    }
}