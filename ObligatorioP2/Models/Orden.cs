﻿using System;
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
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } 
        public string TipoDeServicio { get; set; }

        public List<string> ListaComentarios = new List<string>();



        public Orden(int nroOrden, string cliente, string tecnico,string tipoDeServicio, string descripcionProblema, DateTime fechaCreacion, string estado, List<string> listacomentarios) 
        {
            this.NroOrden = nroOrden;
            this.NombreCliente = cliente;
            this.NombreTecnico = tecnico;
            this.TipoDeServicio = tipoDeServicio;
            this.DescripcionProblema = descripcionProblema;
            this.FechaCreacion = fechaCreacion;
            this.Estado = estado;
  
            this.ListaComentarios = listacomentarios;

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

            return FechaCreacion;
        }

        public void setFechaCreacion(DateTime fechaCreacion)
        {
            this.FechaCreacion = fechaCreacion;
        }

        public string getEstado()
        {
            return Estado;
        }

        public void setEstado(string estado)
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

    }
}