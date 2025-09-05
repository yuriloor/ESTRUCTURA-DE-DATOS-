#include <iostream>
#include <set>
#include <map>
#include <string>

using namespace std;

int main()
{
    // Conjunto de disciplinas
    set<string> disciplinas = { "Atletismo", "Natacion", "Ciclismo", "Futbol" };

    // Mapa: disciplina -> conjunto de deportistas
    map<string, set<string>> deportistas;
    deportistas["Atletismo"] = { "Maria", "Jose"}
    ;
    deportistas["Natacion"] = { "Carlos", "Lucia"}
    ;
    deportistas["Ciclismo"] = { "Andres", "Diana"}
    ;
    deportistas["Futbol"] = { "Kevin", "Luis", "Ana"}
    ;

    // Mapa para guardar los ganadores
    map<string, string> ganadores;

    int opcion;
    string disciplina, ganador;

    do
    {
        cout << "\n=== MENU DE PREMIACION ===\n";
        cout << "1. Mostrar todas las disciplinas\n";
        cout << "2. Mostrar deportistas por disciplina\n";
        cout << "3. Registrar ganador por disciplina\n";
        cout << "4. Ver reporte de ganadores\n";
        cout << "0. Salir\n";
        cout << "Seleccione una opcion: ";
        cin >> opcion;

        switch (opcion)
        {
            case 1:
                {
                    cout << "\n--- Disciplinas en competencia ---\n";
                    for (const auto&d : disciplinas) {
                        cout << "- " << d << endl;
                    }
                    break;
                }
            case 2:
                {
                    cout << "\nIngrese la disciplina a consultar: ";
                    cin >> disciplina;

                    if (disciplinas.count(disciplina))
                    {
                        cout << "Participantes en " << disciplina << ": ";
                        for (const auto&dep : deportistas[disciplina]) {
                            cout << dep << " ";
                        }
                        cout << endl;
                    }
                    else
                    {
                        cout << "Disciplina no encontrada.\n";
                    }
                    break;
                }
            case 3:
                {
                    cout << "\nIngrese la disciplina: ";
                    cin >> disciplina;

                    if (disciplinas.count(disciplina))
                    {
                        cout << "Participantes en " << disciplina << ": ";
                        for (const auto&dep : deportistas[disciplina]) {
                            cout << dep << " ";
                        }
                        cout << endl;

                        cout << "Ingrese el ganador: ";
                        cin >> ganador;

                        if (deportistas[disciplina].count(ganador))
                        {
                            ganadores[disciplina] = ganador;
                            cout << "Ganador registrado con exito.\n";
                        }
                        else
                        {
                            cout << "El nombre no esta en la lista de participantes.\n";
                        }
                    }
                    else
                    {
                        cout << "Disciplina no encontrada.\n";
                    }
                    break;
                }
            case 4:
                {
                    cout << "\n--- REPORTE DE GANADORES ---\n";
                    if (ganadores.empty())
                    {
                        cout << "No hay ganadores registrados aun.\n";
                    }
                    else
                    {
                        for (const auto&par : ganadores) {
                            cout << par.first << ": " << par.second << endl;
                        }
                    }
                    break;
                }
            case 0:
                cout << "Saliendo del programa...\n";
                break;

            default:
                cout << "Opcion no valida.\n";
        }
    } while (opcion != 0);

    return 0;
}
