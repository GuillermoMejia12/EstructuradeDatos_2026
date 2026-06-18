using System;

namespace EB5_ArbolesBinarios
{
    // ==========================================
    // EL MODELO DE DATOS: LA CLASE NODO
    // ==========================================
    public class Nodo
    {
        // Identificador único para ordenar el árbol
        public int ID { get; set; }

        // Información que almacena el nodo
        public string Dato { get; set; } = string.Empty;

        // Referencias recursivas a los hijos (pueden ser null si es un nodo hoja)
        public Nodo? HijoIzquierdo { get; set; }
        public Nodo? HijoDerecho { get; set; }

        // Constructor básico
        public Nodo(int id, string dato)
        {
            ID = id;
            Dato = dato;
        }
    }

    // ==========================================
    // CLASE PRINCIPAL DEL PROGRAMA
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Practica 5: Estructura de Datos - Arboles Binarios ===");
            
            // Inicializamos la raíz del árbol como null
            Nodo? raiz = null;

            // 1. Inserción de nodos (Datos de prueba para verificar el flujo)
            Console.WriteLine("\n[+] Insertando nodos en el arbol...");
            raiz = InsertarNodo(raiz, new Nodo(5, "Nodo Raiz (5)"));
            raiz = InsertarNodo(raiz, new Nodo(3, "Nodo Izquierdo (3)"));
            raiz = InsertarNodo(raiz, new Nodo(7, "Nodo Derecho (7)"));
            raiz = InsertarNodo(raiz, new Nodo(2, "Nodo Hijo Menor (2)"));
            raiz = InsertarNodo(raiz, new Nodo(4, "Nodo Hijo Medio (4)"));

            Console.WriteLine("-> Insercion completada de manera exitosa.");

            // 2. Verificación mediante Búsquedas (Casos de éxito y fallo)
            Console.WriteLine("\n[?] Realizando busquedas en el BST (Eficiencia O(log n)):");
            
            // Caso de éxito 1
            ProcesarBusqueda(raiz, 3);
            // Caso de éxito 2
            ProcesarBusqueda(raiz, 7);
            // Caso de éxito 3 (En profundidad menor)
            ProcesarBusqueda(raiz, 4);
            // Caso de fallo (No existe en el árbol)
            ProcesarBusqueda(raiz, 10);
            
            Console.WriteLine("\n========================================================");
        }

        // ==========================================
        // IMPLEMENTACIÓN: INSERTAR NODO RECURSIVO
        // ==========================================
        public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
        {
            // CASO BASE: posición vacía encontrada. Colocamos el nuevo nodo aquí.
            if (raiz == null)
            {
                return nuevoNodo;
            }

            // CASO RECURSIVO: decidir la dirección según el ID
            if (nuevoNodo.ID < raiz.ID)
            {
                // El nuevo nodo es menor -> va al subárbol izquierdo
                raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
            }
            else if (nuevoNodo.ID > raiz.ID)
            {
                // El nuevo nodo es mayor -> va al subárbol derecho
                raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
            }
            // Si nuevoNodo.ID == raiz.ID, el nodo ya existe (se ignora para evitar duplicados)

            return raiz; // Devolvemos la raíz actualizada en cada retorno de la pila
        }

        // ==========================================
        // IMPLEMENTACIÓN: BUSCAR NODO RECURSIVO
        // ==========================================
        public static string? BuscarNodo(Nodo? raiz, int idTarget)
        {
            // CASO BASE 1: Posición vacía (El nodo no existe en el árbol)
            if (raiz == null)
            {
                return null;
            }

            // CASO BASE 2: ¡Encontrado! El ID coincide con el objetivo
            if (idTarget == raiz.ID)
            {
                return raiz.Dato;
            }

            // CASO RECURSIVO: decidir dirección descartando la mitad del árbol restante
            if (idTarget < raiz.ID)
            {
                // El target es menor -> busca únicamente a la izquierda
                return BuscarNodo(raiz.HijoIzquierdo, idTarget);
            }
            else
            {
                // El target es mayor -> busca únicamente a la derecha
                return BuscarNodo(raiz.HijoDerecho, idTarget);
            }
        }

        // Método auxiliar para imprimir los resultados en consola limpiamente
        private static void ProcesarBusqueda(Nodo? raiz, int idTarget)
        {
            string? resultado = BuscarNodo(raiz, idTarget);
            if (resultado != null)
            {
                Console.WriteLine($"   ID {idTarget} -> ENCONTRADO. Dato: '{resultado}'");
            }
            else
            {
                Console.WriteLine($"   ID {idTarget} -> NOT FOUND (No existe en el arbol).");
            }
        }
    }
}