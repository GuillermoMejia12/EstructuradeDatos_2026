using System;

namespace EB7_Recursividad
{
    public static class Validador
    {
        public static int LeerEnteroPositivo()
        {
            Console.Write("Introduce un número positivo: ");
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero) && numero > 0)
            {
                return numero;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se aceptan enteros positivos.");
                Console.ResetColor();
                return -1;
            }
        }
    }
}