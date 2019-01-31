using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ReflectionDangers
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginsPath = ".";

            var pluggables = new List<Type>();
            var pluggableInterface = typeof(IPluggable);

            var pluginsDir = new DirectoryInfo(pluginsPath);
            var files = pluginsDir.GetFiles();

            foreach (var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFile(file.FullName);
                    var types = assembly.GetTypes();
                    var pluggableTypes = types.Where(type => type.IsClass && !type.IsAbstract && pluggableInterface.IsAssignableFrom(type)).ToList();
                    pluggables.AddRange(pluggableTypes);
                }
                catch (Exception e)
                {
                    // log errors
                }
            }

            foreach (var pluggable in pluggables)
            {
                Console.WriteLine(pluggable.FullName);
            }

            var selectedPluggable = pluggables[0];

            var instance = (IPluggable)Activator.CreateInstance(selectedPluggable);
            Console.WriteLine(instance.GetString());
        }
    }
}
