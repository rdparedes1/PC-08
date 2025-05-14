class Program
{
    static void Main(string[] args)
    {
        string[] nombres = new string[10];
        double[,] notas = new double[10, 10];
        bool success = false;
        OperacionesNotas operacionesNotas = new OperacionesNotas();
        for (int i = 0; i < nombres.Length; i++) {
            Console.WriteLine("Ingrese el nombre del alumno número " + (i+1));
            nombres[i] = Console.ReadLine();
            Console.WriteLine(" ");
        }
        Console.WriteLine("Nombres de los alumnos registrados: ");
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.WriteLine(nombres[i]);
        }
        Console.WriteLine(" ");

        try
        {
            for(int fila = 0; fila < notas.GetLength(0); fila++)
            {
                Console.WriteLine("Ingrese las notas del alumno " + nombres[fila]);
                for(int columna = 0; columna < notas.GetLength(1); columna++)
                {
                    Console.WriteLine("Ingrese la nota " + (columna + 1));
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double nota))
                    {
                        if (nota >= 0 && nota <= 100)
                        {
                            notas[fila, columna] = nota;
                        }
                        else
                        {
                            Console.WriteLine("La nota debe estar entre 0 y 100. Intente nuevamente.");
                            columna--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Formato no aceptado, ingrese nuevamente la nota.");
                        columna--;
                    }
                }
                Console.WriteLine(" ");
            }
            for (int fila = 0; fila < notas.GetLength(0); fila++)
            {
                for (int columna = 0; columna < notas.GetLength(1); columna++)
                {
                    Console.Write(notas[fila, columna] + " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine(" ");
            while (!success)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Mostrar nombre y notas aprobadas para cada alumno.");
                Console.WriteLine("2. Mostrar nombre y notas no aprobadas para cada alumno.");
                Console.WriteLine("3. Mostrar el promedio de notas del grupo.");
                Console.WriteLine("4. Salir.");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        operacionesNotas.NotasAprobadas(nombres, notas);
                        break;
                    case 2:
                        operacionesNotas.NotasNoAprobadas(nombres, notas);
                        break;
                    case 3:
                        operacionesNotas.PromedioGrupo(notas);
                        break;
                    case 4:
                        success = operacionesNotas.cambiarEstado(success);
                        break;
                }
            }
            } catch
            {
                Console.WriteLine("Formato no aceptado, ingrese nuevamente los datos.");
                Console.WriteLine(" ");
            }
    }
}

class OperacionesNotas
{
    public void NotasAprobadas(string[] alumnos, double[,] notas)
    {
        for (int fila = 0; fila < notas.GetLength(0); fila++)
        {
            Console.WriteLine("Los cursos aprobados por el alumno: " + alumnos[fila] + " son,");
            for (int columna = 0; columna < notas.GetLength(1); columna++)
            {
                if (notas[fila, columna] >= 65)
                {
                    Console.WriteLine("El curso número " + (columna+1) + " fue aprobado con una nota de " + notas[fila, columna]);
                }
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    public void NotasNoAprobadas(string[] alumnos, double[,] notas)
    {
        for (int fila = 0; fila < notas.GetLength(0); fila++)
        {
            Console.WriteLine("Los cursos no aprobados por el alumno: " + alumnos[fila] + " son,");
            for (int columna = 0; columna < notas.GetLength(1); columna++)
            {
                if (notas[fila, columna] < 65)
                {
                    Console.WriteLine("El curso número " + (columna + 1) + " fue desaprobado con una nota de " + notas[fila, columna]);
                }
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    public void PromedioGrupo(double[,] notas)
    {
        double suma = 0;
        int cantidadNotas = notas.Length;
        for (int fila = 0; fila < notas.GetLength(0); fila++)
        {
            for (int columna = 0; columna < notas.GetLength(1); columna++)
            {
                suma += notas[fila, columna];
            }
        }
        double promedio = suma / cantidadNotas;
        Console.WriteLine("El promedio del grupo es: " + promedio);
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    public bool cambiarEstado(bool estado)
    {
        Console.WriteLine("Saliendo del programa.");
        return !estado;
    }
}