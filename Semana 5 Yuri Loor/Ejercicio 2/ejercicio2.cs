/*
Ejercicio 2
Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua)
en una lista y la muestre por pantalla el mensaje Yo estudio <asignatura>, donde <asignatura> es cada una de las asignaturas de la lista.
*/
using System;
using System.Collections.Generic;

// Clase que representa un Curso con asignaturas
public class Curso
{
    // Lista privada para almacenar las asignaturas
    private List<string> asignaturas;

    // Constructor de la clase que inicializa la lista
    public Curso()
    {
        asignaturas = new List<string>();
    }

    // Método para agregar una asignatura a la lista
    public void AgregarAsignatura(string asignatura)
    {
        asignaturas.Add(asignatura);
    }

    // Método para mostrar el mensaje "Yo estudio <asignatura>"
    public void MostrarAsignaturas()
    {
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }
}

// Clase principal donde se ejecuta el programa
class Program
{
    static void Main(string[] args)
    {
        // Crear un objeto de la clase Curso
        Curso miCurso = new Curso();

        // Agregar asignaturas al curso
        miCurso.AgregarAsignatura("Matemáticas");
        miCurso.AgregarAsignatura("Física");
        miCurso.AgregarAsignatura("Química");
        miCurso.AgregarAsignatura("Historia");
        miCurso.AgregarAsignatura("Lengua");

        // Mostrar los mensajes por pantalla
        miCurso.MostrarAsignaturas();

        // Esperar a que el usuario presione una tecla para cerrar la consola
        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
