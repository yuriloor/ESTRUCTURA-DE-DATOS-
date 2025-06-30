/*
Ejercicio 4:
Escribir un programa que pregunte al usuario los números ganadores de la lotería primitiva, 
los almacene en una lista, y luego los muestre por pantalla ordenados de menor a mayor.
*/
using System;
using System.Collections.Generic;

// Clase que representa un boleto de lotería con los números ganadores
public class BoletoLoteria
{
    private List<int> numerosGanadores;

    // Constructor que inicializa la lista
    public BoletoLoteria()
    {
        numerosGanadores = new List<int>();
    }

    // Método para pedir los números al usuario
    public void PedirNumeros()
    {
        Console.WriteLine("Ingrese los números ganadores de la lotería primitiva (por ejemplo 6 números):");

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Número {i + 1}: ");
            string entrada = Console.ReadLine();

            // Validar que la entrada sea un número entero
            if (int.TryParse(entrada, out int numero))
            {
                numerosGanadores.Add(numero);
            }
            else
            {
                Console.WriteLine("Valor no válido. Se registrará como 0.");
                numerosGanadores.Add(0);
            }
        }
    }

    // Método para mostrar los números ordenados
    public void MostrarNumerosOrdenados()
    {
        numerosGanadores.Sort(); // Ordena de menor a mayor
        Console.WriteLine("\nNúmeros ganadores ordenados de menor a mayor:");
        foreach (int numero in numerosGanadores)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine(); // Nueva línea final
    }
}

// Clase principal que ejecuta el programa
class Program
{
    static void Main(string[] args)
    {
        // Crear un objeto de la clase BoletoLoteria
        BoletoLoteria miBoleto = new BoletoLoteria();

        // Pedir al usuario los números ganadores
        miBoleto.PedirNumeros();

        // Mostrar los números ordenados
        miBoleto.MostrarNumerosOrdenados();

        // Esperar una tecla para cerrar la consola
        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
