using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    public class ModuloIngresoDatos
    {
        // sexo = true => masculino, false => femenino
        public static void IngresoPorRangosDeEdad(bool sexo, int Departamento, Nacion pais)
        {
            Console.Write("Ingreso de Datos por Rango de Edad con ");
            if (sexo) // Masculino
            {
                Console.WriteLine("Sexo Masculino");
            }
            else
            {
                Console.WriteLine("Sexo Femenino");
            }
            int[] arregloTemporal = new int[10];
            for (int i = 0; i < arregloTemporal.Length; i++)
            {
                bool numValido = false;
                string strEntrada;
                int entrada = -1;
                do
                {
                    if (!sexo) // Femenino 
                        if (i == 0)
                            Console.WriteLine("Ingrese la cantiad de habitantes de 0 a 10 años");
                        else
                        {
                            Console.WriteLine("Ingrese la cantidad de habitantes de " + (10 * i + 1) + " a " + (i + 1) * 10 + "años");
                        }
                    else // Masculino
                    {
                        if (i == 0)
                            Console.WriteLine("Ingrese la cantidad de habitantes de 0 a 5 años");
                        else if (i >= 1 && i <= 3)
                            Console.WriteLine("Ingrese la cantidad de habitantes de " + (10 * i - 4) + " a " + 10 * i + 5);
                        else if (i == 4)
                        {
                            Console.WriteLine("Ingrese la cantidad de habitantes de 36 a 40 años");
                        }
                        else if (i == 5)
                            Console.WriteLine("Ingrese la cantidad de habitantes de 41 a 63 años");
                        else if (i == 6)
                            Console.WriteLine("Ingrese la cantidad de habitantes de 64 a 70 años");
                        else if (i == 7)
                            Console.WriteLine("Ingrese la cantidad de habitantes de 71 a 75 años");
                        else if (i == 8)
                            Console.WriteLine("Ingrese la cantidad de habitantes de 76 a 80 años");
                        else if (i == 9)
                            Console.WriteLine("Ingrese la cantidad de habitantes de 81 a 100 años");
                    }

                    Console.ResetColor();
                    strEntrada = Console.ReadLine();
                    if (Validaciones.esEntero(strEntrada))
                    {
                        entrada = int.Parse(strEntrada);
                        if (entrada >= 0)
                        {
                            numValido = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                } while (!numValido);
                arregloTemporal[i] = entrada;
            }
            if (sexo)
            {
                pais.Departamentos[Departamento].RangoEdadesMasculino = arregloTemporal;
            }
            else
            {
                pais.Departamentos[Departamento].RangoEdadesFemenino = arregloTemporal;
            }
        }
        public static void IngresoDatos(int Departamento, bool sexo, int edad, Nacion pais, int poblacionAdicional)
        {
            if (sexo)
            {
                pais.Departamentos[Departamento].RangoEdadesMasculino[Utilidades.getRangoMasculino(edad)]  += poblacionAdicional;
            }
            else
            {
                pais.Departamentos[Departamento].RangoEdadesFemenino[Utilidades.getRangoFemenino(edad)] += poblacionAdicional;
            }
        }

        public static void IngresarDatos(Nacion pais)
        {
            int numeroPais = pais.MostrarDepartamentos()-1;
            int metodo = MenuIngresoDatos();
            if(metodo == 1)
            {
                try
                {
                    IngresoPorRangosDeEdad(true, numeroPais, pais);
                    IngresoPorRangosDeEdad(false, numeroPais, pais);
                }
                catch
                {
                    Console.WriteLine("Cometió un error al ingresar los datos. Recuerde que deben ser cantidades numéricas.");
                }
            }
            else
            {
                bool masculino = MenuIngresoSexo() == 1;
                int edad = IngresarPositivo("Ingrese la edad: ");
                int poblacion = IngresarPositivo("Ingrese la población: ");
                IngresoDatos(numeroPais, masculino, edad, pais, poblacion);
            }
        }

        public static int MenuIngresoDatos()
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Opciones"));
            Console.WriteLine("¿Cómo desea ingresar los datos?");
            Console.WriteLine(" 1. Rango de edad");
            Console.WriteLine(" 2. Ingreso de datos");
            string strOpcion = Console.ReadLine();
            if (strOpcion != "1" && strOpcion != "2")
                return MenuIngresoDatos();
            return int.Parse(strOpcion);
        }
        public static int MenuIngresoSexo()
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Sexo"));
            Console.WriteLine("Seleccione el sexo de los datos a ingresar: ");
            Console.WriteLine(" 1. Masculino");
            Console.WriteLine(" 2. Femenino");
            string strOpcion = Console.ReadLine();
            if (strOpcion != "1" && strOpcion != "2")
                return MenuIngresoDatos();
            return int.Parse(strOpcion);
        }
        public static int IngresarPositivo(string m)
        {
            Console.Clear();
            Console.WriteLine(Utilidades.enmarcar("Edad"));
            Console.WriteLine(m);
            string edad = Console.ReadLine();
            if (!Validaciones.esEntero(edad))
            {
                return IngresarPositivo(m);
            }
            if(int.Parse(edad) >= 0)
            {
                return int.Parse(edad);
            }
            return IngresarPositivo(m);
        }
    }
}
