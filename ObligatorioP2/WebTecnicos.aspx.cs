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
                CargarClientesEnTabla();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCI.Text = "";
            ddlTipoServicio.ClearSelection();
            ddlTipoServicio.AutoPostBack = true;
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
                var a = txtNombre.Text;
                var b = txtApellido.Text;
                var c = txtCI.Text;
                if (!CorroborarCI(c))
                {

                    lblError.Text = "Debes agregar un documento valido";
                    lblError.ForeColor= System.Drawing.Color.Red;
                    lblError.Visible = true;
                    return;
                }
                
                var d = ddlTipoServicio.Text;


                Tecnico miTecnico = new Tecnico(a, b, c, d);

                miTecnico.Nombre = a;
                miTecnico.Apellido = b;
                miTecnico.CI = c;
                miTecnico.Especialidad = d;
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

            TablaTecnico1.EditIndex = -1;
            CargarClientesEnTabla();
        }

        protected void TablaTecnico1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                BtnActualizar.Visible = true;
                btnCrearTecnico.Visible = false;
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