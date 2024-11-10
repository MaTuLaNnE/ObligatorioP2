﻿using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void CargarClientesEnTabla()
        {
            TablaClientes1.DataSource = BaseDeDatos.ListaClientes;
            TablaClientes1.DataBind();
        }

        protected void CmdCrear(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtTelefono.Text))
            {

                lblError.Text = "Debes agregar un metodo de contacto";
                lblError.Visible = true;

            }
            else
            {
                var a = txtNombre.Text;
                var b = txtApellido.Text;
                var c = txtCI.Text;
                var d = txtDireccion.Text;
                var ea = txtTelefono.Text;
                var f = txtEmail.Text;

                Cliente miCliente = new Cliente(a, b, c, d, ea, f);

                miCliente.Nombre = a;
                miCliente.Apellido = b;
                miCliente.CI = c;
                miCliente.Direccion = d;
                miCliente.Telefono = ea;
                miCliente.Email = f;
                lblCreadoCorrectamente.Visible = true;
                lblCreadoCorrectamente.Text = "Cliente creado correctamente";

                BaseDeDatos.ListaClientes.Add(miCliente);



                CargarClientesEnTabla();

                LimpiarCampos();
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

        protected void TeBorroALaMierda(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.ListaClientes.Count)
            {
                BaseDeDatos.ListaClientes.RemoveAt(index);
                lblError.Visible = true;
                lblError.Text = "Cliente eliminado correctamente";
                BtnActualizar.Visible = false;
            }
            else
            {
                lblError.Text = "OUT del rango.";
                return;
            }

            TablaClientes1.EditIndex = -1;
            CargarClientesEnTabla();

        }

        protected void TablaClientes1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                BtnActualizar.Visible = true;
                lblError.Visible = false;

                if (index >= 0 && index < BaseDeDatos.ListaClientes.Count)
                {

                    Cliente cliente = BaseDeDatos.ListaClientes[index];

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
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que existe un índice almacenado en sesión
            if (Session["ClienteIndex"] != null)
            {
                int index = (int)Session["ClienteIndex"];

                Cliente cliente = BaseDeDatos.ListaClientes[index];

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.CI = txtCI.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Email = txtEmail.Text;

                LimpiarCampos();

                lblError.Visible = true;
                lblError.Text = "Cliente actualizado correctamente";


                rfvNombre.Enabled = true;
                rfvApellido.Enabled = true;
                rfcCI.Enabled = true;

                CargarClientesEnTabla();

                Session.Remove("ClienteIndex");
                BtnActualizar.Visible = false;
            }
        }


    }
}