using System;

namespace EB7_Recursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ejecutanado = true;
            while (ejecutanado)
            {
                Console.WriteLine("\n===================================================");
                Console.WriteLine("   ESTRUCTURA DE DATOS - SIMULADOR DEL CALL STACK   ");
                Console.WriteLine("===================================================");
                Console.WriteLine("1. Ejercicio A: Cuenta Regresiva de Memoria");
                Console.WriteLine("2. Ejercicio B: Sumatoria Recursiva Dinámica");
                Console.WriteLine("3. Salir del Programa");
                Console.Write("Selecciona una opción (1-3): ");
                
                string? opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("--- EJERCICIO A: CUENTA REGRESIVA ---");
                        int numA = Validador.LeerEnteroPositivo();
                        if (numA != -1)
                        {
                            SimuladorStack.ImprimirCuentaRegresiva(numA);
                        }
                        break;

                    case "2":
                        Console.WriteLine("--- EJERCICIO B: SUMATORIA RECURSIVA ---");
                        int numB = Validador.LeerEnteroPositivo();
                        if (numB != -1)
                        {
                            int resultado = SimuladorStack.SumarHasta(numB);
                            Console.WriteLine($"La suma de 1 hasta {numB} es: {resultado}");
                        }
                        break;

                    case "3":
                        ejecutanado = false;
                        Console.WriteLine("Saliendo de la aplicación. Siuu.");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}