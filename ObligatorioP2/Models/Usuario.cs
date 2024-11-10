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

        public bool CorroborarCI(string ci)
        {

            int[] valores = { 2, 9, 8, 7, 6, 5, 4, 3 };
            int suma = 0;
            int[] CILista = new int[8];
            bool digitoCorrecto = false;

            int digitoActual = int.Parse(ci[8].ToString());

            for (int i = 0; i < 8; i++)
            {
                CILista[i] = int.Parse(ci[i].ToString());

                suma += (CILista[i] * valores[i]);
            }

            int residuo = suma % 10;
            int digitoVerificador = 10 - residuo;

            if (digitoVerificador == digitoActual)
            {
                digitoCorrecto = true;

            }
            else { digitoCorrecto = false; }

            return digitoCorrecto;

        }
    }
}