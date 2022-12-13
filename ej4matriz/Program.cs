using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMatrices_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string[] bimestres = { "primero", "segundo", "tercero", "cuarto", "quinto", "sexto" };
            double[,] registroDeVentas = new double[6, 5];
            string menu = "Ingrese 1 para cargar venta\nIngrese 2 para Informar venta de un bimestre\nIngrese 3 para informar la venta de una sucursal\nIngrese 0 para terminar el programa";

            do
            {
                Console.WriteLine(menu);
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        cargaDeVentas(ref registroDeVentas);
                        break;
                    case 2:
                        ventaXBimestre(ref registroDeVentas, bimestres);
                        break;
                    case 3:
                        ventaXSucursal(ref registroDeVentas);
                        break;
                    case 0:
                        Console.WriteLine("FIN DEL PROGRAMA");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida");
                        break;
                }

            } while (opcion != 0);

        }

        static void cargaDeVentas(ref double[,] rdvtas)
        {

            int sucursal = 0, bimestre = 0;
            double venta = 0;
            Console.WriteLine("Ingrese el código de sucursal <1-4> 0 para salir");
            sucursal = int.Parse(Console.ReadLine());


            while (sucursal != 0)
            {

                Console.WriteLine("Ingrese el Bimestre <1-6>");
                bimestre = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la venta");
                venta = double.Parse(Console.ReadLine());

                rdvtas[bimestre - 1, sucursal - 1] = venta;
                rdvtas[bimestre - 1, 4] = rdvtas[bimestre - 1, 4] + venta;

                Console.WriteLine("Ingrese el código de sucursal <1-4> 0  para salir");
                sucursal = int.Parse(Console.ReadLine());
            }
        }
        static void ventaXBimestre(ref double[,] rdvtas, string[] bimestres)
        {

            int bimestre = 0;
            Console.WriteLine("Ingrese el número de bimestre");
            bimestre = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"La venta del {bimestres[bimestre - 1]} Bimestre es {rdvtas[bimestre - 1, 4]}");

        }

        static void ventaXSucursal(ref double[,] rdvtas)
        {
            int sucursal = 0;
            double total = 0;
            Console.WriteLine("Ingrese el número de sucursal a informar");
            sucursal = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 5; i++)
            {
                total += rdvtas[i, sucursal - 1];
            }
            Console.WriteLine($"La venta total de la sucurusal {sucursal} es de {total} pesos.");
        }
    }
}