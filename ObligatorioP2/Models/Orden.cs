using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public class Orden
    {
        public int NroOrden { get; set; }
        public string NombreCliente { get; set; }
        public string NombreTecnico { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Estado Estado { get; set; } //Podemos intentar sacar al estado de ser un ENUM para no complicarla tanto
        public string EstadoEnString { get; set; } //?????? (Se usa en la tabla de orden)
        public string TipoDeServicio { get; set; }
        public string ComentariosTecnico { get; set; }

        public List<string> ListaComentarios = new List<string>();

        public static List<int> HistorialOrdenes = new List<int>();



        public Orden(int nroOrden, string cliente, string tecnico,string tipoDeServicio, DateTime fecha, string descripcionProblema, DateTime fechaCreacion, string estado, List<string> listacomentarios) // OJO Q CAMBIE CLIENTE Y TECNICO POR STRING
        {
            this.NroOrden = nroOrden;
            this.NombreCliente = cliente;
            this.NombreTecnico = tecnico;
            this.TipoDeServicio = tipoDeServicio;
            this.Fecha = fecha;
            this.DescripcionProblema = descripcionProblema;
            this.FechaCreacion = fechaCreacion;
            this.EstadoEnString = estado;
            //this.ComentariosTecnico = comentariosTecnico;
            this.ListaComentarios = listacomentarios;

        }

        public Orden(int nroOrden, string cliente , string tecnico, string tipoDeServicio, DateTime fecha, string estadoEnString) //Usado en la tabla ordenes
        {
            
            NroOrden = nroOrden;
            NombreCliente = cliente;
            NombreTecnico = tecnico;
            TipoDeServicio = tipoDeServicio;
            Fecha = fecha;
            EstadoEnString = estadoEnString;
        }

        public int CrearNroOrden()
        {

            for (int i = 0; i <= BaseDeDatos.ListaOrdenes.Count; i++)
            {
                HistorialOrdenes.Add(i);

                while (HistorialOrdenes.Contains(i))
                {
                    i++;
                }

                NroOrden = i;
            }

            return NroOrden;
        }

        public int getNroOrden()
        {
            return NroOrden;
        }

        public void setNroOrden(int nroOrden)
        {
            this.NroOrden = nroOrden;
        }

        public string getCliente()
        {
            return NombreCliente;
        }

        public void setCliente(string cliente)
        {
            this.NombreCliente = cliente;
        }

        public string getTecnico()
        {
            return NombreTecnico;
        }

        public void setTecnico(string tecnico)
        {
            this.NombreTecnico = tecnico;
        }

        public string getDescripcionProblema()
        {
            return DescripcionProblema;
        }

        public void setDescripcionProblema(string descripcionProblema)
        {
            this.DescripcionProblema = descripcionProblema;
        }

        public DateTime getFechaCreacion()
        {
            DateTime fechaCreacion = DateTime.Now;

            return fechaCreacion;
        }

        public void setFechaCreacion(DateTime fechaCreacion)
        {
            this.FechaCreacion = fechaCreacion;
        }

        public Estado getEstado()
        {
            return Estado;
        }

        public void setEstado(Estado estado)
        {
            this.Estado = estado;
        }

        public string getTipoServicio()
        {
            return TipoDeServicio;
        }

        public void setTipoServicio(string tipoDeServicio)
        {
            this.TipoDeServicio = tipoDeServicio;
        }

        public string getComentariosTecnico()
        {
            return ComentariosTecnico;
        }

        public void setComentariosTecnico(string comentariosTecnico)
        {
            this.ComentariosTecnico = comentariosTecnico;
        }

        public void ColocarComentarioEnLista(string comentario) // EDITANDO |||| NO TERMINADO
        {
            ListaComentarios.Add(comentario);        }
    }
}