using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public class Orden
    {
        public int NroOrden { get; set; }
        public Cliente Cliente { get; set; }
        public Tecnico Tecnico { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Estado Estado { get; set; }
        public string ComentariosTecnico { get; set; }

        public List<string> ListaComentarios = new List<string>();

        public Orden(int nroOrden, Cliente cliente, Tecnico tecnico, DateTime fecha, string descripcionProblema, DateTime fechaCreacion, Estado estado, List<string> listacomentarios)
        {
            this.NroOrden = nroOrden;
            this.Cliente = cliente;
            this.Tecnico = tecnico;
            this.Fecha = fecha;
            this.DescripcionProblema = descripcionProblema;
            this.FechaCreacion = fechaCreacion;
            this.Estado = estado;
            //this.ComentariosTecnico = comentariosTecnico;
            this.ListaComentarios = listacomentarios;

        }

        public int getNroOrden()
        {

            for (int i = 0; i < Convert.ToInt32(BaseDeDatos.ListaOrdenes.Count); i++)
            {
                NroOrden = i;
            }

            return NroOrden;
        }

        public void setNroOrden(int nroOrden)
        {
            this.NroOrden = nroOrden;
        }

        public Cliente getCliente()
        {
            return Cliente;
        }

        public void setCliente(Cliente cliente)
        {
            this.Cliente = cliente;
        }

        public Tecnico getTecnico()
        {
            return Tecnico;
        }

        public void setTecnico(Tecnico tecnico)
        {
            this.Tecnico = tecnico;
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
            return FechaCreacion;
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

        public string getComentariosTecnico()
        {
            return ComentariosTecnico;
        }

        public void setComentariosTecnico(string comentariosTecnico)
        {
            this.ComentariosTecnico = comentariosTecnico;
        }
    }
}