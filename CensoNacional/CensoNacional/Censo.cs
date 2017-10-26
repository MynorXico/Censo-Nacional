using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class Censo
    {
        
        public ModuloAccesos ma = new ModuloAccesos();
        public ModuloIngresoDatos mid = new ModuloIngresoDatos();
        public ModuloReportes mr = new ModuloReportes();
        private static Departamento[] deptosGuatemala = {
            new Departamento("Peten"),
            new Departamento("Huehuetenango"),
            new Departamento("Quiché"),
            new Departamento("Alta Verapaz"),
            new Departamento("Izabal"),
            new Departamento("San Marcos"),
            new Departamento("Quetzaltenango"),
            new Departamento("Totonicapán"),
            new Departamento("Sololá"),
            new Departamento("Chimaltenango"),
            new Departamento("Sacatepéquez"),
            new Departamento("Guatemala"),
            new Departamento("Baja Verapaz"),
            new Departamento("El Progreso"),
            new Departamento("Jalapa"),
            new Departamento("Zacapa"),
            new Departamento("Chiquimula"),
            new Departamento("Retalhuleu"),
            new Departamento("Suchitepéquez"),
            new Departamento("Escuintla"),
            new Departamento("Santa Rosa"),
            new Departamento("Jutiapa"),
        };
        Nacion Guatemala = new Nacion("Guatemala", deptosGuatemala);
        public Censo()
        {
            Usuario admin = new Usuario("admin", "Ronald", "Méndez", "password", true, true, true, false);
            Utilidades.Usuarios.Add(admin);
        }


        public bool LogIn()
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Log In"));
            Console.WriteLine("Ingrese su usuario: ");
            string username = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña: ");
            string contraseña = Console.ReadLine();
            bool acceso = ModuloAccesos.IngresoValido(username, contraseña);
            if (acceso)
            {
                if (!ModuloAccesos.BuscarUsuario(username).UsuarioBloqueado)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ingreso exitoso");
                    Utilidades.UsuarioActual = ModuloAccesos.BuscarUsuario(username);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Usuario Bloqueado");
                }                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ingreso infructuoso");
            }
            Console.ResetColor();
            Console.ReadKey();
            return acceso;
        }
        public void IngresarDatos()
        {
            ModuloIngresoDatos.IngresarDatos(Guatemala);
        }
        public void ObtenerReportes()
        {
            ModuloReportes.ObtenerReportes(Guatemala);
        }
        public void AgregarUsuarios()
        {
            ModuloAccesos.AgregarUsuario(Utilidades.Usuarios);
        }
    }
}
