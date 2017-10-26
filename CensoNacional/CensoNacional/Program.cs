using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoNacional
{
    class Program
    {
        static void Main(string[] args)
        {
            Censo c = new Censo();
            Start:

            #region Flujo 1
            bool ingreso = false;
            do
            {
                ingreso = c.LogIn();
            } while (!ingreso);
            #endregion
            #region Flujo 2
            bool salir = false;
            do
            {
                int numeroModulo = Utilidades.MostrarModulos();
                Console.ReadKey();
                #endregion
                #region Flujo 3
                switch (numeroModulo)
                {
                    case 1:
                        c.IngresarDatos();
                        break;
                    case 2:
                        c.ObtenerReportes();
                        break;
                    case 3:
                        c.AgregarUsuarios();
                        break;
                    case 4:
                        goto Start;
                }
            } while (!salir);
            
            #endregion

        }
    }
}
