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
        public static List<Orden> OrdenesxTecnico = new List<Orden>();
        public static List<Orden> ListaMes = new List<Orden>();

        public static Tecnico Token;
        public static int UltimoNumeroDeOrden;


        public static void PrecargarBD()
        {


            UltimoNumeroDeOrden = 0;
            Cliente Cli1 = new Cliente("Jose", "Perez", "50237326", "Sarandi 234", "097342631", "jperez@gmail.com");
            Cliente Cli2 = new Cliente("Pepe", "Silva", "44094112", "Gorlero 890", "094621001", "elpepe777@gmail.com");
            Cliente Cli3 = new Cliente("Ricardo", "Gonzalez", "51017628", "25 de Mayo 1001", "098150787", "RicarditoDDL@gmail.com");
            Cliente Cli4 = new Cliente("Ana", "Lopez", "43128766", "18 de Julio 234", "092345678", "analopez@gmail.com");
            Cliente Cli5 = new Cliente("Marta", "Sanchez", "48237612", "Colonia 1234", "094567890", "msanchez@gmail.com");
            Cliente Cli6 = new Cliente("Luis", "Ramirez", "50287654", "Ellauri 345", "099112233", "lramirez@gmail.com");
            Cliente Cli7 = new Cliente("Sofia", "Martinez", "45017629", "Bulevar Artigas 210", "093445566", "smartinez@gmail.com");
            Cliente Cli8 = new Cliente("Federico", "Alvarez", "44198761", "Mercedes 890", "091667788", "falvarez@gmail.com");
            Cliente Cli9 = new Cliente("Laura", "Gomez", "46023456", "Canelones 567", "098899001", "lgomez@gmail.com");
            Cliente Cli10 = new Cliente("Carlos", "Diaz", "45561029", "Durazno 123", "092345676", "cdiaz@gmail.com");

            ListaClientes.Add(Cli1);
            ListaClientes.Add(Cli2);
            ListaClientes.Add(Cli3);
            ListaClientes.Add(Cli4);
            ListaClientes.Add(Cli5);
            ListaClientes.Add(Cli6);
            ListaClientes.Add(Cli7);
            ListaClientes.Add(Cli8);
            ListaClientes.Add(Cli9);
            ListaClientes.Add(Cli10);

            Tecnico Tec1 = new Tecnico("Juan", "Manuel", "34653871", "Reparacion", "1234");
            Tecnico Tec2 = new Tecnico("Gabriel", "Medina", "48769321", "Montaje", "5678");
            Tecnico Tec3 = new Tecnico("Lucia", "Fernandez", "39827165", "Instalación", "9876");
            Tecnico Tec4 = new Tecnico("Carlos", "Lopez", "40293847", "Diagnóstico", "4321");
            Tecnico admin = new Tecnico("Admin", "Medina", "50140797", "ToLosPoderes", "1111", true);
            Tecnico Tec6 = new Tecnico("Emilia", "Garcia", "48273910", "Soporte Técnico", "6543");
            Tecnico Tec7 = new Tecnico("Miguel", "Suarez", "47983921", "Mantenimiento", "8901");
            Tecnico Tec8 = new Tecnico("Paula", "Sosa", "45983210", "Programación", "2345");
            Tecnico Tec9 = new Tecnico("Andrés", "Rivas", "46128794", "Capacitación", "6789");
            Tecnico Tec10 = new Tecnico("Roberto", "Martinez", "48019273", "Redes", "1010");


            ListaTecnico.Add(Tec1);
            ListaTecnico.Add(Tec2);
            ListaTecnico.Add(Tec3);
            ListaTecnico.Add(Tec4);
            ListaTecnico.Add(admin);
            ListaTecnico.Add(Tec6);
            ListaTecnico.Add(Tec7);
            ListaTecnico.Add(Tec8);
            ListaTecnico.Add(Tec9);
            ListaTecnico.Add(Tec10);


            string nota1 = "El cliente reportó fallas intermitentes.";
            string nota2 = "Se necesita cambio de hardware.";
            string nota3 = "Instalación completada con éxito.";
            string nota4 = "El cliente solicitó revisión de garantías.";
            string nota5 = "Actualizar el sistema operativo.";
            string nota6 = "Falta cableado en red interna.";
            string nota7 = "Problema de seguridad en la red.";
            string nota8 = "Configuración del servidor.";
            string nota9 = "Revisión de equipos de la oficina.";
            string nota10 = "Problemas con software de gestión.";


            List<string> list1 = new List<string> { nota1, nota2 };
            List<string> list2 = new List<string> { nota3 };
            List<string> list3 = new List<string> { nota4, nota5 };
            List<string> list4 = new List<string> { nota6 };
            List<string> list5 = new List<string> { nota7, nota8 };
            List<string> list6 = new List<string> { nota9, nota10 };


            BaseDeDatos.crearOrden(Cli1.Nombre, Tec1.Nombre, "Sistemas", "Reparación de software", DateTime.Now.Date, "EN PROGRESO", list1);
            BaseDeDatos.crearOrden(Cli2.Nombre, Tec2.Nombre, "Montaje", "Configuración inicial de equipo", DateTime.Now.Date, "COMPLETADO", list2);
            BaseDeDatos.crearOrden(Cli3.Nombre, Tec3.Nombre, "Instalación", "Instalación de nueva red", DateTime.Now.Date, "PENDIENTE", list3);
            BaseDeDatos.crearOrden(Cli4.Nombre, Tec4.Nombre, "Diagnóstico", "Problemas de conectividad", DateTime.Now.Date, "EN PROGRESO", list4);
            BaseDeDatos.crearOrden(Cli5.Nombre, Tec1.Nombre, "Actualización", "Actualizar sistema operativo a última versión", DateTime.Now.Date, "PENDIENTE", new List<string>());
            BaseDeDatos.crearOrden(Cli6.Nombre, admin.Nombre, "Redes", "Instalación de cableado estructurado", DateTime.Now.Date, "COMPLETADO", list5);
            BaseDeDatos.crearOrden(Cli7.Nombre, Tec6.Nombre, "Soporte Técnico", "Resolución de problemas con el correo", DateTime.Now.Date, "EN PROGRESO", list6);
            BaseDeDatos.crearOrden(Cli8.Nombre, Tec7.Nombre, "Mantenimiento", "Revisión de hardware", DateTime.Now.Date, "COMPLETADO", list1);
            BaseDeDatos.crearOrden(Cli9.Nombre, Tec8.Nombre, "Programación", "Desarrollo de módulo adicional", DateTime.Now.Date, "PENDIENTE", list2);
            BaseDeDatos.crearOrden(Cli10.Nombre, Tec9.Nombre, "Capacitación", "Entrenamiento sobre nuevo software", DateTime.Now.Date, "EN PROGRESO", list3);
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