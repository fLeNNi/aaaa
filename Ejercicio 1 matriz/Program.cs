class Program
{
    public static void Main(string[] args)
    {
        int prod = 0, dias = 0, ventas = 0;
        int productos = 4, diaDeLaSemana = 7;
        string[] diasDeLaSemana = new string[] { "Lun", "Mar", "Mier", "juev", "Vier", "Sab", "Dom" };
        string[] productosSemanales = new string[] { "prod1", "prod2", "prod3", "prod4" };
        int[,] ventasPorSemana = new int[productos, diaDeLaSemana];

        bool bandera = true;
        int opciones = 0;


        while (bandera)
        {

            Console.WriteLine("Opciones:\n" +
                              "1-CargarVentas\n" +
                              "2-Mostras ventas\n" +
                              "3-Ventas totales por producto\n" +
                              "4-Ventas totales por dia\n" +
                              "5-Salir\n");

            opciones = int.Parse(Console.ReadLine());

            switch (opciones)
            {
                case 1:

                    while (bandera)
                    {
                        Console.WriteLine("ingrese dia de la semana 1-7 o '0' para salir");
                        dias = int.Parse(Console.ReadLine());
                        if (dias == 0)
                        {
                            break;
                        }
                        Console.WriteLine("ingrese numero de producto 1-4");
                        prod = int.Parse(Console.ReadLine());
                        Console.WriteLine("ingrese ventas totales");
                        ventas = int.Parse(Console.ReadLine());

                        ventasPorSemana[prod - 1, dias - 1] += ventas;
                    }
                    break;

                case 2:

                    Console.Clear();
                    mostrarVentas(diasDeLaSemana, productosSemanales, ventasPorSemana);
                    break;

                case 3:

                    Console.Clear();
                    ventasTotalesXproducto(diasDeLaSemana, productosSemanales, ventasPorSemana);
                    break;

                case 4:

                    Console.Clear();
                    ventasTotalesXsemana(diasDeLaSemana, productosSemanales, ventasPorSemana);
                    break;

                case 5:

                    bandera = false;
                    break;

                default:
                    Console.WriteLine("opcion incorrecta");
                    break;

            }

        }
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }
    static void mostrarVentas(string[] semana, string[] producto, int[,] ventas)
    {

        for (int i = 0; i < ventas.GetLength(1); i++)
        {
            Console.Write("\t{0} ", semana[i]);
        }
        Console.WriteLine(" ");
        for (int i = 0; i < ventas.GetLength(0); i++)
        {
            Console.Write("{0}\t", producto[i]);

            for (int a = 0; a < ventas.GetLength(1); a++)
            {
                Console.Write("{0}\t", ventas[i, a]);
            }
            Console.WriteLine("  ");
        }
    }
    static void ventasTotalesXproducto(string[] semanaTp, string[] productoT, int[,] ventas)
    {
        int acumProducto = 0;
        for (int i = 0; i < ventas.GetLength(1); i++)
        {
            Console.Write("\t{0} ", semanaTp[i]);
        }
        Console.WriteLine(" ");

        for (int i = 0; i < ventas.GetLength(0); i++)
        {
            Console.Write("{0}\t", productoT[i]);

            for (int a = 0; a < ventas.GetLength(1); a++)
            {
                Console.Write("{0}\t", ventas[i, a]);
                acumProducto += ventas[i, a];
            }
            Console.Write("{0}\t", acumProducto);
            Console.WriteLine("  ");
            acumProducto = 0;
        }
    }
    static void ventasTotalesXsemana(string[] semanaTs, string[] productoTs, int[,] ventas)
    {
        int acumSemanal = 0;
        for (int i = 0; i < ventas.GetLength(1); i++)
        {
            Console.Write("\t{0} ", semanaTs[i]);
        }
        Console.WriteLine(" ");
        for (int i = 0; i < ventas.GetLength(0); i++)
        {
            Console.Write("{0}\t", productoTs[i]);

            for (int a = 0; a < ventas.GetLength(1); a++)
            {
                Console.Write("{0}\t", ventas[i, a]);
            }
            Console.WriteLine("  ");
        }

        for (int i = 0; i < ventas.GetLength(1); i++)
        {

            for (int a = 0; a < ventas.GetLength(0); a++)
            {
                acumSemanal += ventas[a, i];
            }
            Console.Write("\t{0}", acumSemanal);
            acumSemanal = 0;
        }
        Console.WriteLine(" ");
    }

}