using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class Nacion
    {
        public String Nombre;
        public Departamento[] Departamentos;
        public Nacion(String nombre, Departamento[] departamentos)
        {
            this.Nombre = nombre;
            this.Departamentos = departamentos;
        }

        public int MostrarDepartamentos()
        {
            Console.Clear();
            Utilidades.enmarcar("Departamentos");
            Console.WriteLine("Seleccione un departamento: ");
            for (int i = 0; i < Departamentos.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + Departamentos[i].Nombre);
            }
            string opcion = Console.ReadLine();
            if (!Validaciones.esEntero(opcion))
                return MostrarDepartamentos();
            else
            {
                int o = int.Parse(opcion);
                if (o <= 0 || o >= 23)
                    return MostrarDepartamentos();
                else
                    return o;
            }
        }
    }
}
