using System;

namespace EntregableBimestral6
{
    // Módulo 3: Definición de la clase Alumno para la demostración de referencias
    class Alumno
    {
        public string Nombre { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INICIO DE LA PRÁCTICA 6 ===\n");

            // --- EJECUCIÓN MÓDULO 1: Modificador ref ---
            Console.WriteLine("--- Módulo 1: El Modificador ref en Acción ---");
            int x = 10, y = 25;
            Console.WriteLine($"Antes del intercambio: x = {x}, y = {y}");
            
            // Se pasa la dirección de memoria usando ref
            Intercambiar(ref x, ref y);
            Console.WriteLine($"Después del intercambio: x = {x}, y = {y}\n");


            // --- EJECUCIÓN MÓDULO 2: Modificador out ---
            Console.WriteLine("--- Módulo 2: El Modificador out (Promesa del Compilador) ---");
            int dividendo = 17;
            int divisor = 5;
            
            // La variable resto no requiere inicialización previa debido a 'out'
            int cociente = CalcularYValidar(dividendo, divisor, out int resto);
            Console.WriteLine($"Dividendo: {dividendo}, Divisor: {divisor}");
            Console.WriteLine($"Cociente: {cociente}");
            Console.WriteLine($"Residuo (out): {resto}\n");


            // --- EJECUCIÓN MÓDULO 3: Referencias de Objetos ---
            Console.WriteLine("--- Módulo 3: Demostración de Referencias de Objetos ---");
            // Se crea el primer objeto en el Heap
            Alumno alumno1 = new Alumno { Nombre = "Dany" };
            // alumno2 copia la dirección de memoria de alumno1 (apuntan al mismo objeto)
            Alumno alumno2 = alumno1;
            
            Console.WriteLine($"Nombre original de alumno1: {alumno1.Nombre}");
            
            // Modificamos a través de la segunda variable
            alumno2.Nombre = "3Treum";
            
            Console.WriteLine("Se modificó alumno2.Nombre a '3Treum'...");
            Console.WriteLine($"Nombre final de alumno1: {alumno1.Nombre} (Demuestra que comparten memoria)\n");

            Console.WriteLine("=== FIN DE LA PRÁCTICA 6 ===");
        }

        // Módulo 1: Intercambio de variables directamente en memoria
        static void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Módulo 2: Retorno múltiple mediante valor convencional y parámetro out
        static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            residuo = dividendo % divisor; // Obligatorio asignar antes de salir
            return dividendo / divisor;
        }
    }
}