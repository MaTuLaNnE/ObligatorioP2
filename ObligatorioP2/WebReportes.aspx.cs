﻿using ObligatorioP2.Models;
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
                btnMostrarReportes.Visible = false;
                AutoCargar();
            }

            if (!IsPostBack)
            {
                DDTecnicos.DataSource = BaseDeDatos.ListaTecnico;
                DDTecnicos.DataTextField = "Nombre";
                DDTecnicos.DataValueField = "Nombre";
                DDTecnicos.DataBind();
                FiltrarOrdenesUltimoMes();
                MostrarOrdenesDelMes();
            }
            FiltrarOrdenesUltimoMes();
            MostrarOrdenesDelMes();

        }

        public static void FiltrarOrdenesUltimoMes()
        {

            BaseDeDatos.ListaMes.Clear();

            DateTime haceUnMes = DateTime.Now.AddDays(-30);

            foreach (var orden in BaseDeDatos.OrdenesxTecnico)
            {

                if (orden.Estado == "COMPLETADO" && orden.FechaCreacion >= haceUnMes)
                {
                    BaseDeDatos.ListaMes.Add(orden);
                }

         
            }
        }

        protected void MostrarOrdenesDelMes()
        {
            TablaOrdenes30.DataSource = BaseDeDatos.ListaMes;
            TablaOrdenes30.DataBind();

            if (BaseDeDatos.ListaMes.Count == 0)
            {
                TablaOrdenes30.EmptyDataText = "No hay órdenes completadas en los últimos 30 días.";
            }
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            AutoCargar();
        }

        private void AutoCargar()
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

            // Verificar si es admin
            if (BaseDeDatos.Token.esAdmin)
            {
                
                string tecnicoCI = DDTecnicos.SelectedValue;
                int index = DDTecnicos.SelectedIndex;

                if (tecnicoCI == "-1")
                {
                    
                    LimpiarReportes();
                    return;
                }

                
                Tecnico tecnicoSeleccionado = BaseDeDatos.ListaTecnico[index];

                if (tecnicoSeleccionado != null)
                {
                    foreach (var orden in BaseDeDatos.ListaOrdenes)
                    {
                        if (orden.NombreTecnico == tecnicoSeleccionado.Nombre)
                        {
                            numTotales++;
                            if (orden.Estado == "PENDIENTE") numPendiente++;
                            if (orden.Estado == "EN PROGRESO") numEnProgreso++;
                            if (orden.Estado == "COMPLETADO") numCompletado++;
                        }
                    }
                }
            }
            else
            {
                
                string tecnicoActual = BaseDeDatos.Token.Nombre;

                foreach (var orden in BaseDeDatos.ListaOrdenes)
                {
                    if (orden.NombreTecnico == tecnicoActual)
                    {
                        numTotales++;
                        if (orden.Estado == "PENDIENTE") numPendiente++;
                        if (orden.Estado == "EN PROGRESO") numEnProgreso++;
                        if (orden.Estado == "COMPLETADO") numCompletado++;
                    }
                }
            }

            
            lblCuantasTotal.Text = numTotales.ToString();
            lblCuantasPendientes.Text = numPendiente.ToString();
            lblCuantasEnProgreso.Text = numEnProgreso.ToString();
            lblCuantasCompletadas.Text = numCompletado.ToString();
        }

        
        private void LimpiarReportes()
        {
            lblCuantasTotal.Text = "0";
            lblCuantasPendientes.Text = "0";
            lblCuantasEnProgreso.Text = "0";
            lblCuantasCompletadas.Text = "0";
        }


    }
}