using System;

namespace ArbolBinarioBusqueda
{
    public class Nodo
    {
        public int Dato { get; set; }

        // Permiten valores NULL porque un hijo puede no existir
        public Nodo? Izquierdo { get; set; }
        public Nodo? Derecho { get; set; }

        public Nodo(int dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
        }
    }

    public class ArbolBinario
    {
        // La raíz puede ser nula si el árbol está vacío
        public Nodo? Raiz { get; set; }

        public ArbolBinario()
        {
            Raiz = null;
        }

        // ====== INSERCIÓN ======
        public void Insertar(int dato)
        {
            Raiz = InsertarRecursivo(Raiz, dato);
        }

        private Nodo InsertarRecursivo(Nodo? nodo, int dato)
        {
            if (nodo == null) return new Nodo(dato);

            if (dato < nodo.Dato)
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, dato);
            else if (dato > nodo.Dato)
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, dato);

            return nodo;
        }

        // ====== RECORRIDOS ======
        public void InOrden(Nodo? nodo)
        {
            if (nodo == null) return;
            InOrden(nodo.Izquierdo);
            Console.Write(nodo.Dato + " ");
            InOrden(nodo.Derecho);
        }

        public void PreOrden(Nodo? nodo)
        {
            if (nodo == null) return;
            Console.Write(nodo.Dato + " ");
            PreOrden(nodo.Izquierdo);
            PreOrden(nodo.Derecho);
        }

        public void PostOrden(Nodo? nodo)
        {
            if (nodo == null) return;
            PostOrden(nodo.Izquierdo);
            PostOrden(nodo.Derecho);
            Console.Write(nodo.Dato + " ");
        }

        // ====== BÚSQUEDA ======
        public bool Buscar(Nodo? nodo, int valor)
        {
            if (nodo == null) return false;
            if (valor == nodo.Dato) return true;
            return valor < nodo.Dato ? Buscar(nodo.Izquierdo, valor) : Buscar(nodo.Derecho, valor);
        }

        // ====== ELIMINACIÓN ======
        public Nodo? Eliminar(Nodo? nodo, int valor)
        {
            if (nodo == null) return null;

            if (valor < nodo.Dato)
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, valor);
            else if (valor > nodo.Dato)
                nodo.Derecho = Eliminar(nodo.Derecho, valor);
            else
            {
                if (nodo.Izquierdo == null && nodo.Derecho == null) return null;
                if (nodo.Izquierdo == null) return nodo.Derecho;
                if (nodo.Derecho == null) return nodo.Izquierdo;

                nodo.Dato = MinValor(nodo.Derecho);
                nodo.Derecho = Eliminar(nodo.Derecho, nodo.Dato);
            }
            return nodo;
        }

        private int MinValor(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;
            return nodo.Dato;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();
            int opcion;

            do
            {
                Console.WriteLine("\n===== MENÚ ÁRBOL BINARIO DE BÚSQUEDA =====");
                Console.WriteLine("1. Insertar nodo");
                Console.WriteLine("2. Recorrido InOrden");
                Console.WriteLine("3. Recorrido PreOrden");
                Console.WriteLine("4. Recorrido PostOrden");
                Console.WriteLine("5. Buscar un dato");
                Console.WriteLine("6. Eliminar un nodo");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese un número: ");
                        if (int.TryParse(Console.ReadLine(), out int dato))
                        {
                            arbol.Insertar(dato);
                            Console.WriteLine("Nodo insertado.");
                        }
                        else Console.WriteLine("Valor inválido.");
                        break;

                    case 2:
                        Console.Write("Recorrido InOrden: ");
                        arbol.InOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Write("Recorrido PreOrden: ");
                        arbol.PreOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.Write("Recorrido PostOrden: ");
                        arbol.PostOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Ingrese el número a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valor))
                            Console.WriteLine(arbol.Buscar(arbol.Raiz, valor) ? "Dato encontrado." : "Dato NO encontrado.");
                        else Console.WriteLine("Valor inválido.");
                        break;

                    case 6:
                        Console.Write("Ingrese el número a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int eliminar))
                        {
                            arbol.Raiz = arbol.Eliminar(arbol.Raiz, eliminar);
                            Console.WriteLine("Nodo eliminado (si existía).");
                        }
                        else Console.WriteLine("Valor inválido.");
                        break;

                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 7);
        }
    }
}
