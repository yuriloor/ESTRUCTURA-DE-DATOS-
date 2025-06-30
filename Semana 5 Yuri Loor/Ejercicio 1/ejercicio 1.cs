/*
Ejercicio 1:
Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua)
en una lista y la muestre por pantalla, utilizando C# y en lo posible Programación Orientada a Objetos.
*/

using System;
using System.Collections.Generic;

// Definición de la clase Curso que representa un curso con sus asignaturas
public class Curso
{
    // Lista privada para almacenar las asignaturas del curso
    private List<string> asignaturas;

    // Constructor de la clase que inicializa la lista de asignaturas
    public Curso()
    {
        asignaturas = new List<string>();
    }

    // Método para agregar una asignatura a la lista
    public void AgregarAsignatura(string asignatura)
    {
        asignaturas.Add(asignatura);
    }

    // Método para mostrar todas las asignaturas almacenadas en la lista
    public void MostrarAsignaturas()
    {
        Console.WriteLine("Asignaturas del curso:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine("- " + asignatura);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la clase Curso
        Curso miCurso = new Curso();

        // Agregar asignaturas al curso
        miCurso.AgregarAsignatura("Matemáticas");
        miCurso.AgregarAsignatura("Física");
        miCurso.AgregarAsignatura("Química");
        miCurso.AgregarAsignatura("Historia");
        miCurso.AgregarAsignatura("Lengua");

        // Mostrar las asignaturas por pantalla
        miCurso.MostrarAsignaturas();

        // Esperar a que el usuario presione una tecla antes de cerrar la consola
        Console.WriteLine("Presione una tecla para salir...");
        Console.ReadKey();
    }
}
