using System;
using System.Collections.Generic;

class Nodo
{
    public string Nombre { get; set; }
    public List<Nodo> Hijos { get; set; }

    public Nodo(string nombre)
    {
        Nombre = nombre;
        Hijos = new List<Nodo>();
    }

    public void AgregarHijo(Nodo hijo)
    {
        Hijos.Add(hijo);
    }
}

class Arbol
{
    public Nodo Raiz { get; set; }

    public Arbol(Nodo raiz)
    {
        Raiz = raiz;
    }

    // Mostrar el árbol jerárquicamente
    public void MostrarArbol(Nodo nodo, int nivel)
    {
        if (nodo == null) return;
        Console.WriteLine(new string(' ', nivel * 3) + "- " + nodo.Nombre);
        foreach (var hijo in nodo.Hijos)
        {
            MostrarArbol(hijo, nivel + 1);
        }
    }

    // Buscar si un nodo existe
    public bool BuscarNodo(Nodo nodo, string nombreBuscado)
    {
        if (nodo == null) return false;
        if (nodo.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase)) return true;

        foreach (var hijo in nodo.Hijos)
        {
            if (BuscarNodo(hijo, nombreBuscado))
                return true;
        }
        return false;
    }

    // Contar el total de nodos
    public int ContarNodos(Nodo nodo)
    {
        if (nodo == null) return 0;
        int total = 1;
        foreach (var hijo in nodo.Hijos)
        {
            total += ContarNodos(hijo);
        }
        return total;
    }

    // Listar todos los nodos
    public void ListarNodos(Nodo nodo, List<string> lista)
    {
        if (nodo == null) return;
        lista.Add(nodo.Nombre);
        foreach (var hijo in nodo.Hijos)
        {
            ListarNodos(hijo, lista);
        }
    }
}

class GraficaArbol
{
    static void Main(string[] args)
    {
        // ======== EJEMPLO 1 ========
        Console.WriteLine("=== EJEMPLO 1: Árbol Familiar ===");

        Nodo raiz = new Nodo("Abuelo");
        Nodo padre1 = new Nodo("Padre");
        Nodo madre1 = new Nodo("Madre");
        Nodo hijo1 = new Nodo("Hijo 1");
        Nodo hijo2 = new Nodo("Hijo 2");

        raiz.AgregarHijo(padre1);
        raiz.AgregarHijo(madre1);
        padre1.AgregarHijo(hijo1);
        madre1.AgregarHijo(hijo2);

        Arbol arbolFamiliar = new Arbol(raiz);

        Console.WriteLine("\n📂 Estructura del árbol:");
        arbolFamiliar.MostrarArbol(raiz, 0);

        Console.WriteLine("\n📊 Reporte del árbol:");
        Console.WriteLine("Total de nodos: " + arbolFamiliar.ContarNodos(raiz));
        string nodoBuscado = "Hijo 2";
        Console.WriteLine($"¿Existe el nodo '{nodoBuscado}'? " +
            (arbolFamiliar.BuscarNodo(raiz, nodoBuscado) ? "✅ Sí" : "❌ No"));
        var listaNodos = new List<string>();
        arbolFamiliar.ListarNodos(raiz, listaNodos);
        Console.WriteLine("Lista de nodos: " + string.Join(", ", listaNodos));

        // ======== EJEMPLO 2 ========
        Console.WriteLine("\n\n=== EJEMPLO 2: Árbol de Categorías de Productos ===");

        Nodo categoria = new Nodo("Productos");
        Nodo electronica = new Nodo("Electrónica");
        Nodo hogar = new Nodo("Hogar");
        Nodo telefonos = new Nodo("Teléfonos");
        Nodo tv = new Nodo("Televisores");
        Nodo cocina = new Nodo("Cocina");
        Nodo limpieza = new Nodo("Limpieza");

        categoria.AgregarHijo(electronica);
        categoria.AgregarHijo(hogar);
        electronica.AgregarHijo(telefonos);
        electronica.AgregarHijo(tv);
        hogar.AgregarHijo(cocina);
        hogar.AgregarHijo(limpieza);

        Arbol arbolProductos = new Arbol(categoria);

        Console.WriteLine("\n📂 Estructura del árbol:");
        arbolProductos.MostrarArbol(categoria, 0);

        Console.WriteLine("\n📊 Reporte del árbol:");
        Console.WriteLine("Total de nodos: " + arbolProductos.ContarNodos(categoria));
        string buscar = "Cocina";
        Console.WriteLine($"¿Existe el nodo '{buscar}'? " +
            (arbolProductos.BuscarNodo(categoria, buscar) ? "✅ Sí" : "❌ No"));
        var listaProd = new List<string>();
        arbolProductos.ListarNodos(categoria, listaProd);
        Console.WriteLine("Lista de nodos: " + string.Join(", ", listaProd));

        Console.WriteLine("\n\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}

