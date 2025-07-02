/*
Ejercicio 2:
Invertir una lista Invertir una lista enlazada: enlazada:
Implementar un método dentro de la Implementar un método dentro de la lista enlazada q lista enlazada que permita invertir los datos ue 
permita invertir los datos almacenados en una lista enlazada, es decir que almacenados en una lista enlazada, es decir que el primer 
elemento pase a ser el último y el primer elemento pase a ser el último y el
último pase a ser el primero, que el segundo sea el penúltimo y el penúltimo pase a ser el
segundo y así segundo y así sucesivamente. 
*/
using System;

namespace ListaEnlazadaEjemplo
{
    // Clase que representa un nodo de la lista
    public class Nodo
    {
        public int Valor;        // Dato que almacena el nodo
        public Nodo Siguiente;   // Referencia al siguiente nodo

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    // Clase que representa la lista enlazada simple
    public class ListaEnlazada
    {
        public Nodo Cabeza;  // Primer nodo de la lista

        public ListaEnlazada()
        {
            Cabeza = null;  // Al iniciar la lista está vacía
        }

        // Método para agregar un nuevo nodo al final de la lista
        public void Agregar(int valor)
        {
            Nodo nuevo = new Nodo(valor);  // Crear nuevo nodo con el valor

            if (Cabeza == null)
            {
                // Si la lista está vacía, el nuevo nodo será la cabeza
                Cabeza = nuevo;
            }
            else
            {
                // Si no está vacía, recorrer hasta el último nodo
                Nodo actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                // El último nodo apuntará al nuevo nodo
                actual.Siguiente = nuevo;
            }
        }

        // Método para calcular la longitud de la lista
        public int Longitud()
        {
            int contador = 0;
            Nodo actual = Cabeza;

            // Recorre la lista mientras haya nodos
            while (actual != null)
            {
                contador++;           // Cuenta cada nodo visitado
                actual = actual.Siguiente;  // Avanza al siguiente nodo
            }

            return contador;  // Devuelve el total de nodos contados
        }

        // Método para invertir la lista enlazada
        public void Invertir()
        {
            Nodo anterior = null;   // Nodo anterior inicializado en null
            Nodo actual = Cabeza;   // Nodo actual comienza en la cabeza
            Nodo siguiente = null;  // Nodo siguiente para guardar temporalmente

            // Mientras existan nodos por procesar
            while (actual != null)
            {
                siguiente = actual.Siguiente;  // Guardar siguiente nodo
                actual.Siguiente = anterior;   // Cambiar enlace para que apunte al nodo anterior (invirtiendo)
                anterior = actual;             // Avanzar nodo anterior a actual
                actual = siguiente;            // Avanzar nodo actual a siguiente
            }

            Cabeza = anterior;  // Actualizar la cabeza al último nodo procesado
        }

        // Método para imprimir los valores de la lista
        public void Imprimir()
        {
            Nodo actual = Cabeza;

            // Recorre y muestra cada valor hasta llegar al final
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }

            Console.WriteLine("null"); // Indica el fin de la lista
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            // Agregamos algunos valores
            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);
            lista.Agregar(40);

            Console.WriteLine("Lista original:");
            lista.Imprimir();

            // Invertimos la lista
            lista.Invertir();

            Console.WriteLine("Lista invertida:");
            lista.Imprimir();
        }
    }
}
