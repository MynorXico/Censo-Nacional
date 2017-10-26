using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class Departamento
    {
        public string Nombre;
        public int[] RangoEdadesMasculino;
        public int[] RangoEdadesFemenino;

        public Departamento(string nombre)
        {
            this.Nombre = nombre;
            RangoEdadesFemenino = new int[10];
            RangoEdadesMasculino = new int[10];
        }
    }
}
