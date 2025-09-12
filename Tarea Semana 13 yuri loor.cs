using System;
using System.Collections.Generic;

#region Clase Revista
/// <summary>
/// Representa una revista con sus propiedades básicas.
/// </summary>
public class Revista
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Editorial { get; private set; }
    public int Año { get; private set; }

    /// <summary>
    /// Constructor para inicializar una revista
    /// </summary>
    /// <param name="id">Identificador único de la revista</param>
    /// <param name="titulo">Título de la revista</param>
    /// <param name="editorial">Editorial de la revista</param>
    /// <param name="año">Año de publicación</param>
    public Revista(int id, string titulo, string editorial, int año)
    {
        if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El título no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(editorial)) throw new ArgumentException("La editorial no puede estar vacía.");
        if (año <= 0) throw new ArgumentException("El año debe ser positivo.");

        Id = id;
        Titulo = titulo;
        Editorial = editorial;
        Año = año;
    }

    /// <summary>
    /// Sobrescribe ToString() para mostrar la información de la revista
    /// </summary>
    public override string ToString()
    {
        return $"ID: {Id}, Título: {Titulo}, Editorial: {Editorial}, Año: {Año}";
    }
}
#endregion

#region Clase Catalogo
/// <summary>
/// Representa el catálogo de revistas y permite buscar títulos
/// </summary>
public class Catalogo
{
    private readonly List<Revista> _revistas;

    // Constantes para mensajes de búsqueda
    private const string ENCONTRADO = "Encontrado";
    private const string NO_ENCONTRADO = "No encontrado";

    public Catalogo()
    {
        _revistas = new List<Revista>();
    }

    /// <summary>
    /// Agrega una revista al catálogo
    /// </summary>
    public void AgregarRevista(Revista revista)
    {
        if (revista == null) throw new ArgumentNullException(nameof(revista));
        _revistas.Add(revista);
    }

    /// <summary>
    /// Muestra todas las revistas del catálogo
    /// </summary>
    public void MostrarCatalogo()
    {
        if (_revistas.Count == 0)
        {
            Console.WriteLine("El catálogo está vacío.");
            return;
        }

        foreach (var revista in _revistas)
        {
            Console.WriteLine(revista);
        }
    }

    /// <summary>
    /// Búsqueda iterativa de un título
    /// </summary>
    public void BuscarTituloIterativo(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("Título inválido.");
            return;
        }

        bool encontrado = false;

        foreach (var revista in _revistas)
        {
            if (revista.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                break;
            }
        }

        Console.WriteLine(encontrado ? ENCONTRADO : NO_ENCONTRADO);
    }

    /// <summary>
    /// Búsqueda recursiva de un título
    /// </summary>
    public void BuscarTituloRecursivo(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("Título inválido.");
            return;
        }

        var resultado = BuscarRecursivoInterno(titulo, 0);
        Console.WriteLine(resultado != null ? ENCONTRADO : NO_ENCONTRADO);
    }

    /// <summary>
    /// Método privado que realiza la búsqueda recursiva
    /// </summary>
    private Revista BuscarRecursivoInterno(string titulo, int index)
    {
        if (index >= _revistas.Count) return null;

        if (_revistas[index].Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return _revistas[index];

        return BuscarRecursivoInterno(titulo, index + 1);
    }
}
#endregion

#region Programa Principal
/// <summary>
/// Programa principal con menú interactivo
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Inicializa el catálogo con 10 revistas
        Catalogo catalogo = InicializarCatalogo();

        bool salir = false;

        // Bucle del menú interactivo
        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    catalogo.MostrarCatalogo();
                    break;

                case "2":
                    Console.Write("\nIngrese el título a buscar (Iterativo): ");
                    string tituloIterativo = Console.ReadLine();
                    catalogo.BuscarTituloIterativo(tituloIterativo);
                    break;

                case "3":
                    Console.Write("\nIngrese el título a buscar (Recursivo): ");
                    string tituloRecursivo = Console.ReadLine();
                    catalogo.BuscarTituloRecursivo(tituloRecursivo);
                    break;

                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    /// <summary>
    /// Inicializa el catálogo con 10 revistas de ejemplo
    /// </summary>
    private static Catalogo InicializarCatalogo()
    {
        Catalogo catalogo = new Catalogo();
        catalogo.AgregarRevista(new Revista(1, "Revista Ciencia", "Editorial Alfa", 2023));
        catalogo.AgregarRevista(new Revista(2, "Tecnología Hoy", "Editorial Beta", 2024));
        catalogo.AgregarRevista(new Revista(3, "Salud y Vida", "Editorial Gamma", 2022));
        catalogo.AgregarRevista(new Revista(4, "Historia Universal", "Editorial Delta", 2021));
        catalogo.AgregarRevista(new Revista(5, "Economía Global", "Editorial Épsilon", 2023));
        catalogo.AgregarRevista(new Revista(6, "Viajes y Turismo", "Editorial Zeta", 2022));
        catalogo.AgregarRevista(new Revista(7, "Gastronomía Moderna", "Editorial Eta", 2024));
        catalogo.AgregarRevista(new Revista(8, "Arte y Cultura", "Editorial Theta", 2021));
        catalogo.AgregarRevista(new Revista(9, "Deportes al Día", "Editorial Iota", 2023));
        catalogo.AgregarRevista(new Revista(10, "Astronomía y Espacio", "Editorial Kappa", 2024));
        return catalogo;
    }

    /// <summary>
    /// Muestra el menú interactivo
    /// </summary>
    private static void MostrarMenu()
    {
        Console.WriteLine("\n--- Menú del Catálogo de Revistas ---");
        Console.WriteLine("1. Mostrar catálogo");
        Console.WriteLine("2. Buscar título (Iterativo)");
        Console.WriteLine("3. Buscar título (Recursivo)");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }
}
#endregion
