using System.Reflection;

namespace Reflections
{
    /// <summary>
    /// Dynamic method invoker
    /// </summary>
    internal class DynamicMethodInvoker
    {
        /// <summary>
        /// Invoke mthod
        /// </summary>
        /// <param name="obj">obj</param>
        /// <param name="methodName">method Name</param>
        /// <param name="parameters">parameters</param>
        public void InvokeMethod(object obj, string methodName, object[]? parameters = null)
        {
            if (obj == null)
            {
                Console.WriteLine("Target object is null.");
                return;
            }

            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (method != null)
            {
                Console.WriteLine($"Calling method '{method.Name}' on {type.Name}...");
                // Adjust parameters if method takes no parameters but null was passed
                var methodParams = method.GetParameters();
                if (methodParams.Length == 0)
                {
                    method.Invoke(obj, null);
                }
                else
                {
                    method.Invoke(obj, parameters);
                }
            }
            else
            {
                Console.WriteLine($"Method '{methodName}' was not found on type {type.Name}.");
            }
        }

        /// <summary>
        /// Demonstration method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("\n--- Task 3: Dynamic Method Invoker ---");
            Student student = new Student();
            DynamicMethodInvoker invoker = new DynamicMethodInvoker();

            Console.WriteLine("Available methods on SampleStudent: SayHello, DisplayDetails");
            Console.Write("Enter method name to call: ");
            string? methodName = Console.ReadLine();

            if (string.Equals(methodName, "SayHello", StringComparison.OrdinalIgnoreCase))
            {
                invoker.InvokeMethod(student, "SayHello");
            }
            else if (string.Equals(methodName, "DisplayDetails", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter message parameter: ");
                string? msg = Console.ReadLine() ?? "Default note";
                invoker.InvokeMethod(student, "DisplayDetails", new object[] { msg });
            }
            else if (!string.IsNullOrWhiteSpace(methodName))
            {
                invoker.InvokeMethod(student, methodName);
            }
        }
    }
}
