using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public class Tecnico : Usuario
    {
        public string Especialidad { get; set; }

        public string Clave { get; set; }

        public Tecnico(string Nombre, string Apellido, string ci, string especialidad, string clave) : base(Nombre, Apellido, ci)
        {
            this.Especialidad = especialidad;
            Clave = clave;
        }

        public string getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(string Especialidad)
        {
            this.Especialidad = Especialidad;
        }

        public string getClave()
        {
            return Clave;
        }

        public void setClave(string clave)
        {
            this.Clave = clave;
        }
    }
}