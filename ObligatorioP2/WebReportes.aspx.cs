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
            if (!BaseDeDatos.Token.esAdmin)
            {
                lblNombreTecnico.Visible = false;
                DDTecnicos.Visible = false;
            }

            if (!IsPostBack)
            {
                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataValueField = "Nombre";
                DDTecnicos.DataBind();

                lblPendientes.Visible = false;
                lblCuantasPendientes.Visible=false;
                lblEnProgreso.Visible = false;
                lblCuantasEnProgreso.Visible=false;
                lblCompletadas.Visible = false;
                lblCuantasCompletadas.Visible=false;
                lblTotal.Visible = false;
                lblCuantasTotal.Visible=false;
            }


        }
        protected void Confirmar_Click(object sender, EventArgs e)
        {
            // Obtén el valor seleccionado, que es el "CI" del técnico
            string tecnicoCI = DDTecnicos.SelectedValue;
            int index = DDTecnicos.SelectedIndex;

            if (tecnicoCI == "-1") // Si se seleccionó la opción "Seleccione un Tecnico"
            {
                // Si no se seleccionó un técnico, limpia los valores
                LimpiarReportes();
                return;
            }

            // Encuentra el técnico seleccionado en la lista
            Tecnico tecnicoSeleccionado = BaseDeDatos.ListaTecnico[index];

            if (tecnicoSeleccionado != null)
            {
                int numPendiente = 0;
                int numEnProgreso = 0;
                int numCompletado = 0;
                int numTotales = 0;

                lblPendientes.Visible = true;
                lblCuantasPendientes.Visible = true;
                lblEnProgreso.Visible = true;
                lblCuantasEnProgreso.Visible = true;
                lblCompletadas.Visible = true;
                lblCuantasCompletadas.Visible = true;
                lblTotal.Visible = true;
                lblCuantasTotal.Visible = true;

                // Si es admin, cuenta las órdenes de todos los técnicos
                if (BaseDeDatos.Token.esAdmin)
                {
                    foreach (var orden in BaseDeDatos.ListaOrdenes)
                    {
                        numTotales++;

                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre && orden.Estado == "PENDIENTE")
                        {
                            numPendiente++;
                        }
                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre && orden.Estado == "EN PROGRESO")
                        {
                            numEnProgreso++;
                        }
                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre && orden.Estado == "COMPLETADO")
                        {
                            numCompletado++;
                        }
                    }
                }
                else // Si no es admin, solo cuenta las órdenes del técnico actual
                {
                    foreach (var orden in BaseDeDatos.OrdenesxTecnico)
                    {
                        numTotales++;

                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre && orden.Estado == "PENDIENTE")
                        {
                            numPendiente++;
                        }
                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre && orden.Estado == "EN PROGRESO")
                        {
                            numEnProgreso++;
                        }
                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre && orden.Estado == "COMPLETADO")
                        {
                            numCompletado++;
                        }
                    }
                }

                // Actualiza las etiquetas con los valores calculados
                lblCuantasTotal.Text = numTotales.ToString();
                lblCuantasPendientes.Text = numPendiente.ToString();
                lblCuantasEnProgreso.Text = numEnProgreso.ToString();
                lblCuantasCompletadas.Text = numCompletado.ToString();
            }
        }

        // Método para limpiar los reportes
        private void LimpiarReportes()
        {
            lblCuantasTotal.Text = "0";
            lblCuantasPendientes.Text = "0";
            lblCuantasEnProgreso.Text = "0";
            lblCuantasCompletadas.Text = "0";
        }

        
    }
}