using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class Usuario
    {
        public string Username;
        public string Nombre;
        public string Apellido;
        public string Contraseña;
        public bool PermisoIngresar;
        public bool PermisoReportes;
        public bool PermisoModificarUsuarios;
        public bool UsuarioBloqueado;

        public Usuario(string username, string nombre, string apellido, string contraseña, bool permisoIngreso, bool permisoReportes, bool permisoModificar, bool usuarioBloqueado)
        {
            this.Username = username;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Contraseña = contraseña;
            this.PermisoIngresar = permisoIngreso;
            this.PermisoReportes = permisoReportes;
            this.PermisoModificarUsuarios = permisoModificar;
            this.UsuarioBloqueado = usuarioBloqueado;
        }
        public Usuario()
        {

        }
    }
}
