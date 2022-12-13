double[,] registroDeSocios = new double[7, 5];
int opcion = 0;
string menu = "Ingrese 1 para cargar socios\nIngrese 2 para Informar la cantidad de afiliados en un centro por dia\nIngrese 3 para informar la cantidad de socios atendidos en un dia\nIngrese 4 para informar la cantidad total de socios atendidos en un centro determinado\nIngrese 0 para salir";
string[] diasDeLaSemana = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
int[] centros = new int[] { 1, 2, 3, 4 };
do
{
    Console.WriteLine(menu);
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            cargaDeSocios(ref registroDeSocios);
            break;
        case 2:
            afiliadoXDia(ref registroDeSocios, diasDeLaSemana, centros);
            break;
        case 3:
            sociosXDia(ref registroDeSocios, diasDeLaSemana);
            break;
        case 4:
            sociosXCentros(ref registroDeSocios, centros);
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



static void cargaDeSocios(ref double[,] rDeSocios)
{
    int centro = 0, dia = 0, socios = 0;

    Console.WriteLine("Ingrese el codigo del centro");
    centro = int.Parse(Console.ReadLine());

    while(centro != 0)
    {
        Console.WriteLine("Ingrese el dia");
        dia = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la cantidad de socios");
        socios = int.Parse(Console.ReadLine());

        rDeSocios[dia - 1, centro - 1] = socios;
        rDeSocios[dia - 1, 4] = rDeSocios[dia - 1, 4] + socios;

        Console.WriteLine("Ingrese el código del centro, 0 para salir");
        centro = int.Parse(Console.ReadLine());

    }
}

static void afiliadoXDia(ref double[,] rDeSocios, string[] diasDeLaSemana, int[] centros)
{
    int dia = 0, centro = 0;
    Console.WriteLine("Ingrese el dia");
    dia = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el centro");
    centro = int.Parse(Console.ReadLine());

    Console.WriteLine($"El centro de atencion {centros[centro - 1]} atendio {rDeSocios[dia - 1, 4]} el dia {diasDeLaSemana[dia - 1]} ");
}

static void sociosXDia(ref double[,] rDeSocios, string[] diasDeLaSemana)
{
    int dia = 0;
    Console.WriteLine("Ingrese el dia");
    dia = int.Parse(Console.ReadLine());

    Console.WriteLine($"El dia {diasDeLaSemana[dia - 1]} se atendieron {rDeSocios[dia - 1, 4]} socios ");
}

static void sociosXCentros(ref double[,] rDeSocios, int[] centros)
{
    int centro = 0;
    double total = 0;
    Console.WriteLine("Ingrese el centro");
    centro = int.Parse(Console.ReadLine());
    for (int i = 0; i <= 5; i++)
    {
        total += rDeSocios[i, centro - 1];
    }
    Console.WriteLine($"El centro de atencion {centro} atendio {total} socios ");
}