using System;
using System.Collections.Generic;

class TorreHanoi
{
    /// <summary>
    /// Función principal del programa.
    /// Solicita al usuario el número de discos y configura las torres.
    /// </summary>
    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        int n = int.Parse(Console.ReadLine()); // Lee el número de discos desde la consola

        // Se crean las tres torres como pilas: origen, auxiliar y destino
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        // Se apilan los discos en la torre de origen (el disco más grande abajo)
        for (int i = n; i >= 1; i--)
        {
            origen.Push(i);
        }

        // Llama al algoritmo recursivo para resolver el problema de Hanoi
        ResolverHanoi(n, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");
    }

    /// <summary>
    /// Algoritmo recursivo que resuelve el problema de las Torres de Hanoi usando pilas.
    /// </summary>
    /// <param name="n">Cantidad de discos a mover</param>
    /// <param name="origen">Pila de origen</param>
    /// <param name="destino">Pila de destino</param>
    /// <param name="auxiliar">Pila auxiliar</param>
    /// <param name="nombreOrigen">Nombre de la torre de origen</param>
    /// <param name="nombreDestino">Nombre de la torre de destino</param>
    /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                              string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        // Caso base: solo hay un disco por mover
        if (n == 1)
        {
            int disco = origen.Pop();      // Quita el disco de la torre de origen
            destino.Push(disco);           // Lo coloca en la torre de destino
            MostrarMovimiento(disco, nombreOrigen, nombreDestino); // Muestra el paso
        }
        else
        {
            // Paso 1: mover n-1 discos de origen a auxiliar
            ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            // Paso 2: mover el disco más grande al destino
            int disco = origen.Pop();
            destino.Push(disco);
            MostrarMovimiento(disco, nombreOrigen, nombreDestino);

            // Paso 3: mover los n-1 discos de auxiliar a destino
            ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }

    /// <summary>
    /// Muestra el movimiento de un disco entre torres en consola.
    /// </summary>
    /// <param name="disco">Número del disco que se está moviendo</param>
    /// <param name="desde">Nombre de la torre de origen</param>
    /// <param name="hacia">Nombre de la torre de destino</param>
    static void MostrarMovimiento(int disco, string desde, string hacia)
    {
        Console.WriteLine($"Mover disco {disco} de {desde} a {hacia}");
    }
}
