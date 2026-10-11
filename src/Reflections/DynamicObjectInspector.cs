using System.Reflection;

namespace Reflections
{
    /// <summary>
    /// Dynamic Object inspector
    /// </summary>
    internal class DynamicObjectInspector
    {
        /// <summary>
        /// Inspect method
        /// </summary>
        /// <param name="obj">obj</param>
        public void Inspect(object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Object is null.");
                return;
            }

            Type type = obj.GetType();
            Console.WriteLine($"\nInspecting Object of Type: {type.Name}");
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                object? value = prop.GetValue(obj);
                Console.WriteLine($"  Property: {prop.Name} ({prop.PropertyType.Name}) = {value}");
            }
        }

        /// <summary>
        /// Sets value for the property
        /// </summary>
        /// <param name="obj">obj</param>
        /// <param name="propertyName">propertyname</param>
        /// <param name="newValue">value</param>
        public void SetPropertyValue(object obj, string propertyName, object newValue)
        {
            if (obj == null)
            {
                return;
            }

            Type type = obj.GetType();
            PropertyInfo? prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (prop != null && prop.CanWrite)
            {
                // Convert type safely to target property type
                object convertedValue = Convert.ChangeType(newValue, prop.PropertyType);
                prop.SetValue(obj, convertedValue);
                Console.WriteLine($"Successfully updated '{prop.Name}' to '{convertedValue}'.");
            }
            else
            {
                Console.WriteLine($"Property '{propertyName}' not found or cannot be written.");
            }
        }

        /// <summary>
        /// Demonstration method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("\n--- Task 2: Dynamic Object Inspector ---");
            Student student = new Student();
            DynamicObjectInspector inspector = new DynamicObjectInspector();

            Console.WriteLine("Initial values:");
            inspector.Inspect(student);

            Console.WriteLine("\nModifying properties at runtime using Reflection...");
            Console.Write("Enter property name to modify (e.g. Name, Age, Grade): ");
            string? propName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(propName))
            {
                Console.Write("Enter new value: ");
                string? propValue = Console.ReadLine() ?? "";

                inspector.SetPropertyValue(student, propName, propValue);

                Console.WriteLine("\nObject values after update:");
                inspector.Inspect(student);
            }
        }
    }
}
