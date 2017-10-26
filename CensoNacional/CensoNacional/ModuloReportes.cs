using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class ModuloReportes
    {

        // Por Departamento
        public static int TotalHabitantesPorDepartamento(int Departamento, Nacion pais)
        {
            Departamento d = pais.Departamentos[Departamento];
            int suma = 0;
            for(int i = 0; i < d.RangoEdadesMasculino.Length; i++)
            {
                suma += d.RangoEdadesMasculino[i];
            }
            for(int i = 0; i < d.RangoEdadesFemenino.Length; i++)
            {
                suma += d.RangoEdadesFemenino[i];
            }
            return suma;
        }
        public static int TotalHabitantesFemeninosPorDepartamento(int Departamento, Nacion pais)
        {
            int suma = 0;
            for(int i = 0; i < pais.Departamentos[Departamento].RangoEdadesFemenino.Length; i++)
            {
                suma += pais.Departamentos[Departamento].RangoEdadesFemenino[i];
            }
            return suma;
        }
        public static int TotalHabitantesMasculinosPorDepartamento(int Departamento, Nacion pais)
        {
            int suma = 0;
            for (int i = 0; i < pais.Departamentos[Departamento].RangoEdadesMasculino.Length; i++)
            {
                suma += pais.Departamentos[Departamento].RangoEdadesMasculino[i];
            }
            return suma;
        }
        public static int[] TotalHabitantesPorRangosDeEdadPorDepartamento(int Departamento, Nacion pais)
        {
            int[] salida = new int[pais.Departamentos[Departamento].RangoEdadesMasculino.Length];
            for(int i = 0; i < salida.Length; i++)
            {
                salida[i] += pais.Departamentos[Departamento].RangoEdadesMasculino[i];
                salida[i] += pais.Departamentos[Departamento].RangoEdadesFemenino[i];
            }
            return salida;
        }

        // Por País
        public static int TotalHabitantes(Nacion pais)
        {
            int suma = 0;
            for (int i = 0; i < pais.Departamentos.Length; i++)
            {
                // Hombres en cada departamento
                for (int j = 0; j < pais.Departamentos[i].RangoEdadesMasculino.Length; i++)
                {
                    suma += pais.Departamentos[i].RangoEdadesMasculino[j];
                }
                // Mujeres en cada departamento
                for (int j = 0; j < pais.Departamentos[i].RangoEdadesFemenino.Length; i++)
                {
                    suma += pais.Departamentos[i].RangoEdadesFemenino[j];
                }
            }
            return suma;
        }
        public static int TotalHabitantesFemeninos(Nacion pais)
        {
            int suma = 0;
            for(int i = 0; i < pais.Departamentos.Length; i++)
            {
                suma += TotalHabitantesFemeninosPorDepartamento(i, pais);
            }
            return suma;
        }
        public static int TotalHabitantesMasculinos(Nacion pais)
        {
            int suma = 0;
            for (int i = 0; i < pais.Departamentos.Length; i++)
            {
                suma += TotalHabitantesMasculinosPorDepartamento(i, pais);
            }
            return suma;
        }
        public static int[] TotalHabitantesPorRangosDeEdad(Nacion pais)
        {
            int[] salida = new int[pais.Departamentos[0].RangoEdadesFemenino.Length];

            for(int i = 0; i < salida.Length; i++)
            {
                for(int j = 0; j < pais.Departamentos.Length; j++)
                {
                    salida[i] += pais.Departamentos[j].RangoEdadesFemenino[i];
                    salida[i] += pais.Departamentos[j].RangoEdadesMasculino[i];
                }
            }
            return salida;
        }

        public static int DepartamentoOPais()
        {
            Console.Clear();
            Utilidades.enmarcar("Tipo de Búsqueda");
            Console.WriteLine(" 1. Por departamento");
            Console.WriteLine(" 2. Por País");
            string strOpcion = Console.ReadLine();
            if(strOpcion == "1" || strOpcion == "2")
            {
                return int.Parse(strOpcion);
            }
            return DepartamentoOPais();
        }

        public static int QueTotal()
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("¿Qué desea obtener?"));
            Console.WriteLine(" 1. Total de habitantes");
            Console.WriteLine(" 2. Total de habitantes femeninos");
            Console.WriteLine(" 3. Total de habitantes masculinos");
            Console.WriteLine(" 4. Total de habitantes por rangos de edad");
            string strOpcion = Console.ReadLine();
            if (strOpcion == "1" || strOpcion == "2" || strOpcion == "3" || strOpcion == "4")
            {
                return int.Parse(strOpcion);
            }
            return QueTotal();
        }

        public static void ObtenerReportes(Nacion pais)
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Reportes"));
            int tipoBusqueda = DepartamentoOPais();
            if(tipoBusqueda == 1)
            {
                int depto = pais.MostrarDepartamentos()-1;
                int quetotal = QueTotal();
                switch (quetotal)
                {
                    case 1:
                        Console.WriteLine("El total de habitantes en este departamento es de: "+TotalHabitantesPorDepartamento(depto, pais));
                        break;
                    case 2:
                        Console.WriteLine("El total de habitantes femeninos en el departamento es de: " + TotalHabitantesFemeninosPorDepartamento(depto, pais));
                        break;
                    case 3:
                        Console.WriteLine("El total de habitantes masculinos en el departamento es de: " + TotalHabitantesMasculinosPorDepartamento(depto, pais));
                        break;
                    case 4:
                        ImprimirIntervalos(TotalHabitantesPorRangosDeEdadPorDepartamento(depto,pais));
                        break;
                }
            }
            else
            {
                int quetotal = QueTotal();
                switch (quetotal)
                {
                    case 1:
                        Console.WriteLine("El total de habitantes en el país es de: " + TotalHabitantes(pais));
                        break;
                    case 2:
                        Console.WriteLine("El total de habitantes femeninos en el país es de: " + TotalHabitantesFemeninos(pais));
                        break;
                    case 3:
                        Console.WriteLine("El total de habitantes masculinos en el país es de: " + TotalHabitantesMasculinos(pais));
                        break;
                    case 4:
                        ImprimirIntervalos(TotalHabitantesPorRangosDeEdad(pais));
                        break;
                }
            }

        }
        public static void ImprimirIntervalos(int[] intervalos)
        {
            Console.WriteLine(Utilidades.enmarcar("Resultados de Búsqueda"));
            Console.WriteLine("Los resultados obtenidos son los siguientes: ");
            Console.WriteLine("0 a 10 años: " + intervalos[0]);
            Console.WriteLine("11 a 20 años: " + intervalos[1]);
            Console.WriteLine("21 a 30 años: " + intervalos[2]);
            Console.WriteLine("31 a 40 años: " + intervalos[3]);
            Console.WriteLine("41 a 50 años: " + intervalos[4]);
            Console.WriteLine("51 a 60 años: " + intervalos[5]);
            Console.WriteLine("61 a 70 años: " + intervalos[6]);
            Console.WriteLine("71 a 80 años: " + intervalos[7]);
            Console.WriteLine("81 a 90 años: " + intervalos[8]);
            Console.WriteLine("91 a 100 años: " + intervalos[9]);
        }



    }
}
