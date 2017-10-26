using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    class Utilidades
    {
        public static int getRangoFemenino(int edad)
        {
            if (edad >= 0 && edad <= 10)
                return 0;
            else if (edad >= 11 && edad <= 20)
                return 1;
            else if (edad >= 21 && edad <= 30)
                return 2;
            else if (edad >= 31 && edad <= 40)
                return 3;
            else if (edad >= 41 && edad <= 50)
                return 4;
            else if (edad >= 51 && edad <= 60)
                return 5;
            else if (edad >= 61 && edad <= 70)
                return 6;
            else if (edad >= 71 && edad <= 80)
                return 7;
            else if (edad >= 81 && edad <= 90)
                return 8;
            else if (edad >= 91 && edad <= 100)
                return 9;
            return -1;
        }
        public static int getRangoMasculino(int edad)
        {
            if (edad >= 0 && edad <= 5)
                return 0;
            else if (edad >= 6 && edad <= 15)
                return 1;
            else if (edad >= 16 && edad <= 25)
                return 2;
            else if (edad >= 26 && edad <= 35)
                return 3;
            else if (edad >= 36 && edad <= 40)
                return 4;
            else if (edad >= 41 && edad <= 63)
                return 5;
            else if (edad >= 64 && edad <= 70)
                return 6;
            else if (edad >= 71 && edad <= 75)
                return 7;
            else if (edad >= 76 && edad <= 80)
                return 8;
            else if (edad >= 81 && edad <= 100)
                return 9;
            return -1;
        }
        public static List<Usuario> Usuarios = new List<Usuario>();
        public static Usuario UsuarioActual;
        public static string enmarcar(string s)
        {
            int longitud = s.Length;
            string salida = "";
            for (int i = 0; i <= longitud + 1; i++)
            {
                salida += "═";
            }
            salida += "\n";
            salida += " " + s + "\n";
            for (int i = 0; i <= longitud + 1; i++)
            {
                salida += "═";
            }
            return salida;
        }
        public static int MostrarModulos()
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Módulos"));
            if (UsuarioActual.PermisoIngresar)
            {
                Console.WriteLine("1. Ingreso de datos");
            }
            if (UsuarioActual.PermisoReportes)
            {
                Console.WriteLine("2. Mostrar reportes");
            }
            if (UsuarioActual.PermisoModificarUsuarios)
            {
                Console.WriteLine("3. Modulo accesos");
            }
            Console.WriteLine("4. Cerrar sesión");

            string opcion = Console.ReadLine();
            if (opcion == "1")
                return 1;
            if (opcion == "2")
                return 2;
            if (opcion == "3")
                return 3;
            if (opcion == "4")
                return 4;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opción no válida");
            Console.ResetColor();
            Console.ReadKey();
            return MostrarModulos();
        }
    }
}
