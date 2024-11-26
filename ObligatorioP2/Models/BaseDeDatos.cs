using Microsoft.Ajax.Utilities;
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

        public static Tecnico Token;
        public static int UltimoNumeroDeOrden;


        public static void PrecargarBD()
        {
            UltimoNumeroDeOrden = 0;
            Cliente Cli1 = new Cliente("Jose", "Perez", "50237326", "Sarandi 234", "097342631", "jperez@gmail.com");
            Cliente Cli2 = new Cliente("Pepe", "Silva", "44094112", "Gorlero 890", "094621001", "elpepe777@gmail.com");
            Cliente Cli3 = new Cliente("Ricardo", "Gonzalez", "51017628", "25 de Mayo 1001", "098150787", "RicarditoDDL@gmail.com");

            ListaClientes.Add(Cli1);
            ListaClientes.Add(Cli2);
            ListaClientes.Add(Cli3);

            Tecnico Tec1 = new Tecnico("Juan", "Manuel", "34653871", "Reparacion", "1234");
            Tecnico Tec2 = new Tecnico("Gabriel", "Medina", "48769321", "Montaje", "5678");

            Tecnico admin = new Tecnico("Admin", "Medina", "50140797", "ToLosPoderes", "1111", true);


            ListaTecnico.Add(Tec1);
            ListaTecnico.Add(Tec2);
            ListaTecnico.Add(admin);



            string kk = "jshdjshd";
            string aaa = "Hola";
            string hghg = "me cao en toS";


            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();

            list1.Add(kk);


            list2.Add(aaa);
            list2.Add(hghg);


            BaseDeDatos.crearOrden(Cli1.Nombre, Tec2.Nombre, "Sistemas", "Este es el problema", DateTime.Now.Date, "EN PROGRESO", list1);
            BaseDeDatos.crearOrden(Cli1.Nombre, Tec1.Nombre, "Montaje", "Este es el problema nuevo", DateTime.Now.Date, "COMPLETADO", list2);
        }
        public static Orden crearOrden(string cliente, string tecnico, string tipoDeServicio, string descripcionProblema, DateTime fechaCreacion, string estado, List<string> listacomentarios)
        {
            UltimoNumeroDeOrden++;
            Orden OrdenCreada = new Orden(UltimoNumeroDeOrden, cliente, tecnico, tipoDeServicio, descripcionProblema, fechaCreacion, estado, listacomentarios);
            ListaOrdenes.Add(OrdenCreada);
            return OrdenCreada;
        }

        public static Orden BuscadorDeOrden(int nroOrden)
        {

            foreach (Orden orden in ListaOrdenes)
            {
                if (orden.NroOrden == nroOrden)
                {
                    return orden;
                }
            }

            return null;
        }
    }
}