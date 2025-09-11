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
        return $"{titulo} De {autor} Fecha de publicacion: {anio}";
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
                    while (true)
                    {
                        Console.WriteLine("\nLIBROS");
                        Console.WriteLine("1. Registrar libro");
                        Console.WriteLine("2. Listar libros");
                        Console.WriteLine("3. Buscar libro");
                        Console.WriteLine("4. Ir al menu principal");
                        Console.Write("Selecciona una opción: ");
                        string subOpcion = Console.ReadLine();

                        if (subOpcion == "1")
                        {

                            Console.Write("Ingrese el título del libro: ");
                            string titulo = Console.ReadLine();
                            Console.Write("Ingrese el autor del libro: ");
                            string autor = Console.ReadLine();
                            Console.Write("Ingrese el año de publicación: ");
                            int anio = int.Parse(Console.ReadLine());

                            libros.Add(new libro { titulo = titulo, autor = autor, anio = anio });
                            Console.WriteLine($"Libro '{titulo}' de {autor} ({anio}) registrado exitosamente.");
                        }
                        else if (subOpcion == "2")
                        {
                            if (libros.Count == 0)
                            {
                                Console.WriteLine("No hay libros registrados.");
                            }
                            else
                            {
                                Console.WriteLine("\nLISTADO DE LIBROS");
                                foreach (var l in libros)
                                {
                                    Console.WriteLine(l);
                                }
                            }
                        }
                        else if (subOpcion == "3")
                        {
                            Console.Write("Ingrese el título del libro a buscar: ");
                            string tituloBuscar = Console.ReadLine();

                            var encontrados = libros
                                .Where(l => l.titulo.Equals(tituloBuscar, StringComparison.OrdinalIgnoreCase))
                                .ToList();

                            if (encontrados.Count == 0)
                            {
                                Console.WriteLine("No se encontró el libro.");
                            }
                            else
                            {
                                Console.WriteLine("\nRESULTADOS");
                                foreach (var l in encontrados)
                                {
                                    Console.WriteLine(l);
                                }
                            }
                        }
                        else if (subOpcion == "4")
                        {
                            Console.Write("Saliendo al menu principal ");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida en gestión de libros.");
                        }
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
