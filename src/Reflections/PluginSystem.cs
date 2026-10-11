using System.Reflection;

namespace Reflections
{
    /// <summary>
    /// Plugin system
    /// </summary>
    internal class PluginSystem
    {
        /// <summary>
        /// Demonstratrion method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("\n--- Task 5: Plugin System ---");
            Console.WriteLine("Plugin interface: IPlugin (Name, Execute())");
            Console.WriteLine("Enter path to a plugin assembly .dll (or press Enter to discover and load plugins from current assembly):");
            string? path = Console.ReadLine();

            Assembly pluginAssembly;
            if (string.IsNullOrWhiteSpace(path))
            {
                pluginAssembly = Assembly.GetExecutingAssembly();
                Console.WriteLine($"Loading plugins from current assembly: {pluginAssembly.GetName().Name}");
            }
            else
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("Assembly file not found! Falling back to current assembly.");
                    pluginAssembly = Assembly.GetExecutingAssembly();
                }
                else
                {
                    pluginAssembly = Assembly.LoadFile(Path.GetFullPath(path));
                }
            }

            int count = 0;
            foreach (Type type in pluginAssembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    count++;
                    Console.WriteLine($"\nDiscovered Plugin: {type.FullName}");

                    IPlugin? plugin = Activator.CreateInstance(type) as IPlugin;
                    if (plugin != null)
                    {
                        Console.WriteLine($"Plugin Name: {plugin.Name}");
                        Console.WriteLine("Invoking plugin Execute() method:");
                        plugin.Execute();
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No plugins implementing IPlugin were found.");
            }
        }
    }
}
