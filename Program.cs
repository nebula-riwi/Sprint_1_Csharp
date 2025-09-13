using System;
using System.Collections.Generic;
using System.Linq;

public class libro
{
    public string titulo { get; set; }
    public string autor { get; set; }
    public int anio { get; set; }
    public bool disponible { get; set; } = true;
    public string categoria { get; set; }
    public override string ToString()
    {
        return $"{titulo} de {autor} ({anio}) - Categoria: {categoria} - {(disponible ? "Disponible" : "No Disponible")}";
    }
}

class BibliotecaServicios
{
    static void Main()
    {
        List<libro> libros = new List<libro>();
        string opcion;
        string subOpcion;

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
                        subOpcion = Console.ReadLine();

                        if (subOpcion == "1")
                        {
                            Console.Write("Ingrese el título del libro: ");
                            string titulo = Console.ReadLine();
                            Console.Write("Ingrese el autor del libro: ");
                            string autor = Console.ReadLine();
                            Console.Write("Ingrese el año de publicación: ");
                            int anio = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese la categoria del libro: ");
                            string categoria = Console.ReadLine();

                            libros.Add(new libro { titulo = titulo, autor = autor, anio = anio, categoria = categoria });
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
                    // Gestión de usuarios (pendiente)
                    break;

                case "3":
                    while (true)
                    {
                        Console.WriteLine("\nPRÉSTAMOS Y DEVOLUCIONES");
                        Console.WriteLine("1. Prestar libro");
                        Console.WriteLine("2. Registrar devolución");
                        Console.WriteLine("3. Mostrar libros prestados");
                        Console.WriteLine("4. Ir al menu principal");
                        Console.Write("Selecciona una opción: ");
                        subOpcion = Console.ReadLine();

                        if (subOpcion == "1")
                        {
                            Console.Write("Ingrese el título del libro a prestar: ");
                            string titulo = Console.ReadLine();

                            var libro = libros.FirstOrDefault(l => l.titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

                            if (libro == null)
                            {
                                Console.WriteLine("El libro no está registrado en la biblioteca.");
                            }
                            else if (!libro.disponible)
                            {
                                Console.WriteLine("Ese libro ya está prestado.");
                            }
                            else
                            {
                                libro.disponible = false;
                                Console.WriteLine($"Libro '{libro.titulo}' prestado exitosamente.");
                            }
                        }
                        else if (subOpcion == "2")
                        {
                            Console.Write("Ingrese el título del libro a devolver: ");
                            string titulo = Console.ReadLine();

                            var libro = libros.FirstOrDefault(l => l.titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

                            if (libro == null)
                            {
                                Console.WriteLine("El libro no está registrado.");
                            }
                            else if (libro.disponible)
                            {
                                Console.WriteLine("Ese libro no estaba prestado.");
                            }
                            else
                            {
                                libro.disponible = true;
                                Console.WriteLine($"Libro '{libro.titulo}' devuelto correctamente.");
                            }
                        }
                        else if (subOpcion == "3")
                        {
                            var prestados = libros.Where(l => !l.disponible).ToList();

                            if (prestados.Count == 0)
                            {
                                Console.WriteLine("No hay libros prestados actualmente.");
                            }
                            else
                            {
                                Console.WriteLine("\n--- LIBROS PRESTADOS ---");
                                foreach (var l in prestados)
                                {
                                    Console.WriteLine(l);
                                }
                            }
                        }
                        else if (subOpcion == "4")
                        {
                            Console.Write("Saliendo al menu principal...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida en préstamos y devoluciones.");
                        }
                    }
                    break;

                case "4":
                    // Reseñas y calificaciones (pendiente)
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
