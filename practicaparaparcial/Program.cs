int qAlumnos = 6, opcion = 0;
double[,] registroDeAlumnos = new double[qAlumnos, 9];
string[] materias = new string[] { "Matematica", "Lengua", "Historia", "Geografia", "Ingles", "Fisica", "Quimica", "Politica" };
string menu = "Ingrese 1 para cargar alumnos\nIngrese 2 para Informar la cantidad de afiliados en un centro por dia\nIngrese 3 para informar la cantidad de socios atendidos en un dia\nIngrese 4 para informar la cantidad total de socios atendidos en un centro determinado\nIngrese 0 para salir";

do
{
    Console.WriteLine(menu);
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            cargaDeAlumnos(ref registroDeAlumnos);
            break;
        case 2:
            notasXMateria(ref registroDeAlumnos, materias, qAlumnos);
            break;
        case 3:
            notasXAlumno(ref registroDeAlumnos, materias, qAlumnos);
            break;
        case 4:
            notasXAluXMat(ref registroDeAlumnos, materias, qAlumnos);
            break;
        case 5:
            CantidadMateriasExaminadas(ref registroDeAlumnos);
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

static void cargaDeAlumnos(ref double[,] rDeAlumnos)
{
    int alumno = 0, materia = 0, nota = 0;
    Console.WriteLine("Digite el numero de alumno");
    alumno = int.Parse(Console.ReadLine());

    while (alumno < 100 && alumno != 0)
    {
        Console.WriteLine("Digite el codigo de materia");
        materia = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite la nota");
        nota = int.Parse(Console.ReadLine());

        rDeAlumnos[alumno - 1, materia - 1] = nota;
        //rDeAlumnos[alumno - 1, 8] = rDeAlumnos[alumno - 1, 8] + nota;

        Console.WriteLine("Digite el numero de alumno");
        alumno = int.Parse(Console.ReadLine());
    }
}

static void notasXMateria(ref double[,] rDeAlumnos, string[] materias, int qAlumnos)
{
    int materia = 0;

    Console.WriteLine("Ingrese el codigo de la materia");
    materia = int.Parse(Console.ReadLine());

    Console.WriteLine($"{materias[materia - 1]}");

    for(int i = 0; i < qAlumnos; i++)
    {
        if (rDeAlumnos[i, materia - 1] != 0)
        {
            Console.WriteLine($"Alumno {i + 1} nota {rDeAlumnos[i, materia - 1]}");
        }
    }
}

static void notasXAlumno(ref double[,] rDeAlumnos, string[] materias, int qAlumnos)
{
    int alumno = 0;

    Console.WriteLine("Ingrese el codigo del alumno");
    alumno = int.Parse(Console.ReadLine());

    for(int i = 0; i < materias.Length; i++)
    {
        if(rDeAlumnos[alumno - 1,i] != 0)
        {
            Console.WriteLine($"Alumno {i} : {materias[i]} {rDeAlumnos[alumno - 1,i]} ");
        }
    }
}

static void notasXAluXMat(ref double[,] rDeAlumnos, string[] materias, int qAlumnos)
{
    int materia = 0, alumno = 0;

    Console.WriteLine("Ingrese el numero de alumno");
    alumno = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el codigo de materia");
    materia = int.Parse(Console.ReadLine());

    
    if(rDeAlumnos[alumno - 1, materia - 1] != 0)
    {
        Console.WriteLine($"El alumno {alumno} rindio {materias[materia]} con {rDeAlumnos[alumno - 1,materia - 1]}");
    }
    else if(rDeAlumnos[alumno - 1, materia - 1] == 0)
    {
        Console.WriteLine("El alumno no rindio la materia");
    }

}

static void CantidadMateriasExaminadas(ref double[,] rDeAlumnos)
{
    // Recorremos cada fila de la matriz

    for (int i = 0; i < rDeAlumnos.GetLength(0); i++)
    {
        // Inicializamos la variable que llevará la cuenta de las materias examinadas
        int materiasExaminadas = 0;

        // Recorremos cada columna de la fila actual
        for (int j = 0; j < rDeAlumnos.GetLength(1); j++)
        {
            // Si el valor en la posición actual es distinto de cero, significa que el alumno ha examinado esa materia
            if (rDeAlumnos[i, j] != 0)
            {
                // Incrementamos el contador de materias examinadas
                materiasExaminadas++;
            }
        }

        // Imprimimos el número del alumno y la cantidad de materias examinadas
        Console.WriteLine("Alumno {0}: {1} materias examinadas", i + 1, materiasExaminadas);
    }
}