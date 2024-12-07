using ObligatorioP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioP2
{
    public partial class WebInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarPanelesOrdenes();


            Tecnico tecnico = BaseDeDatos.Token;
            titulo.Text = "Bienvenido Tecnico " + tecnico.Nombre;
        }

        private void GenerarPanelesOrdenes()
        {

            foreach (var orden in BaseDeDatos.OrdenesxTecnico)
            {
                // Crear un panel para cada orden UTLIZAMOS ESTE METODO PARA CREAR DIVS/PANELES POR CADA ORDEN DE CADA TECNICO
                Panel panelOrden = new Panel
                {
                    CssClass = "panel-orden",
                    ID = $"panelOrden_{orden.NroOrden}"
                };

                // Agregar etiquetas con información de la orden
                panelOrden.Controls.Add(new Literal
                {
                    Text = $@"
                    <div class='orden-info'>
                        <h3>Orden #{orden.NroOrden}</h3>
                        <p><strong>Cliente:</strong> {orden.NombreCliente}</p>
                        <p><strong>Técnico:</strong> {orden.NombreTecnico}</p>
                        <p><strong>Servicio:</strong> {orden.TipoDeServicio}</p>
                        <p><strong>Descripción:</strong> {orden.DescripcionProblema}</p>
                        <p><strong>Fecha de creación:</strong> {orden.FechaCreacion.ToShortDateString()}</p>
                        <p><strong>Estado:</strong> {orden.Estado}</p>
                        <p><strong>Comentarios:</strong> {string.Join(" | ", orden.ListaComentarios)}</p>
                    </div>"
                });

                // Agregar el panel al contenedor principal
                ContenedorOrdenes.Controls.Add(panelOrden);
            }
        }




    }
}