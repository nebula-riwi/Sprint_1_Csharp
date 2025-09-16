using System;
using System.Collections.Generic;
using System.Linq;

public class libro
{
    public string titulo { get; set; }
    public string autor { get; set; }
    public int anio { get; set; }

    public List<double> Calificaciones { get; set; } = new List<double>();


    public bool disponible { get; set; } = true;
    public string categoria { get; set; }

    public override string ToString()
    {
        return $"{titulo} de {autor} ({anio}) - Categoria: {categoria} - {(disponible ? "Disponible" : "No Disponible")}";
    }
}

public class Usuario
{
    public string Nombre { get; set; }
    public string Identificacion { get; set; }
    public string Email { get; set; }

    public Usuario(string nombre, string identificacion, string email)
    {
        Nombre = nombre;
        Identificacion = identificacion;
        Email = email;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}, Identificacion: {Identificacion}, Email: {Email}");
    }
}
class BibliotecaServicios
{
    static void Main()
    {
        List<libro> libros = new List<libro>();
        List<Usuario> Usuarios = new List<Usuario>();

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
                    
                    Console.WriteLine("\n--- GESTION DE USUARIOS ---");
                    Console.WriteLine("1. Registrar usuario");
                    Console.WriteLine("2. Listar usuarios");
                    Console.Write("Selecciona una opcion: ");
                    opcion = Console.ReadLine();

                    if (opcion == "1")
                    {
                        Console.Write("Ingrese el nombre del usuario: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la identificacion del usuario: ");
                        string identificacion = Console.ReadLine();
                        Console.Write("Ingrese el correo electronico del usuario: ");
                        string email = Console.ReadLine();

                        Usuarios.Add(new Usuario(nombre, identificacion, email));
                        Console.WriteLine("Usuario registrado exitosamente.");
                    }
                    else if (opcion == "2")
                    {
                        Console.WriteLine("\n--- LISTA DE USUARIOS ---");
                        if (Usuarios.Count == 0)
                        {
                            Console.WriteLine("No hay usuarios registrados.");
                        }
                        else
                        {
                            foreach (Usuario u in Usuarios)
                            {
                                u.MostrarInfo();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida en gestion de usuarios.");
                    }
                    break;

                case "3":

                    break;

                case "4":
                    Console.WriteLine("\n--- RESEÑAS Y CALIFICACIONES ---");
                    Console.WriteLine("1. Calificar un libro");
                    Console.WriteLine("2. Ver calificación promedio de un libro");
                    Console.Write("Selecciona una opción: ");
                    string subOpcionResena = Console.ReadLine();

                    if (subOpcionResena == "1")
                    {
                        Console.Write("Ingrese el título del libro a calificar: ");
                        string tituloCalificar = Console.ReadLine();

                        // Buscamos el libro
                        libro libroACalificar = libros.FirstOrDefault(l => l.titulo.Equals(tituloCalificar, StringComparison.OrdinalIgnoreCase));

                        if (libroACalificar == null)
                        {
                            Console.WriteLine("No se encontró el libro.");
                        }
                        else
                        {
                            Console.Write("Ingrese la calificación (de 0.0 a 5.0): ");
                            if (double.TryParse(Console.ReadLine(), out double calificacion) && calificacion >= 0.0 && calificacion <= 5.0)
                            {
                                libroACalificar.Calificaciones.Add(calificacion);
                                Console.WriteLine("¡Calificación agregada exitosamente!");
                            }
                            else
                            {
                                Console.WriteLine("Calificación no válida. Debe ser un número entre 0.0 y 5.0.");
                            }
                        }
                    }
                    else if (subOpcionResena == "2")
                    {
                        Console.Write("Ingrese el título del libro para ver su calificación: ");
                        string tituloConsulta = Console.ReadLine();

                        libro libroConsultado = libros.FirstOrDefault(l => l.titulo.Equals(tituloConsulta, StringComparison.OrdinalIgnoreCase));

                        if (libroConsultado == null)
                        {
                            Console.WriteLine("No se encontró el libro.");
                        }
                        else
                        {
                            if (libroConsultado.Calificaciones.Count == 0)
                            {
                                Console.WriteLine("Este libro aún no tiene calificaciones.");
                            }
                            else
                            {
                                double promedio = libroConsultado.Calificaciones.Average();
                                Console.WriteLine($"La calificación promedio de '{libroConsultado.titulo}' es: {promedio:F1} / 5.0");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
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

