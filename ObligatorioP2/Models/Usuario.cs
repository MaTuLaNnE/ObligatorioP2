using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public class Usuario
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }


        public Usuario(string Nombre, string Apellido, string ci)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.CI = ci;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public string getApellido()
        {
            return Apellido;
        }

        public string getCI()
        {
            return CI;
        }

        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public void setApellido(string apellido)
        {
            this.Apellido = apellido;
        }

        public void setCI(string ci)
        {
            this.CI = ci;
        }

   
    }
}