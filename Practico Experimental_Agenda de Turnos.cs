using System;
using System.Collections.Generic;
using System.Linq;

// Clase que representa un paciente con sus datos básicos
public class Paciente
{
    // Propiedades públicas para los datos del paciente
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public string Especialidad { get; set; }
    public DateTime HoraTurno { get; set; }

    // Constructor para inicializar un paciente con todos sus datos
    public Paciente(string nombre, string cedula, string especialidad, DateTime horaTurno)
    {
        Nombre = nombre;
        Cedula = cedula;
        Especialidad = especialidad;
        HoraTurno = horaTurno;
    }

    // Método para mostrar la información del paciente en formato legible
    public override string ToString()
    {
        return $"Nombre: {Nombre}, Cédula: {Cedula}, Especialidad: {Especialidad}, Hora: {HoraTurno:HH:mm}";
    }
}

// Clase que gestiona la agenda de turnos, almacenando y manipulando pacientes
public class AgendaClinica
{
    // Lista que guarda los turnos (pacientes) registrados
    private List<Paciente> turnos;

    // Constructor que inicializa la lista vacía
    public AgendaClinica()
    {
        turnos = new List<Paciente>();
    }

    // Método para agregar un nuevo turno a la agenda
    public void RegistrarTurno(Paciente paciente)
    {
        turnos.Add(paciente);
        Console.WriteLine("Turno registrado correctamente.\n");
    }

    // Método para mostrar todos los turnos registrados en la agenda
    public void MostrarTurnos()
    {
        if (turnos.Count == 0)
        {
            Console.WriteLine("No hay turnos registrados.\n");
            return;
        }

        Console.WriteLine("Listado de turnos:");
        foreach (var paciente in turnos)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine();
    }

    // Método para buscar un paciente por su cédula en la lista de turnos
    public Paciente BuscarPorCedula(string cedula)
    {
        // Retorna el primer paciente que coincida con la cédula o null si no existe
        return turnos.FirstOrDefault(p => p.Cedula == cedula);
    }

    // Método para eliminar un turno buscando por cédula
    public bool EliminarTurno(string cedula)
    {
        var paciente = BuscarPorCedula(cedula);
        if (paciente != null)
        {
            turnos.Remove(paciente);
            return true; // Eliminación exitosa
        }
        return false; // No se encontró el turno para eliminar
    }
}

// Clase principal que contiene el menú y controla la ejecución del programa
class Program
{
    static void Main(string[] args)
    {
        // Crear una nueva instancia de la agenda
        AgendaClinica agenda = new AgendaClinica();
        bool continuar = true;

        // Ciclo principal del programa para mostrar el menú y procesar opciones
        while (continuar)
        {
            Console.WriteLine("===== Agenda de Turnos de Clínica =====");
            Console.WriteLine("1. Registrar turno");
            Console.WriteLine("2. Mostrar todos los turnos");
            Console.WriteLine("3. Buscar turno por cédula");
            Console.WriteLine("4. Eliminar turno por cédula");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            // Evaluar la opción ingresada por el usuario
            switch (opcion)
            {
                case "1":
                    RegistrarTurno(agenda);
                    break;
                case "2":
                    agenda.MostrarTurnos();
                    break;
                case "3":
                    BuscarTurno(agenda);
                    break;
                case "4":
                    EliminarTurno(agenda);
                    break;
                case "5":
                    continuar = false; // Salir del programa
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.\n");
                    break;
            }
        }

        Console.WriteLine("Programa finalizado. Gracias.");
    }

    // Método para capturar datos del paciente y registrar un nuevo turno
    static void RegistrarTurno(AgendaClinica agenda)
    {
        Console.Write("Ingrese nombre del paciente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese cédula: ");
        string cedula = Console.ReadLine();

        Console.Write("Ingrese especialidad: ");
        string especialidad = Console.ReadLine();

        DateTime horaTurno;
        // Validar que la hora esté en formato correcto HH:mm
        while (true)
        {
            Console.Write("Ingrese hora del turno (HH:mm): ");
            string horaStr = Console.ReadLine();

            if (DateTime.TryParseExact(horaStr, "HH:mm", null, System.Globalization.DateTimeStyles.None, out horaTurno))
            {
                break;
            }
            else
            {
                Console.WriteLine("Formato de hora inválido. Intente nuevamente.");
            }
        }

        // Crear el objeto Paciente con los datos capturados
        Paciente paciente = new Paciente(nombre, cedula, especialidad, horaTurno);

        // Registrar el turno en la agenda
        agenda.RegistrarTurno(paciente);
    }

    // Método para buscar y mostrar un turno por cédula
    static void BuscarTurno(AgendaClinica agenda)
    {
        Console.Write("Ingrese cédula a buscar: ");
        string cedula = Console.ReadLine();

        Paciente paciente = agenda.BuscarPorCedula(cedula);
        if (paciente != null)
        {
            Console.WriteLine("Turno encontrado:");
            Console.WriteLine(paciente + "\n");
        }
        else
        {
            Console.WriteLine("No se encontró turno con esa cédula.\n");
        }
    }

    // Método para eliminar un turno mediante la cédula ingresada
    static void EliminarTurno(AgendaClinica agenda)
    {
        Console.Write("Ingrese cédula para eliminar turno: ");
        string cedula = Console.ReadLine();

        bool eliminado = agenda.EliminarTurno(cedula);
        if (eliminado)
        {
            Console.WriteLine("Turno eliminado correctamente.\n");
        }
        else
        {
            Console.WriteLine("No se encontró turno con esa cédula.\n");
        }
    }
}
