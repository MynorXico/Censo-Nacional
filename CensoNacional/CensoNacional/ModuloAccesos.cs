using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class ModuloAccesos
    {
        public static void AgregarUsuario(List<Usuario> Usuarios)
        {
            if (Usuarios.Count >= 6)
            {
                Console.WriteLine("Se ha alcanzado el tamaño máximo de usuarios.");
                return;
            }
            else
            {
                string username = PedirNuevoNombreUsuario();
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del nuevo usuario");
                string nombre = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Ingrese el apellido del nuevo usuario");
                string apellido = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Ingrese la contraseña del nuevo usuario");
                string contraseña = Console.ReadLine();
                bool ingreso = PedirAprobacion("¿El usuario podrá ingresar valores?");
                bool reportes = PedirAprobacion("¿El usuario podrá ver reportes?");
                bool modificar = PedirAprobacion("¿El usuario podrá modificar otros usuarios?");
                bool bloqueado = false;
                AgregarUsuario(username, nombre, apellido, contraseña, ingreso, reportes, modificar, bloqueado, Usuarios);                
            }
        }

        public static void AgregarUsuario(string username, string nombre, string apellido, string contraseña, bool ingreso, bool reportes, bool modificar, bool bloqueado, List<Usuario> Usuarios)
        {
            Usuario nuevoUsuario = new Usuario(username, nombre, apellido, contraseña, ingreso, reportes, modificar, bloqueado);
            Usuarios.Add(nuevoUsuario);
        }

        public static bool IngresoValido(string usuario, string contraseña)
        {
            for(int i = 0; i < Utilidades.Usuarios.Count; i++)
            {
                if (usuario == Utilidades.Usuarios[i].Username && contraseña == Utilidades.Usuarios[i].Contraseña)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ExisteUsuario(string usuario)
        {
            for (int i = 0; i < Utilidades.Usuarios.Count; i++)
            {
                if (usuario == Utilidades.Usuarios[i].Username)
                {
                    return true;
                }
            }
            return false;
        }
        public static Usuario BuscarUsuario(string usuario)
        {
            for (int i = 0; i < Utilidades.Usuarios.Count; i++)
            {
                if (usuario == Utilidades.Usuarios[i].Username)
                {
                    return Utilidades.Usuarios[i];
                }
            }
            return new Usuario();
        }

        public static string PedirNuevoNombreUsuario()
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Creación de nuevo usuario"));
            Console.WriteLine("Ingrese el nombre del nuevo usuario");           
            string opcion = Console.ReadLine();
            if (ExisteUsuario(opcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ya existe un usuario con ese nombre de usuario");
                Console.ResetColor();
                Console.ReadKey();
                return PedirNuevoNombreUsuario();
            }
            return opcion; 
        }

        public static bool PedirAprobacion(string m) {
            Console.Clear();
            Console.WriteLine(m);
            Console.WriteLine(" 1. Si");
            Console.WriteLine(" 2. No");
            string opcion = Console.ReadLine();
            if(opcion == "1" || opcion == "2")
            {
                return opcion == "1";
            }
            return PedirAprobacion(m);

        }
    }
}
