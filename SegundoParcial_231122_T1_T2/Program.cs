using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial_231122_T1_TW
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            int qAlu = 5; // la cantidad de alumnos para probar, debería dejarse en 100 luego de chequear el código            
            // arreglo para la carga de materias
            string[] materias = new string[2];
            // matriz para la carga de notas
            // le sumo uno para contemplar la fila adicional y la columna adicional, de esta manera evito "olvidarme hasta donde recorrer" y que haya errores de índice
            int[,] notasAlumnos = new int[qAlu +1 , materias.Length + 1] ; 
            //cargo el arreglo de materias antes que el menú
            cargaMaterias(ref materias);
            int opcion = 0;
            string menu = "1. Cargar matriz T1 y T2\n2. Detalle de notas de una materia T1\n3. Informe de las notas de un alumno T1\n4. Informar la nota de un alumno de una determinada materia T1 y T2\n5. Informar la cantidad de materias examinadas por alumno T1\n\n6. Informar las materias alas que no se presentó un alumno\n7. Detalle de notas de una materia T2\n8. Informar la cantidad de alumnos examinados por materia T2";
            // menú
            do
            {
                Console.WriteLine(menu);
                opcion= int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("FIN DEL PROGRAMA!");
                        break;
                    case 1:
                        cargarNotas(ref notasAlumnos, materias);
                        break;
                    case 2:
                        notasDeUnaMateria(notasAlumnos,materias);
                        break;
                    case 3:
                        notasDeUnAlumno(notasAlumnos, materias);
                        break;
                    case 4:
                        notasDeUnAlumnoDeUnaMateria(notasAlumnos, materias);
                        break;
                    case 5:
                        cantidadDeMateriasExaminadasPorAlumno(notasAlumnos);
                        break;
                    case 6:
                        alumnoNoPresentadoAunaMateria(notasAlumnos, materias);
                        break;
                    case 7:
                        notasDeUnaMateriaT2(notasAlumnos, materias);
                        break;
                    case 8:
                        cantidadDeAlumnosXMateria(notasAlumnos, materias);
                        break ;
                    default:
                        Console.WriteLine("La opción ingresa no es correcta");
                        break;
                }
            } while (opcion != 0);


        }

        static void cargaMaterias(ref string [] auxMaterias)
        {
            for(int i = 0; i < auxMaterias.Length; i++)
            {
                Console.WriteLine($"Ingrese el la descripción de la materia {i+1}");
                auxMaterias[i] = Console.ReadLine();    
            }
        }
    
        static void cargarNotas(ref int[,] auxNotas, string []auxMaterias)
        { 
            int codAlu = 0, codMate = 0, nota=0;
            int qAlu = auxNotas.GetLength(0) - 1;
            Console.WriteLine($"Ingrese el código de alumno 1 a {qAlu} otro valor para terminar");
            codAlu = int.Parse(Console.ReadLine());
            while (codAlu >= 1 && codAlu <= 100)
            {  //se podria validar la materia entre 1y 8 para que pinche por error el progrmama no lo hago porque no se solicita.
                Console.WriteLine($"Ingese el código de materia <<valores entre 1 y {auxMaterias.Length}>>");
                codMate = int.Parse(Console.ReadLine());
                Console.WriteLine($"Ingrese la nota del alumno {codAlu}, para la materia {auxMaterias[codMate - 1]}");
                nota = int.Parse((Console.ReadLine()));
                auxNotas [codAlu-1, codMate-1] = nota; // guardo la nota del alumno
                auxNotas[codAlu - 1, auxMaterias.Length] +=1 ; // contabilizo por columna "Materias examinadas por alumno"
                //para no hardcodear 100 en las filas uso GetLength y le indico la dimension de la cual quiero saber el último número
                //recordar que devuelve el número real de elementos , por eso lo decremento en 1
                auxNotas[auxNotas.GetLength(0)-1, codMate - 1] += 1; // contabilizo por fila la cantidad de alumnos en una misma materia
                Console.WriteLine($"Ingrese el código de alumno 1 a {qAlu}  otro valor para terminar");
                codAlu = int.Parse(Console.ReadLine());
            }

        }
        
        static void notasDeUnaMateria (int[,] auxNotas, string[] auxMaterias)
        {
            int codMate = 0, qAlu = auxNotas.GetLength(0) - 1; 
            Console.WriteLine($"Ingrese el código de materia a consular entre 1 y {auxMaterias.Length}");
            codMate = int.Parse(Console.ReadLine());
            Console.WriteLine($"Materia: {auxMaterias[codMate-1]} ");

            for (int i = 0; i < qAlu; i++) //podria haber usado en lugar de auxMaterias.Length auxNotas.GetLength(1)-1
            {
                if (auxNotas[ i, codMate-1] != 0)
                {
                    Console.WriteLine($"Alumno {i+1} nota: {auxNotas[i, codMate-1]}");
                }
            }
        }

        static void notasDeUnAlumno(int [,]auxNotas,string []auxMaterias)
        {
            int codAlu = 0;
            Console.WriteLine($"Ingrese el código alumno a consular entre 1 y {auxNotas.GetLength(0)-1}"); // podria haber usado 100 en lugar del GetLenght
            codAlu= int.Parse(Console.ReadLine());
            Console.Write($"Alumno: {codAlu} ");
            for(int i = 0; i < auxMaterias.Length; i++) //podria haber usado en lugar de auxMaterias.Length auxNotas.GetLength(1)-1
            {
                if(auxNotas[codAlu-1,i] != 0)
                {
                    Console.Write($", {auxMaterias[i]} {auxNotas[codAlu-1,i]}" );
                }
            }
            Console.WriteLine("");
        }

        static void notasDeUnAlumnoDeUnaMateria(int[,] auxNotas, string[] auxMaterias)
        {
            int codAlu = 0, codMate = 0;
            Console.WriteLine("Ingrese el código del alumno");
            codAlu= int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el código de Materia");
            codMate= int.Parse(Console.ReadLine());

            if (auxNotas[codAlu - 1, codMate - 1] != 0)
            {
                Console.WriteLine($"El alumno {codAlu}, rindió {auxMaterias[codMate - 1]} con {auxNotas[codAlu - 1, codMate - 1]} ");
            }
            else
            {
                Console.WriteLine($"El alumno {codAlu} no rindió {auxMaterias[codMate - 1]}");
            }

        }
        
        static void cantidadDeMateriasExaminadasPorAlumno(int[,] auxNotas)
        {
            int qAlu = auxNotas.GetLength(0) - 1;
            int columnaTotalizadora = auxNotas.GetLength(1) - 1;
            // podria haber usado el valor 8 directamente, pero lo dejé variable para las pruebas
            //int columnaTotalizadora = 8
            for (int i = 0; i < qAlu; i++) //podria haber usado en lugar de auxMaterias.Length auxNotas.GetLength(1)-1
            {                               
                   Console.WriteLine($"Alumno {i+1} materias examinadas: {auxNotas[i, columnaTotalizadora]}");
                
            }
        }

        static void alumnoNoPresentadoAunaMateria(int[,] auxNotas, string[] auxMaterias)
        {
            int codAlu = 0;
            Console.WriteLine($"Ingrese el código alumno a consular entre 1 y {auxNotas.GetLength(0) - 1}"); // podria haber usado 100 en lugar del GetLenght
            codAlu = int.Parse(Console.ReadLine());
            Console.Write($"Alumno: {codAlu} ");
            for (int i = 0; i < auxMaterias.Length; i++) //podria haber usado en lugar de auxMaterias.Length auxNotas.GetLength(1)-1
            {
                if (auxNotas[codAlu - 1, i] == 0)
                {
                    Console.Write($", {auxMaterias[i]}");
                }
            }
            Console.WriteLine("");
        }
    
        static void notasDeUnaMateriaT2(int[,] auxNotas, string[] auxMaterias)
        {
            int codMate = 0, qAlu = auxNotas.GetLength(0) - 1;
            Console.WriteLine($"Ingrese el código de materia a consular entre 1 y {auxMaterias.Length}");
            codMate = int.Parse(Console.ReadLine());
            Console.WriteLine($"Materia: {auxMaterias[codMate - 1]} ");

            for (int i = qAlu; i >= 0; i--) 
            {
                if (auxNotas[i, codMate - 1] != 0)
                {
                    Console.WriteLine($"Alumno {i + 1} nota: {auxNotas[i, codMate - 1]}");
                }
            }
        }
        
        static void cantidadDeAlumnosXMateria(int[,] auxNotas, string[] auxMaterias)
        {
            int qMate = auxMaterias.Length ;
            int filaTotalizadora = auxNotas.GetLength(0) - 1;
            
            for (int j = 0; j < qMate; j++) //podria haber usado en lugar de auxMaterias.Length auxNotas.GetLength(1)-1
            {
                Console.WriteLine($"{auxMaterias[j]} alumnos: {auxNotas[ filaTotalizadora, j]}");

            }
        }
    }
}
