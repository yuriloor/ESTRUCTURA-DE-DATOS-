using System;
using System.Collections.Generic;

// Clase que representa una asignatura con su nombre y nota
public class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    // Constructor que recibe el nombre de la asignatura
    public Asignatura(string nombre)
    {
        Nombre = nombre;
        Nota = 0.0; // Valor inicial
    }
}

// Clase que representa un curso con varias asignaturas
public class Curso
{
    private List<Asignatura> asignaturas;

    // Constructor que inicializa la lista
    public Curso()
    {
        asignaturas = new List<Asignatura>();
    }

    // Método para agregar una asignatura al curso
    public void AgregarAsignatura(string nombre)
    {
        asignaturas.Add(new Asignatura(nombre));
    }

    // Método para pedir al usuario las notas de cada asignatura
    public void PedirNotas()
    {
        foreach (var asignatura in asignaturas)
        {
            Console.Write($"¿Qué nota has sacado en {asignatura.Nombre}? ");
            string entrada = Console.ReadLine();

            // Intentamos convertir la entrada a número
            if (double.TryParse(entrada, out double nota))
            {
                asignatura.Nota = nota;
            }
            else
            {
                Console.WriteLine("Nota no válida. Se asignará 0.");
                asignatura.Nota = 0.0;
            }
        }
    }

    // Método para mostrar el mensaje con cada asignatura y su nota
    public void MostrarNotas()
    {
        Console.WriteLine("\nResumen de tus calificaciones:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"En {asignatura.Nombre} has sacado {asignatura.Nota}");
        }
    }
}

// Clase principal del programa
class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia del curso
        Curso miCurso = new Curso();

        // Agregar asignaturas al curso
        miCurso.AgregarAsignatura("Matemáticas");
        miCurso.AgregarAsignatura("Física");
        miCurso.AgregarAsignatura("Química");
        miCurso.AgregarAsignatura("Historia");
        miCurso.AgregarAsignatura("Lengua");

        // Pedir al usuario las notas
        miCurso.PedirNotas();

        // Mostrar las notas con el mensaje solicitado
        miCurso.MostrarNotas();

        // Pausar la consola
        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
