using System;

namespace RecursividadApp
{
    class Program
    {
        static void Main(string[] sender)
        {
            Console.WriteLine("=== PRÁCTICA 4: RECURSIVIDAD EN C# ===");
            
            // Bloque try-catch para captura global de errores de argumento o desbordamiento
            try
            {
                // ---- PRUEBA 1: FACTORIAL ----
                int numeroFactorial = 5;
                Console.WriteLine($"\n[Evaluando Factorial para n = {numeroFactorial}]");
                long resultadoFactorial = CalcularFactorial(numeroFactorial);
                Console.WriteLine($"Resultado de {numeroFactorial}! = {resultadoFactorial}");

                // ---- PRUEBA 2: FIBONACCI ----
                int numeroFibonacci = 6;
                Console.WriteLine($"\n[Evaluando Fibonacci para n = {numeroFibonacci}]");
                long resultadoFibonacci = GenerarFibonacci(numeroFibonacci);
                Console.WriteLine($"El término {numeroFibonacci} de la serie de Fibonacci es: {resultadoFibonacci}");

                // ---- PRUEBA 3: VALIDACIÓN DE ERRORES (Entrada Negativa) ----
                Console.WriteLine("\n[Prueba de Control: Enviando un parámetro inválido (-3)]");
                // Esto disparará la excepción y saltará directamente al bloque catch
                CalcularFactorial(-3); 
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error de Validación Controlado: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error Inesperado: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\n=========================================");
            Console.WriteLine("Presiona cualquier tecla para salir...");
        }

        /// <summary>
        /// Calcula el factorial de un número de forma recursiva.
        /// </summary>
        /// <param name="n">Número entero no negativo.</param>
        /// <returns>El factorial de n.</returns>
        /// <exception cref="ArgumentException">Se lanza si el número es negativo.</exception>
        static long CalcularFactorial(int n)
        {
            // Validación de entrada para evitar ciclos infinitos en el Call Stack
            if (n < 0)
            {
                throw new ArgumentException("El número no puede ser negativo para calcular el factorial.");
            }

            // CASO BASE: 0! = 1 y 1! = 1
            if (n == 0 || n == 1)
            {
                return 1;
            }

            // CASO RECURSIVO
            return n * CalcularFactorial(n - 1);
        }

        /// <summary>
        /// Genera el n-ésimo término de la sucesión de Fibonacci de forma recursiva.
        /// </summary>
        /// <param name="n">Posición de la serie (basado en índice 0).</param>
        /// <returns>El valor numérico en la posición n.</returns>
        /// <exception cref="ArgumentException">Se lanza si la posición es negativa.</exception>
        static long GenerarFibonacci(int n)
        {
            // Validación de entrada
            if (n < 0)
            {
                throw new ArgumentException("La posición en la serie de Fibonacci no puede ser negativa.");
            }

            // CASOS BASE: F(0) = 0, F(1) = 1
            if (n == 0) return 0;
            if (n == 1) return 1;

            // CASO RECURSIVO
            return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
        }
    }
}