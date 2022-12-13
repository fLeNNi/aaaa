int opcion = 0;
string[] dias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
string[] operadores = { "Juan", "Jorge", "Martin", "Pedro", "Paola" };
int qOperadores = 5;
double[,] registro = new double[operadores.Length, 7];
string menu = "Ingrese 1 para cargar operadores\nIngrese 2 para saber los minutos por operador\nIngrese 3 para informar la venta de una sucursal\nIngrese 0 para terminar el programa";
do
{
    Console.WriteLine(menu);
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            cargaDeOperadores(ref registro);
            break;
        case 2:
            minutosPorOperador(ref registro, operadores, qOperadores);
            break;
        case 3:
            llamadaPromedio(ref registro);
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

static void cargaDeOperadores(ref double[,] registro)
{
    int dia = 0, operador = 0;
    double minutos = 0;

    Console.WriteLine("Ingrese el dia");
    dia = int.Parse(Console.ReadLine());

    while(dia != 0)
    {
        Console.WriteLine("Ingrese el codigo del operador");
        operador = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los minutos");
        minutos = double.Parse(Console.ReadLine());

        registro[operador -1, dia - 1] = minutos;

        Console.WriteLine("Ingrese el dia, 0 para salir");
        dia = int.Parse(Console.ReadLine());

    }

}

static void minutosPorOperador(ref double[,] registro, string[] operadores, int qOperadores)
{
    for (int i = 0; i <= qOperadores - 1; i++)
    {
        Console.WriteLine($"El operador {operadores[i]} atendio llamadas por {registro[i, i]} ");
        
    }
    
}

static double llamadaPromedio(ref double[,] registro)
{
    double promedio = 0;
    int contador = 0;

    for (int i = 0; i < registro.GetLength(0); i++)
    {
        for (int j = 0; j < registro.GetLength(1); j++)
        {
            if (registro[i, j] != 0)
            {
                promedio += registro[i, j];
                contador++;
            }
        }
    }

    return promedio / contador;
    Console.WriteLine($"{promedio / contador}");
}
