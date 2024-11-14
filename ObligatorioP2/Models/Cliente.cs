using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public class Cliente: Usuario
    {
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        public Cliente(string nombre, string apellido, string ci, string direccion, string telefono, string email) : base(nombre, apellido, ci)
        {

            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
        }

        public string getDireccion()
        {
            return Direccion;
        }

        public string getTelefono()
        {
            return Telefono;
        }

        public string getEmail()
        {
            return Email;
        }

        public void setDireccion(string direccion)
        {
            this.Direccion = direccion;
        }

        public void setTelefono(string telefono)
        {
            this.Telefono = telefono;
        }

        public void setEmail(string email)
        {
            this.Email = email;
        }
    }
}