/*
Ejercicio 4:
Escribir un programa que pregunte al usuario los números ganadores de la lotería primitiva, 
los almacene en una lista, y luego los muestre por pantalla ordenados de menor a mayor.
*/
using System;
using System.Collections.Generic;

// Clase que representa una colección de números
public class Numeros
{
    private List<int> listaNumeros;

    // Constructor: inicializa la lista con los números del 1 al 10
    public Numeros()
    {
        listaNumeros = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            listaNumeros.Add(i);
        }
    }

    // Método para mostrar los números en orden inverso separados por comas
    public void MostrarInverso()
    {
        Console.WriteLine("Números en orden inverso:");
        listaNumeros.Reverse(); // Invierte el orden de la lista

        for (int i = 0; i < listaNumeros.Count; i++)
        {
            if (i < listaNumeros.Count - 1)
            {
                Console.Write(listaNumeros[i] + ", ");
            }
            else
            {
                Console.Write(listaNumeros[i]); // Último número sin coma
            }
        }
        Console.WriteLine(); // Salto de línea final
    }
}

// Clase principal del programa
class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la clase Numeros
        Numeros misNumeros = new Numeros();

        // Mostrar la lista en orden inverso
        misNumeros.MostrarInverso();

        // Esperar una tecla para salir
        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
