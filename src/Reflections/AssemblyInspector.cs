using System.Reflection;

namespace Reflections
{
    /// <summary>
    /// Assembly inspector class
    /// </summary>
    public class AssemblyInspector
    {
        /// <summary>
        /// Demonstration method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Enter the assembly file path (or press Enter to inspect the current running assembly):");
            string? inputPath = Console.ReadLine();

            Assembly assembly;
            if (string.IsNullOrWhiteSpace(inputPath))
            {
                assembly = Assembly.GetExecutingAssembly();
                Console.WriteLine($"Using current assembly: {assembly.Location}");
            }
            else
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("File not found! Loading current executing assembly instead.");
                    assembly = Assembly.GetExecutingAssembly();
                }
                else
                {
                    assembly = Assembly.LoadFile(Path.GetFullPath(inputPath));
                }
            }

            Console.WriteLine($"\nAssembly Full Name: {assembly.FullName}");
            Type[] types = assembly.GetTypes();
            Console.WriteLine($"Total Types Found: {types.Length}\n");

            foreach (Type type in types)
            {
                Console.WriteLine($"Type: {type.FullName} ({type.Attributes})");

                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
                Console.WriteLine($"  Methods ({methods.Length}):");
                foreach (var method in methods)
                {
                    Console.WriteLine($"    - {method.ReturnType.Name} {method.Name}()");
                }

                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
                Console.WriteLine($"  Properties ({properties.Length}):");
                foreach (var prop in properties)
                {
                    Console.WriteLine($"    - {prop.PropertyType.Name} {prop.Name}");
                }

                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
                Console.WriteLine($"  Fields ({fields.Length}):");
                foreach (var field in fields)
                {
                    Console.WriteLine($"    - {field.FieldType.Name} {field.Name}");
                }

                EventInfo[] events = type.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
                Console.WriteLine($"  Events ({events.Length}):");
                foreach (var ev in events)
                {
                    Console.WriteLine($"    - {ev.EventHandlerType?.Name} {ev.Name}");
                }

                Console.WriteLine();
            }
        }
    }
}
