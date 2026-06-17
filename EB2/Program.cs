using System;

namespace PracticaMemoria
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- CONFIGURACIÓN DE VALORES INICIALES ---
            int numeroOriginal = 25;
            int[] miArregloOriginal = { 10, 20, 30 };

            Console.WriteLine("=== ESTADO INICIAL ===");
            Console.WriteLine($"Variable tipo int (Value Type): {numeroOriginal}");
            Console.WriteLine($"Arreglo tipo int[] (Reference Type) - Primer elemento: {miArregloOriginal[0]}");
            Console.WriteLine("--------------------------------------------------\n");

            // --- PRUEBA 1: PASO POR VALOR (STACK) ---
            Console.WriteLine("--- Ejecutando CambiarValor(int x) ---");
            CambiarValor(numeroOriginal);
            Console.WriteLine($"Resultado DESPUÉS de la función -> int original: {numeroOriginal}");
            Console.WriteLine("Nota: El valor NO cambió en el Main porque se modificó una copia en el Stack.\n");

            // --- PRUEBA 2: PASO POR REFERENCIA (HEAP) ---
            Console.WriteLine("--- Ejecutando CambiarReferencia(int[] arr) ---");
            CambiarReferencia(miArregloOriginal);
            Console.WriteLine($"Resultado DESPUÉS de la función -> Arreglo[0] original: {miArregloOriginal[0]}");
            Console.WriteLine("Nota: El valor SÍ cambió en el Main porque la función operó sobre la dirección del Heap.\n");
            
            Console.WriteLine("=== PRÁCTICA COMPLETADA CON ÉXITO ===");
        }

        // 1. Intenta cambiar el valor de un entero a 100
        static void CambiarValor(int x)
        {
            Console.WriteLine($"   [Dentro de CambiarValor] Valor recibido: {x}");
            x = 100;
            Console.WriteLine($"   [Dentro de CambiarValor] Valor modificado internamente a: {x}");
        }

        // 2. Intenta cambiar el primer elemento de un arreglo a 100
        static void CambiarReferencia(int[] arr)
        {
            Console.WriteLine($"   [Dentro de CambiarReferencia] Primer elemento recibido: {arr[0]}");
            arr[0] = 100;
            Console.WriteLine($"   [Dentro de CambiarReferencia] Primer elemento modificado internamente a: {arr[0]}");
        }
    }
}