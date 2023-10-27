using Microsoft.VisualBasic;
using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        bool continuar = true;

        using (var context = new Context())
        {
            context.Database.EnsureCreated();

            bool agregarPersonas = false;

            while (continuar)
            {
                Console.WriteLine("************************************");
                Console.WriteLine("Opciones disponibles:");
                Console.WriteLine("************************************");
                Console.WriteLine("1. Mostrar todos los estudiantes.");
                Console.WriteLine("2. Agregar un estudiante.");
                Console.WriteLine("3. Modificar un estudiante.");
                Console.WriteLine("4. Eliminar un estudiante.");
                Console.WriteLine("5. Salir del programa.");
                Console.WriteLine("************************************");
                Console.Write("Ingrese el número de la opción que desea realizar: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MostrarEstudiantes(context);
                        break;

                    case 2:
                        do
                        {
                            AgregarEstudiante(context);
                            Console.Write("¿Desea agregar más personas? (S/N): ");
                            agregarPersonas = (Console.ReadLine().Trim().ToUpper() == "S");
                        } while (agregarPersonas);
                        break;

                    case 3:
                        do
                        {
                            ModificarEstudiante(context);
                            Console.Write("¿Desea modificar más personas? (S/N): ");
                            agregarPersonas = (Console.ReadLine().Trim().ToUpper() == "S");
                        } while (agregarPersonas);
                        break;

                    case 4:
                        do
                        {
                            EliminarEstudiante(context);
                            Console.Write("¿Desea eliminar más personas? (S/N): ");
                            agregarPersonas = (Console.ReadLine().Trim().ToUpper() == "S");
                        } while (agregarPersonas);
                        break;

                    case 5:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
 



    public static void MostrarEstudiantes(Context context)
    {
        var estudiantes = context.Estudiante.ToList();
        Console.WriteLine("Datos de todos los estudiantes:");
        foreach (var est in estudiantes)
        {
            Console.WriteLine($"ID: {est.Id}, Nombres: {est.Nombres}, Apellidos: {est.Apellidos}, Edad: {est.Edad}, Sexo: {est.Sexo}");
        }
    }


    public static void AgregarEstudiante(Context context)
    {
        Console.Write("Ingrese los nombres: ");
        string? nombres = Console.ReadLine();

        Console.Write("Ingrese los apellidos: ");
        string? apellidos = Console.ReadLine();

        Console.Write("Ingrese la edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el sexo: ");
        string? sexo = Console.ReadLine();

        var estudiante = new Estudiante { Nombres = nombres, Apellidos = apellidos, Edad = edad, Sexo = sexo };
        context.Estudiante.Add(estudiante);
        context.SaveChanges();
        Console.WriteLine("Estudiante agregado exitosamente.");
    }


    public static void ModificarEstudiante(Context context)
    {
        Console.Write("Ingrese el ID del estudiante que desea modificar: ");
        int idAModificar = int.Parse(Console.ReadLine());

        var estudianteAModificar = context.Estudiante.FirstOrDefault(e => e.Id == idAModificar);

        if (estudianteAModificar != null)
        {
            Console.WriteLine("Seleccione el atributo a modificar:");
            Console.WriteLine("1. Nombres");
            Console.WriteLine("2. Apellidos");
            Console.WriteLine("3. Edad");
            Console.WriteLine("4. Sexo");
            Console.Write("Ingrese el número de la opción deseada: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nuevo nombre: ");
                    estudianteAModificar.Nombres = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Ingrese el nuevo apellido: ");
                    estudianteAModificar.Apellidos = Console.ReadLine();
                    break;

                case 3:
                    Console.Write("Ingrese la nueva edad: ");
                    estudianteAModificar.Edad = int.Parse(Console.ReadLine());
                    break;

                case 4:
                    Console.Write("Ingrese el nuevo sexo: ");
                    estudianteAModificar.Sexo = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            context.SaveChanges();
            Console.WriteLine("Estudiante modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró un estudiante con ese ID.");
        }
    }


    public static void EliminarEstudiante(Context context)
    {
        Console.Write("Ingrese el ID del estudiante que desea eliminar: ");
        int idAEliminar = int.Parse(Console.ReadLine());

        var estudianteAEliminar = context.Estudiante.FirstOrDefault(e => e.Id == idAEliminar);

        if (estudianteAEliminar != null)
        {
            context.Estudiante.Remove(estudianteAEliminar);
            context.SaveChanges();
            Console.WriteLine("Estudiante eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró un estudiante con ese ID.");
        }
    }
}

