using System;

namespace EB7_Recursividad
{
    public static class SimuladorStack
    {
        public static void ImprimirCuentaRegresiva(int numero)
        {
            if (numero < 1)
            {
                Console.WriteLine("¡Despegue!");
                return;
            }

            Console.WriteLine($"[APILANDO] Marco actual: {numero}");

            ImprimirCuentaRegresiva(numero - 1);

            Console.WriteLine($"[LIBERANDO] Marco de activación de la función: {numero}");
        }

        public static int SumarHasta(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            Console.WriteLine($"[APILANDO] SumarHasta({n}) -> Esperando que se resuelva SumarHasta({n - 1})");

            return n + SumarHasta(n - 1);
        }
    }
}