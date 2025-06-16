using System;

class Estudiante
{
    // Atributos del estudiante
    public int Id;
    public string Nombres;
    public string Apellidos;
    public string Direccion;
    
    // Array para almacenar hasta 3 teléfonos
    public string[] Telefonos = new string[3];

    // Método para mostrar los datos del estudiante
    public void Mostrar()
    {
        Console.WriteLine("===== DATOS DEL ESTUDIANTE =====");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre completo: {Nombres} {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");

        // Mostrar los teléfonos registrados
        Console.WriteLine("Teléfonos registrados:");
        bool tieneTelefonos = false;

        for (int i = 0; i < Telefonos.Length; i++)
        {
            // Verificar si el teléfono no está vacío ni nulo
            if (!string.IsNullOrEmpty(Telefonos[i]))
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
                tieneTelefonos = true;
            }
        }

        // Si no se ingresó ningún teléfono
        if (!tieneTelefonos)
        {
            Console.WriteLine("  (No tiene teléfonos registrados)");
        }

        Console.WriteLine("================================\n");
    }
}

class Program
{
    static void Main()
    {
        // Crear un objeto Estudiante
        Estudiante est = new Estudiante();

        // Asignar valores al estudiante
        est.Id = 1001;
        est.Nombres = "YURI ELIZABETH";
        est.Apellidos = "LOOR CEDEÑO";
        est.Direccion = "Av.Milton Reyes, Riobamba";

        // Ingresar teléfonos (solo se ingresan algunos)
        est.Telefonos[0] = "0991234567"; // Teléfono 1
        est.Telefonos[1] = null;         // Teléfono 2 no ingresado
        est.Telefonos[2] = "";           // Teléfono 3 vacío

        // Mostrar la información del estudiante
        est.Mostrar();
    }
}
