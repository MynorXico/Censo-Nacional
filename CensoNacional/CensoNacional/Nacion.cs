using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    class Nacion
    {
        public String Nombre;
        public Departamento[] Departamentos;

        public Nacion(String nombre, Departamento[] departamentos)
        {
            this.Nombre = nombre;
            this.Departamentos = departamentos;
        }
    }
}
