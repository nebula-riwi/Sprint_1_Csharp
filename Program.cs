using System;
using System.Collections.Generic;
using System.Linq;

public class libro
{
    public string titulo { get; set; }
    public string autor { get; set; }
    public int anio { get; set; }

    public override string ToString()
    {
        return $"{titulo} by {autor}, {anio}";
    }


}
class BibliotecaServicios
{
    static void Main()
    {
        List<libro> libros = new List<libro>();

        string opcion;

        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Gestión de Libros");
            Console.WriteLine("2. Gestión de Usuarios");
            Console.WriteLine("3. Préstamos y Devoluciones");
            Console.WriteLine("4. Reseñas y Calificaciones");
            Console.WriteLine("5. Estadísticas");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":

                    Console.WriteLine("\n--- LIBROS ---");
                    Console.WriteLine("1. Registrar libro");
                    Console.WriteLine("2. Listar libro");
                    Console.WriteLine("3. Buscar libro");
                    Console.Write("Selecciona una opción: ");
                    opcion = Console.ReadLine();
                    if (opcion == "1")
                    {
                        Console.Write("Ingrese el título del libro: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese el autor del libro: ");
                        string autor = Console.ReadLine();
                        Console.Write("Ingrese el año de publicación: ");
                        int anio = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Libro '{titulo}' de {autor} ({anio}) registrado exitosamente.");
                        libros.Add(new libro { titulo = titulo, autor = autor, anio = anio });
                    }
                    else if (opcion == "2")
                    {
                        Console.WriteLine("Listado de libros (simulado).");
                    }
                    else if (opcion == "3")
                    {
                        Console.Write("Ingrese el título del libro a buscar: ");
                        string tituloBuscar = Console.ReadLine();
                        Console.WriteLine($"Búsqueda de libro '{tituloBuscar}' (simulado).");
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida en gestión de libros.");
                    }
                    break;


                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":
                    Console.WriteLine(" Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine(" Opción no válida. Intenta de nuevo.");
                    break;
            }

        } while (opcion != "5");
    }
}
