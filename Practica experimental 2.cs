using System;
using System.Collections.Generic;

// Clase Persona: representa a cada usuario que llega a la atracción
public class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase Atraccion: gestiona la cola, asigna asientos y muestra los resultados
public class Atraccion
{
    private Queue<Persona> colaDeEspera;
    private List<Persona> asientosAsignados;
    private const int CapacidadMaxima = 30;

    public Atraccion()
    {
        colaDeEspera = new Queue<Persona>();
        asientosAsignados = new List<Persona>();
    }

    public void AgregarPersona(string nombre)
    {
        // Verificar duplicado
        bool existe = colaDeEspera.Any(p => p.Nombre == nombre) || asientosAsignados.Any(p => p.Nombre == nombre);
        if (existe)
        {
            Console.WriteLine($"⚠ {nombre} ya está registrado en el sistema.");
            return;
        }

        // Verificar límite
        if (colaDeEspera.Count + asientosAsignados.Count >= CapacidadMaxima)
        {
            Console.WriteLine("❌ Límite alcanzado. No se permiten más registros.");
            return;
        }

        Persona persona = new Persona(nombre);
        colaDeEspera.Enqueue(persona);
        Console.WriteLine($"✔ {nombre} ha sido agregado a la cola.");
    }

    public void AsignarAsientos()
    {
        if (asientosAsignados.Count >= CapacidadMaxima)
        {
            Console.WriteLine("🚫 Ya no hay asientos disponibles.");
            return;
        }

        while (asientosAsignados.Count < CapacidadMaxima && colaDeEspera.Count > 0)
        {
            Persona siguiente = colaDeEspera.Dequeue();
            asientosAsignados.Add(siguiente);
            Console.WriteLine($"🎟 Asiento asignado a: {siguiente.Nombre}");
        }

        if (asientosAsignados.Count == CapacidadMaxima)
        {
            Console.WriteLine("✅ Todos los asientos han sido asignados.");
        }
    }

    public void MostrarAsientos()
    {
        Console.WriteLine("\n📋 Lista de personas con asiento:");
        int numero = 1;
        foreach (Persona persona in asientosAsignados)
        {
            Console.WriteLine($"{numero++}. {persona.Nombre}");
        }
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion();
        string entrada;

        Console.WriteLine("🎢 Sistema de Asignación de 30 Asientos (Parque de Diversiones)");
        Console.WriteLine("✏ Ingrese el nombre de cada persona o escriba 'asignar' para asignar asientos.");
        Console.WriteLine("⛔ Escriba 'salir' para finalizar el programa.");

        do
        {
            Console.Write("\n👉 Entrada: ");
            entrada = Console.ReadLine();

            if (entrada.ToLower() == "asignar")
            {
                atraccion.AsignarAsientos();
                atraccion.MostrarAsientos();
            }
            else if (entrada.ToLower() != "salir" && !string.IsNullOrWhiteSpace(entrada))
            {
                atraccion.AgregarPersona(entrada);
            }

        } while (entrada.ToLower() != "salir");

        Console.WriteLine("\n👋 Programa finalizado. Gracias por utilizar el sistema.");
    }
}
