using System;
using System.Collections.Generic;
using System.Linq; // Requerido para utilizar los operadores de LINQ

namespace EB3
{
    // ==========================================
    // PASO 2: MODELO DE DATOS - LA CLASE PRODUCTO
    // ==========================================
    public class Producto
    {
        // Propiedades automáticas (Auto-properties)
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        // Constructor explícito para facilitar la instanciación rápida
        public Producto(int id, string nombre, double precio, int cantidad)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // Sobreescritura de ToString() para dar formato legible en consola
        public override string ToString()
        {
            return $"[{ID}] {Nombre} - ${Precio:F2} | Stock: {Cantidad}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE INVENTARIO ===\n");

            // ==========================================
            // PASO 3: CONSTRUYENDO EL INVENTARIO CON List<T>
            // ==========================================
            
            // Sintaxis 1: Inicializador de colección (Primeras 5 existencias requeridas)
            List<Producto> inventario = new List<Producto>
            {
                new Producto(1, "Laptop Lenovo", 15999.00, 10),
                new Producto(2, "Mouse Inalámbrico", 349.00, 25),
                new Producto(3, "Teclado Mecánico", 899.00, 0),
                new Producto(4, "Monitor 24\"", 4500.00, 5),
                new Producto(5, "Audífonos Sony", 1200.00, 0)
            };

            // Sintaxis 2: Agregar elementos después de instanciar la lista usando .Add()
            inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

            // Sintaxis 3: Inferencia de tipos con 'var' agregando un objeto secundario
            var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
            inventario.Add(otroProducto);

            // Desplegar la cantidad total actual en el almacenamiento dinámico
            Console.WriteLine($"Total de productos registrados en lista: {inventario.Count}\n");


            // ==========================================
            // PASO 4: CONSULTAS LINQ - FILTRANDO Y ORDENANDO
            // ==========================================

            // Consulta 1: Ordenar productos por precio de forma descendente (Mayor a Menor)
            var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
            
            Console.WriteLine("=== Productos ordenados por Precio (Descendente) ===");
            foreach (var p in porPrecio)
            {
                Console.WriteLine(p); // Llama automáticamente al método ToString() sobreescrito
            }
            Console.WriteLine();

            // Consulta 2: Filtrar únicamente los productos que se encuentran agotados (Cantidad == 0)
            var agotados = inventario.Where(p => p.Cantidad == 0).ToList();

            Console.WriteLine("=== Productos Agotados ===");
            if (agotados.Count == 0)
            {
                Console.WriteLine("No se encontraron productos agotados en el inventario actual.");
            }
            else
            {
                // Uso de ForEach nativo de List<T> para imprimir de forma compacta
                agotados.ForEach(p => Console.WriteLine(p));
            }
            Console.WriteLine();


            // ==========================================
            // PASO 5: BÚSQUEDA INSTANTÁNEA CON Dictionary<K,V>
            // ==========================================

            // Conversión directa de la lista en una Tabla Hash indexada por el ID único
            Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

            // Ejecución del método interactivo de búsqueda
            BuscarPorID(catalogo);
        }

        /// <summary>
        /// Realiza una búsqueda optimizada de tiempo O(1) usando la tabla de dispersión del diccionario.
        /// </summary>
        static void BuscarPorID(Dictionary<int, Producto> catalogo)
        {
            Console.WriteLine("=== Módulo de Búsqueda de Productos ===");
            Console.Write("Ingresa el ID numérico del producto a buscar: ");
            
            string entrada = Console.ReadLine();
            
            // Validación de parseo numérico para evitar excepciones por entradas inválidas
            if (int.TryParse(entrada, out int idBuscado))
            {
                // Uso de TryGetValue para evitar lanzar excepciones si la llave no existe en la tabla hash
                if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
                {
                    Console.WriteLine($"\n[ÉXITO] Producto localizado en tiempo O(1):");
                    Console.WriteLine($" -> {encontrado}\n");
                }
                else
                {
                    Console.WriteLine($"\n[ERROR] El ID {idBuscado} no corresponde a ningún artículo en existencia.\n");
                }
            }
            else
            {
                Console.WriteLine("\n[ERROR] Entrada inválida. Debes ingresar un número entero válido.\n");
            }
        }
    }
}