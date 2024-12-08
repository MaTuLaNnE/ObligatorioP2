using Antlr.Runtime.Misc;
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
    public partial class WebClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.ListaClientes.Count == 0) // Solo precarga si la lista está vacía
                {
                    BaseDeDatos.PrecargarBD();
                }


                CargarClientesEnTabla();

            }

            rfvNombre.Enabled = false;
            rfvApellido.Enabled = false;
            rfcCI.Enabled = false;
        }

        private void CargarClientesEnTabla()
        {
            TablaClientes1.DataSource = BaseDeDatos.ListaClientes;
            TablaClientes1.DataBind();
        }

        private void EsconderLabels()
        {
            lblCreadoCorrectamente.Visible = false;
            lblError.Visible = false;
        }

        protected void CmdCrear(object sender, EventArgs e)
        {

            EsconderLabels();

            rfvNombre.Visible = true;
            rfvApellido.Visible = true;
            rfcCI.Visible = true;

            rfvNombre.Enabled = true;
            rfvApellido.Enabled = true;
            rfcCI.Enabled = true;


            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtTelefono.Text))
            {

                lblError.Text = "Debes agregar un metodo de contacto";
                lblError.Visible = true;

            }
            else
            {

                string Nombre = txtNombre.Text;
                string Apellido = txtApellido.Text;
                string ci = txtCI.Text;


                if (!CorroborarCI(ci))
                {

                    lblError.Text = "Debes agregar un documento valido";
                    lblError.Visible = true;
                    return;
                }
                string direccion = txtDireccion.Text;
                string Telefono = txtTelefono.Text;
                string email = txtEmail.Text;

                Cliente miCliente = new Cliente(Nombre, Apellido, ci, direccion, Telefono, email);

                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Cliente creado correctamente";
                rfvNombre.Enabled = false;
                rfvApellido.Enabled = false;
                rfcCI.Enabled = false;

                BaseDeDatos.ListaClientes.Add(miCliente);



                CargarClientesEnTabla();

                LimpiarCampos();
                lblError.Visible = false;
            }




        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCI.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        protected void EliminarCliente(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaClientes.Count)
            {
                EsconderLabels();
                BaseDeDatos.ListaClientes.RemoveAt(index);
                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Cliente eliminado correctamente";
                BtnActualizar.Visible = false;
                LimpiarCampos();
            }
            else
            {
                lblError.Text = "OUT del rango.";
                return;
            }

            btnCrearUsuario.Visible = true;

            TablaClientes1.EditIndex = -1;
            CargarClientesEnTabla();

        }

        protected void TablaClientes1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                for (int i = 0; i < BaseDeDatos.ListaClientes.Count; i++)
                {
                    GridViewRow ala = TablaClientes1.Rows[i];

                    Button btnMostrarEditAbiertos = (Button)ala.FindControl("btnEditar");
                    Button btnMostrarCancelAbiertos = (Button)ala.FindControl("btnCancel");

                    btnMostrarEditAbiertos.Visible = true;
                    btnMostrarCancelAbiertos.Visible = false;

                }

                BtnActualizar.Visible = true;

                btnCrearUsuario.Visible = false;
                lblCreadoCorrectamente.Visible = false;

                lblError.Visible = true;
                lblError.Text = "Editando...";

                GridViewRow row = TablaClientes1.Rows[index];

                Button btnMostrarEdit = (Button)row.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)row.FindControl("btnCancel");

                if (index >= 0 && index < BaseDeDatos.ListaClientes.Count)
                {

                    Cliente cliente = BaseDeDatos.ListaClientes[index];

                    btnMostrarEdit.Visible = false;
                    btnMostrarCancel.Visible = true;

                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtCI.Text = cliente.CI;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    txtEmail.Text = cliente.Email;


                    rfvNombre.Enabled = false;
                    rfvApellido.Enabled = false;
                    rfcCI.Enabled = false;

                    // Guarda el índice del técnico en una variable de sesión para usarlo al actualizar
                    Session["ClienteIndex"] = index;
                }
            }
            if (e.CommandName == "CancelEdit")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = TablaClientes1.Rows[index];

                Button btnMostrarEdit = (Button)row.FindControl("btnEditar");
                Button btnMostrarCancel = (Button)row.FindControl("btnCancel");

                btnMostrarEdit.Visible = true;
                btnMostrarCancel.Visible = false;

                lblError.Visible = false;

                rfvNombre.Enabled = true;
                rfvApellido.Enabled = true;
                rfcCI.Enabled = true;

                BtnActualizar.Visible = false;
                btnCrearUsuario.Visible = true;

                LimpiarCampos();

            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que existe un índice almacenado en sesión
            if (Session["ClienteIndex"] != null)
            {
                int index = (int)Session["ClienteIndex"];

                rfvNombre.Enabled = true;
                rfvApellido.Enabled = true;
                rfcCI.Enabled = true;

                rfvNombre.Visible = true;
                rfvApellido.Visible = true;
                rfcCI.Visible = true;

                if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtTelefono.Text))
                {

                    lblError.Text = "Debes agregar un metodo de contacto";
                    lblError.Visible = true;

                }
                else
                {
                    if (!CorroborarCI(txtCI.Text))
                    {
                        lblError.Text = "Debes agregar un documento valido";
                        lblError.Visible = true;
                        return;
                    }

                    Cliente cliente = BaseDeDatos.ListaClientes[index];
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.CI = txtCI.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Email = txtEmail.Text;
                    LimpiarCampos();
                    lblCreadoCorrectamente.Visible = true;
                    lblCreadoCorrectamente.Text = "Cliente actualizado correctamente";
                    btnCrearUsuario.Visible = true;
                    lblError.Visible = false;
                    rfvNombre.Enabled = false;
                    rfvApellido.Enabled = false;
                    rfcCI.Enabled = false;
                    CargarClientesEnTabla();
                    Session.Remove("ClienteIndex");
                    BtnActualizar.Visible = false;
                }

            }
        }
        public bool CorroborarCI(string ci)
        {
            // Verificar que la cédula tenga exactamente 8 caracteres y que todos sean dígitos
            if (string.IsNullOrEmpty(ci) || ci.Length != 8 || !ci.All(char.IsDigit))
            {
                return false;
            }

            for (int i = 0; i < BaseDeDatos.ListaClientes.Count; i++)
            {
                Cliente cliente = BaseDeDatos.ListaClientes[i];

                if (ci == cliente.CI)
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