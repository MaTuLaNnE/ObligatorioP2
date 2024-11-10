using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public class Tecnico : Usuario
    {
        public string Especialidad { get; set; }

        public Tecnico(string Nombre, string Apellido, string ci, string especialidad) : base(Nombre, Apellido, ci)
        {
            this.Especialidad = especialidad;
        }

        public string getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(string Especialidad)
        {
            this.Especialidad = Especialidad;
        }
    }
}