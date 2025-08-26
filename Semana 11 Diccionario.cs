using System;
using System.Collections.Generic;

class Traductor
{
    static void Main()
    {
        // Diccionario inicial Inglés -> Español
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase (Inglés -> Español)");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("⚠ Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese la frase en inglés: ");
                    string frase = Console.ReadLine().ToLower();

                    string[] palabras = frase.Split(' ', ',', '.', ';', ':', '!', '?');
                    string traduccion = frase; // frase original para reemplazo

                    foreach (string palabra in palabras)
                    {
                        if (diccionario.ContainsKey(palabra))
                        {
                            traduccion = ReplaceWord(traduccion, palabra, diccionario[palabra]);
                        }
                    }

                    Console.WriteLine("Traducción (parcial): " + traduccion);
                    break;

                case 2:
                    Console.Write("\nIngrese la palabra en inglés: ");
                    string ing = Console.ReadLine().ToLower();

                    Console.Write("Ingrese su traducción en español: ");
                    string esp = Console.ReadLine().ToLower();

                    if (!diccionario.ContainsKey(ing))
                    {
                        diccionario.Add(ing, esp);
                        Console.WriteLine("✅ Palabra agregada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("⚠ Esa palabra ya existe en el diccionario.");
                    }
                    break;

                case 0:
                    Console.WriteLine("👋 Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("⚠ Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    // Reemplaza solo palabras completas, manteniendo puntuación
    static string ReplaceWord(string original, string word, string replacement)
    {
        string[] separadores = { " ", ",", ".", ";", ":", "!", "?" };
        string[] partes = original.Split(separadores, StringSplitOptions.None);

        for (int i = 0; i < partes.Length; i++)
        {
            if (partes[i] == word)
            {
                partes[i] = replacement;
            }
        }

        return string.Join(" ", partes);
    }
}
