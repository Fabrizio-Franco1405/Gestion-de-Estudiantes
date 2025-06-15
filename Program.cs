using System;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_de_Estudiantes
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    public class Estudiante : Persona
    {
        public int Codigo { get; set; }
        public List<int> ListaDeNotas { get; set; } = new List<int>();

        public float calcularPromedioNotas()
        {
            return (float)ListaDeNotas.Average();
        }

        public string rendimientoAcademico()
        {
            float rendimiento = calcularPromedioNotas();
            if (rendimiento >= 4.5) return "Excelente";
            else if (rendimiento >= 3.5) return "Bueno";
            else if (rendimiento >= 2.5) return "Regular";
            else return "Deficiente";
        }
    }

    class Program
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("//--------------------------------- Bienvenido al Sistema de Gestión de Estudiantes ---------------------------------//\n");
            Console.WriteLine("1. Registrar Estudiante.");
            Console.WriteLine("2. Mostrar Informes de Estudiantes.");
            Console.WriteLine("3. Salir de la aplicación.\n");

            Opciones();
        }

        static void Opciones()
        {
            Console.Write("\nElija una opción: ");

            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    registrarEstudiantes();
                    break;
                case 2:
                    mostrarInformesEstudiantes();
                    break;
                case 3:
                    Console.WriteLine("\nSaliendo del Programa...");
                    return;
                default:
                    Console.WriteLine("\nOpción no válida, intente de nuevo.");
                    Opciones();
                    break;
            }
        }

        static void registrarEstudiantes()
        {
            Console.Clear();
            string nombre = LeerNombre();
            int edad = LeerEntero("\nIngrese edad del estudiante: ", 1, 60);

            int codigo;
            do
            {
                codigo = LeerEntero("\nAsigne un código único para el Estudiante: ", 1, 99999);
                if (estudiantes.Any(e => e.Codigo == codigo))
                    Console.WriteLine("Ese código ya está registrado. Intente con otro.");
                else
                    break;
            } while (true);

            List<int> notas = LeerNotas();

            Estudiante estudiante = new Estudiante
            {
                Nombre = nombre,
                Edad = edad,
                Codigo = codigo,
                ListaDeNotas = notas
            };

            estudiantes.Add(estudiante);
            Console.WriteLine("\nEstudiante registrado exitosamente.");
            Volver();
        }
        static void mostrarInformesEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("//------------------------------ INFORME DE ESTUDIANTES ------------------------------//\n");

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados aún.");
            }
            else
            {
                foreach (var est in estudiantes)
                {
                    Console.WriteLine($"Nombre: {est.Nombre}");
                    Console.WriteLine($"Edad: {est.Edad}");
                    Console.WriteLine($"Código: {est.Codigo}");
                    Console.WriteLine($"Notas: {string.Join(", ", est.ListaDeNotas)}");
                    Console.WriteLine($"Promedio: {est.calcularPromedioNotas():0.00}");
                    Console.WriteLine($"Rendimiento: {est.rendimientoAcademico()}\n");
                    Console.WriteLine("-------------------------------------------------------------");
                }
            }

            Volver();
        }

        static void Volver()
        {
            Console.Write("\n¿Desea volver al menú de opciones? S/N: ");
            char volver = char.Parse(Console.ReadLine());

            if (char.ToUpper(volver) == 'S')
            {
                Menu();
            }
            else
            {
                Console.WriteLine("\nSaliendo del Programa...");
                return;
            }
        }

        static string LeerNombre()
        {
            string nombre;
            do
            {
                Console.Write("Ingrese nombre del Estudiante: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre) || nombre.Any(char.IsDigit))
                    Console.WriteLine("\nNombre inválido. No debe contener números.\n");
                else
                    break;

            } while (true);

            return nombre;
        }

        static int LeerEntero(string mensaje, int min = int.MinValue, int max = int.MaxValue)
        {
            int valor;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out valor) && valor >= min && valor <= max)
                    return valor;
                else
                    Console.WriteLine($"\nEntrada inválida. Ingrese un número entero entre {min} y {max}.");
            } while (true);
        }

        static List<int> LeerNotas()
        {
            List<int> notas;
            do
            {
                Console.Write("\nIngrese 3 notas separadas por espacios (entre 0 y 5): ");
                string[] entrada = Console.ReadLine().Split(' ');
                if (entrada.Length != 3)
                {
                    Console.WriteLine("\nDebe ingresar exactamente 3 notas.");
                    continue;
                }

                notas = new List<int>();
                bool validas = true;

                foreach (var s in entrada)
                {
                    if (int.TryParse(s, out int n) && n >= 0 && n <= 5)
                        notas.Add(n);
                    else
                        validas = false;
                }

                if (validas) break;
                else Console.WriteLine("\nNotas inválidas. Intente de nuevo.");
            } while (true);

            return notas;
        }
    }
}