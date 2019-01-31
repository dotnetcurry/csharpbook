using Plugins;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            NonGenericTypeInfo();
            GenericTypeInfo();
            CreateNonGenericType();
            CreateGenericType();
            InspectBaseType();
            InspectInterfaces();
            TestInheritance();
            SafelyCreatePluginInstance();
            InspectPublicMembers();
            InspectNonPublicMembers();
            InvokePropertyAccessors();
            InvokeMethod();
        }

        private static void NonGenericTypeInfo()
        {
            var text = "Sample text";

            var type = text.GetType();

            Console.WriteLine(type.FullName); // System.String
        }

        private static void GenericTypeInfo()
        {
            var dictionary = new Dictionary<int, string>();

            var type = dictionary.GetType();

            Console.WriteLine(type.FullName);

            Console.WriteLine(type.IsGenericType); // True
            Console.WriteLine(type.GenericTypeArguments.Length); // 2
            Console.WriteLine(type.GenericTypeArguments[0].FullName); // System.Int32
            Console.WriteLine(type.GenericTypeArguments[1].FullName); // System.String
        }

        private static void CreateNonGenericType()
        {
            var type = Type.GetType("System.String");
            var instance = Activator.CreateInstance(type, 'a', 5);

            Console.WriteLine(instance); // aaaaa
        }

        private static void CreateGenericType()
        {
            var typeDefinition = Type.GetType("System.Collections.Generic.Dictionary`2");
            var argumentType1 = Type.GetType("System.Int32");
            var argumentType2 = Type.GetType("System.String");
            var genericType = typeDefinition.MakeGenericType(argumentType1, argumentType2);
            var instance = Activator.CreateInstance(genericType);
        }

        private static void InspectBaseType()
        {
            var type = typeof(List<int>);
            Console.WriteLine(type.BaseType.FullName); // System.Object
        }

        private static void InspectInterfaces()
        {
            var type = typeof(List<int>);
            var interfaces = type.GetInterfaces();

            foreach (var interfaceType in interfaces)
            {
                Console.WriteLine(interfaceType.FullName);
            }
        }

        private static void TestInheritance()
        {
            var type = typeof(List<int>);
            var interfaceType = typeof(IList<int>);

            Console.WriteLine(interfaceType.IsAssignableFrom(type)); // True
        }

        private static void SafelyCreatePluginInstance()
        {
            var pluginAssemblyPath = "Plugins.dll";
            var pluginTypeName = "Plugins.CustomPlugin";

            var pluginAssembly = Assembly.LoadFrom(pluginAssemblyPath); // path read from config
            var pluginType = pluginAssembly.GetType(pluginTypeName);    // type read from config
            if (typeof(IPlugin).IsAssignableFrom(pluginType))
            {
                var pluginInstance = (IPlugin)Activator.CreateInstance(pluginType);
                // use the plugin
            }
        }

        private static void InspectPublicMembers()
        {
            var type = typeof(string);
            var members = type.GetMembers();
        }

        private static void InspectNonPublicMembers()
        {
            var type = typeof(string);
            var members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        }

        private static void InvokePropertyAccessors()
        {
            var text = "Sample text";

            var type = text.GetType();
            var property = type.GetProperty("Length");

            Console.WriteLine(property.GetValue(text)); // 11

            try
            {
                // throws System.ArgumentException : Property set method not found.
                property.SetValue(text, 10);
            }
            catch (ArgumentException)
            { }
        }

        private static void InvokeMethod()
        {
            var text = "Sample text";

            var type = text.GetType();
            var method = type.GetMethod("ToUpper", new Type[0]);

            Console.WriteLine(method.Invoke(text, new object[0])); // SAMPLE TEXT
        }
    }
}
