using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        bool agregarpersonas = true;

        using (var context = new Context())
        {
            context.Database.EnsureCreated();

            while (agregarpersonas)
            {
                Console.Write("Ingrese los nombres: ");
                string nombres = Console.ReadLine();

                Console.Write("Ingrese los apellidos: ");
                string apellidos = Console.ReadLine();


                Console.Write("Ingrese la edad: ");
                int edad = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el sexo: ");
                string sexo = Console.ReadLine();


                var estudiante = new Estudiante { Nombres = nombres, Apellidos = apellidos, Edad = edad, Sexo = sexo };
                context.Estudiante.Add(estudiante);
                context.SaveChanges();

                Console.Write("¿Desea agregar más personas? (S/N): ");
                agregarpersonas = (Console.ReadLine().Trim().ToUpper() == "S");


                var estudiantes = context.Estudiante.ToList();
                foreach (var est in estudiantes)
                {
                    Console.WriteLine($"ID: {est.Id}, Nombres: {est.Nombres},Apellidos: {est.Apellidos}, Edad: {est.Edad}, Sexo: {est.Sexo}");
                }
            }
        }

        using (var contextdb = new Context())
        {
            foreach (var student in contextdb.Estudiante)
            {
                Console.WriteLine($"ID: {student.Id}, Nombre: {student.Nombres}, Apellido: {student.Apellidos}, Sexo: {student.Sexo}, Edad: {student.Edad}");
                Console.WriteLine();
            }
        }
    }
}

