using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioP2.Models
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> ListaClientes = new List<Cliente>();
        public static List<Tecnico> ListaTecnico = new List<Tecnico>();
        public static List<Orden> ListaOrdenes = new List<Orden>();
        public static List<string> Lista = new List<string>();



        public static void PrecargarBD()
        {
            Cliente Cli1 = new Cliente("Jose", "Perez", "50237326", "Sarandi 234", "097342631", "jperez@gmail.com");
            Cliente Cli2 = new Cliente("Pepe", "Silva", "44094112", "Gorlero 890", "094621001", "elpepe777@gmail.com");
            Cliente Cli3 = new Cliente("Ricardo", "Gonzalez", "51017628", "25 de Mayo 1001", "098150787", "RicarditoDDL@gmail.com");

            ListaClientes.Add(Cli1);
            ListaClientes.Add(Cli2);
            ListaClientes.Add(Cli3);

            Tecnico Tec1 = new Tecnico("Juan", "Manuel", "34653871", "Reparacion");
            Tecnico Tec2 = new Tecnico("Gabriel", "Medina", "48769321", "Montaje");


            ListaTecnico.Add(Tec1);
            ListaTecnico.Add(Tec2);


            string kk = "jshdjshd";
            string aaa = "jhdgfjdhg";
            string hghg = "me cao en toS";

            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();

            list1.Add(kk);
            list1.Add(aaa);
            list1.Add(hghg);

            list2.Add(kk);
            list2.Add(aaa);
            list2.Add(hghg);


            Orden Orden1 = new Orden(1, Cli1.Nombre, Tec2.Nombre, "Sistemas", DateTime.Now, "Este es el problema", DateTime.Now, "EN PROGRESO", list1);
            Orden Orden2 = new Orden(2, Cli1.Nombre, Tec1.Nombre, "Montaje", DateTime.Now, "Este es el problema nuevo", DateTime.Now, "COMPLETADO", list2);

            ListaOrdenes.Add(Orden1);
            ListaOrdenes.Add(Orden2);



        }
    }
}