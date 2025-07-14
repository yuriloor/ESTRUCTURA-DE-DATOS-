using System;                    // Importa el espacio de nombres para entrada/salida en consola
using System.Collections.Generic; // Importa las colecciones genéricas como Stack

class Program
{
    static void Main()
    {
        // Solicita al usuario que ingrese una expresión matemática
        Console.WriteLine("Ingrese la expresión matemática:");
        string expresion = Console.ReadLine(); // Lee la entrada del usuario

        // Llama a la función para verificar si la expresión está balanceada
        if (EstaBalanceada(expresion))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula NO balanceada.");
        }
    }

    // Función que determina si la expresión tiene símbolos balanceados
    static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>(); // Se crea una pila para almacenar los símbolos de apertura

        // Se recorre cada carácter de la expresión
        foreach (char c in expresion)
        {
            // Si el carácter es un símbolo de apertura, se apila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si el carácter es un símbolo de cierre
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, no hay símbolo de apertura correspondiente
                if (pila.Count == 0)
                    return false;

                // Se obtiene el último símbolo de apertura de la pila
                char tope = pila.Pop();

                // Se verifica si el par de símbolos coincide
                if (!EsParCorrespondiente(tope, c))
                    return false;
            }
        }

        // Si la pila está vacía al final, los símbolos están balanceados
        return pila.Count == 0;
    }

    // Función que verifica si un par de apertura y cierre coinciden
    static bool EsParCorrespondiente(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}
