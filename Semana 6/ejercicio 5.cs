/*
Ejercicio 5:
Crear un programa que maneje dos Crear un programa que maneje dos listas enlazadas d listas enlazadas de elementos que almacenen datos de elementos que almacenen datos de
tipo enteros. La primera se deben almacenar sólo los números primos, y se agregan por el
final. La segunda deben contener sólo números Armstrong, se rong, se agregan por el agregan por el inicio de la lista. inicio de la lista.
Al final, mostrar:
a. El número de datos El número de datos insertados en cada lista. insertados en cada lista.
b. Mostrar un mensaje indicando la lista que Mostrar un mensaje indicando la lista que contiene contiene más elementos. más elementos.
c. Mostrar todos los datos insertados en las listas.
*/


using System;

namespace DosListasEnlazadas
{
    // Clase que representa un nodo de la lista enlazada
    public class Nodo
    {
        public int Valor;        // Dato que almacena el nodo
        public Nodo Siguiente;   // Referencia al siguiente nodo

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;    // Inicialmente no apunta a ningún nodo
        }
    }

    // Clase que representa una lista enlazada simple
    public class ListaEnlazada
    {
        public Nodo Cabeza;      // Primer nodo de la lista

        public ListaEnlazada()
        {
            Cabeza = null;      // La lista inicia vacía
        }

        // Método para agregar un nodo al final (para lista de números primos)
        public void AgregarAlFinal(int valor)
        {
            Nodo nuevo = new Nodo(valor); // Crear nuevo nodo con el valor

            if (Cabeza == null)
            {
                // Si la lista está vacía, el nuevo nodo será la cabeza
                Cabeza = nuevo;
            }
            else
            {
                // Si no está vacía, recorremos hasta el último nodo
                Nodo actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                // El último nodo apunta al nuevo nodo
                actual.Siguiente = nuevo;
            }
        }

        // Método para agregar un nodo al inicio (para lista de números Armstrong)
        public void AgregarAlInicio(int valor)
        {
            Nodo nuevo = new Nodo(valor);
            nuevo.Siguiente = Cabeza;  // Nuevo nodo apunta a la cabeza actual
            Cabeza = nuevo;            // Nueva cabeza es el nodo agregado
        }

        // Método para contar la cantidad de nodos en la lista
        public int Contar()
        {
            int contador = 0;
            Nodo actual = Cabeza;

            // Recorre todos los nodos y cuenta
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // Método para mostrar todos los valores de la lista
        public void Mostrar()
        {
            Nodo actual = Cabeza;

            // Recorre todos los nodos y los imprime
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }

            Console.WriteLine("null"); // Indica el final de la lista
        }
    }

    class Program
    {
        // Método para verificar si un número es primo
        static bool EsPrimo(int num)
        {
            if (num < 2) return false; // Los números menores que 2 no son primos

            // Verifica divisores desde 2 hasta la raíz cuadrada del número
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;  // Si es divisible, no es primo
            }
            return true; // No se encontró divisor, es primo
        }

        // Método para verificar si un número es Armstrong
        static bool EsArmstrong(int num)
        {
            int suma = 0;
            int temp = num;
            int digitos = num.ToString().Length; // Número de dígitos

            // Calcula suma de cada dígito elevado a la cantidad de dígitos
            while (temp > 0)
            {
                int digito = temp % 10;                 // Extraer último dígito
                suma += (int)Math.Pow(digito, digitos); // Elevarlo y sumar
                temp /= 10;                             // Eliminar último dígito
            }

            return suma == num; // Si la suma es igual al número, es Armstrong
        }

        static void Main(string[] args)
        {
            ListaEnlazada listaPrimos = new ListaEnlazada();       // Lista para primos
            ListaEnlazada listaArmstrong = new ListaEnlazada();    // Lista para Armstrong

            Console.WriteLine("Ingrese números enteros (ingrese -1 para terminar):");

            // Ciclo para leer números hasta que se ingrese -1
            while (true)
            {
                Console.Write("Número: ");

                // Validar que la entrada sea un entero
                if (!int.TryParse(Console.ReadLine(), out int numero))
                {
                    Console.WriteLine("Entrada inválida, intente de nuevo.");
                    continue;
                }

                if (numero == -1) break;  // Condición de salida

                // Si es primo, agregar al final de listaPrimos
                if (EsPrimo(numero))
                {
                    listaPrimos.AgregarAlFinal(numero);
                }

                // Si es Armstrong, agregar al inicio de listaArmstrong
                if (EsArmstrong(numero))
                {
                    listaArmstrong.AgregarAlInicio(numero);
                }
            }

            // Contar elementos en ambas listas
            int countPrimos = listaPrimos.Contar();
            int countArmstrong = listaArmstrong.Contar();

            // Mostrar la cantidad de elementos insertados
            Console.WriteLine("\nCantidad de números primos insertados: " + countPrimos);
            Console.WriteLine("Cantidad de números Armstrong insertados: " + countArmstrong);

            // Comparar cuál lista tiene más elementos
            if (countPrimos > countArmstrong)
            {
                Console.WriteLine("La lista de números primos tiene más elementos.");
            }
            else if (countArmstrong > countPrimos)
            {
                Console.WriteLine("La lista de números Armstrong tiene más elementos.");
            }
            else
            {
                Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");
            }

            // Mostrar los datos almacenados en ambas listas
            Console.WriteLine("\nLista de números primos:");
            listaPrimos.Mostrar();

            Console.WriteLine("\nLista de números Armstrong:");
            listaArmstrong.Mostrar();
        }
    }
}
