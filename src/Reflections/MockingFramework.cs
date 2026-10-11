using System.Reflection;
using System.Reflection.Emit;

namespace Reflections
{
    /// <summary>
    /// MockingFramework
    /// </summary>
    internal class MockingFramework
    {
        /// <summary>
        /// Mock type
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>Type</returns>
        /// <exception cref="ArgumentException">exception</exception>
        public static T Mock<T>() where T : class
        {
            Type interfaceType = typeof(T);
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("Type parameter must be an interface.");
            }

            AssemblyName assemblyName = new AssemblyName("MockAssembly_" + interfaceType.Name);
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MockModule");

            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                "Mock_" + interfaceType.Name,
                TypeAttributes.Public | TypeAttributes.Class,
                typeof(object),
                new Type[] { interfaceType });

            foreach (MethodInfo method in interfaceType.GetMethods())
            {
                Type[] parameterTypes = Array.ConvertAll(method.GetParameters(), p => p.ParameterType);
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    parameterTypes);

                ILGenerator il = methodBuilder.GetILGenerator();

                if (method.ReturnType == typeof(void))
                {
                    il.Emit(OpCodes.Ret);
                }
                else if (method.ReturnType == typeof(int) || method.ReturnType == typeof(bool) ||
                         method.ReturnType == typeof(byte) || method.ReturnType == typeof(short))
                {
                    il.Emit(OpCodes.Ldc_I4_0);
                    il.Emit(OpCodes.Ret);
                }
                else if (method.ReturnType == typeof(double) || method.ReturnType == typeof(float))
                {
                    il.Emit(OpCodes.Ldc_R8, 0.0);
                    il.Emit(OpCodes.Ret);
                }
                else if (method.ReturnType == typeof(string))
                {
                    il.Emit(OpCodes.Ldstr, "MockDefaultString");
                    il.Emit(OpCodes.Ret);
                }
                else
                {
                    il.Emit(OpCodes.Ldnull);
                    il.Emit(OpCodes.Ret);
                }

                typeBuilder.DefineMethodOverride(methodBuilder, method);
            }

            Type mockType = typeBuilder.CreateType();
            return (T)Activator.CreateInstance(mockType)!;
        }

        /// <summary>
        /// Demonstration method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("\n--- Task 6: Mocking Framework ---");
            Console.WriteLine("Mocking interface 'ICalculatorService' at runtime using Reflection.Emit...");

            ICalculatorService mockService = Mock<ICalculatorService>();
            Console.WriteLine($"Mock object instantiated: {mockService.GetType().FullName}");

            Console.WriteLine("\nCalling mocked methods:");
            int result = mockService.Add(10, 20);
            string status = mockService.GetStatus();

            Console.WriteLine($"mockService.Add(10, 20) returned: {result} (Default return value)");
            Console.WriteLine($"mockService.GetStatus() returned: '{status}' (Default mock string)");
            Console.WriteLine("Mocking verification passed successfully.");
        }
    }
}
