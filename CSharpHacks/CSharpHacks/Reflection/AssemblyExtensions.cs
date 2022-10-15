using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpHacks.Reflection
{
    /// <summary>
    ///     Extension methods to aid reflecting upon assemblies, and their types.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        ///     Gets a collection of all types implementing a specified open generic interface, within a given assembly.
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <param name="openGenericType">Type of the open generic.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(this Assembly assembly, Type openGenericType) =>
            assembly.GetTypes()
                .SelectMany(types => types.GetInterfaces(), (types, interfaces) => new { Types = types, Interfaces = interfaces })
                .Select(t => new { TypeWrapper = t, t.Types.BaseType })
                .Where(t =>
                    t.BaseType is { IsGenericType: true } &&
                    openGenericType.IsAssignableFrom(t.BaseType.GetGenericTypeDefinition()) ||
                    t.TypeWrapper.Interfaces.IsGenericType &&
                    openGenericType.IsAssignableFrom(t.TypeWrapper.Interfaces.GetGenericTypeDefinition()))
                .Select(t => t.TypeWrapper.Types);


        /// <summary>
        ///     Scans an assembly for all instantiable classes of a specified type, and forms an array of instances.
        /// </summary>
        /// <typeparam name="T">The type of class to find.</typeparam>
        /// <param name="assembly">The assembly to scan.</param>
        /// <param name="constructorArgs">The constructor arguments to pass to each instance.</param>
        /// <returns>An array of instantiated classes of a specified type.</returns>
        public static IEnumerable<T> InstantiateAllTypes<T>(this Assembly assembly, params object[] constructorArgs)
            where T : class
        {
            var objects = assembly
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .Select(type => (T)Activator.CreateInstance(type, constructorArgs))
                .ToList();
            objects.Sort();

            return objects;
        }
    }
}
