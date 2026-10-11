using System.Reflection;
using System.Reflection.Emit;

namespace Reflections
{
    /// <summary>
    /// Dynamic Type Builder
    /// </summary>
    public class DynamicTypeBuilder
    {
        /// <summary>
        /// Demonstration method
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("\n--- Task 4: Dynamic Type Builder ---");
            Console.Write("Enter the name of the new dynamic class (e.g. DynamicPerson): ");
            string className = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(className))
            {
                className = "DynamicPerson";
            }

            AssemblyName assemblyName = new AssemblyName("DynamicTypeAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

            TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class);

            FieldBuilder fieldBuilder = typeBuilder.DefineField("_description", typeof(string), FieldAttributes.Private);
            PropertyBuilder propBuilder = typeBuilder.DefineProperty("Description", PropertyAttributes.HasDefault, typeof(string), null);

            MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("get_Description",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                typeof(string), Type.EmptyTypes);
            ILGenerator getIL = getMethodBuilder.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, fieldBuilder);
            getIL.Emit(OpCodes.Ret);
            propBuilder.SetGetMethod(getMethodBuilder);

            // Setter
            MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("set_Description",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                null, new Type[] { typeof(string) });
            ILGenerator setIL = setMethodBuilder.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, fieldBuilder);
            setIL.Emit(OpCodes.Ret);
            propBuilder.SetSetMethod(setMethodBuilder);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod("PrintHello", MethodAttributes.Public, null, Type.EmptyTypes);
            ILGenerator methodIL = methodBuilder.GetILGenerator();
            methodIL.Emit(OpCodes.Ldstr, $"[Dynamic Type '{className}'] Hello from runtime created method!");
            methodIL.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) })!);
            methodIL.Emit(OpCodes.Ret);

            Type dynamicType = typeBuilder.CreateType();
            Console.WriteLine($"Successfully built type: {dynamicType.FullName}");

            object? instance = Activator.CreateInstance(dynamicType);
            PropertyInfo? prop = dynamicType.GetProperty("Description");
            prop?.SetValue(instance, "Runtime Property Value");

            Console.WriteLine($"Property Description Value: {prop?.GetValue(instance)}");

            MethodInfo? method = dynamicType.GetMethod("PrintHello");
            method?.Invoke(instance, null);
        }
    }
}
