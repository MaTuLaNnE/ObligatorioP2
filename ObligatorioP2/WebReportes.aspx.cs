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
            CargarReportes();

        }
        private void CargarReportes()
        {
            Tecnico tecnicoActual = BaseDeDatos.Token;

            int numPendiente = 0;
            int numEnProgreso = 0;
            int numCompletado = 0;

            for (int i = 0; i < BaseDeDatos.OrdenesxTecnico.Count; i++)
            {
                if ((tecnicoActual.Nombre == BaseDeDatos.OrdenesxTecnico[i].NombreTecnico || tecnicoActual.esAdmin) && BaseDeDatos.OrdenesxTecnico[i].Estado == "PENDIENTE")
                {
                    numPendiente++;
                }
                if ((tecnicoActual.Nombre == BaseDeDatos.OrdenesxTecnico[i].NombreTecnico || tecnicoActual.esAdmin) && BaseDeDatos.OrdenesxTecnico[i].Estado == "EN PROGRESO")
                {
                    numEnProgreso++;
                }
                if ((tecnicoActual.Nombre == BaseDeDatos.OrdenesxTecnico[i].NombreTecnico || tecnicoActual.esAdmin) && BaseDeDatos.OrdenesxTecnico[i].Estado == "COMPLETADO")
                {
                    numCompletado++;
                }

            } 





            lblCuantasPendientes.Text = numPendiente.ToString();
            lblCuantasEnProgreso.Text = numEnProgreso.ToString();
            lblCuantasCompletadas.Text = numCompletado.ToString();

        }
    }
}