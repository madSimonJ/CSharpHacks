using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global

namespace CSharpHacks.Reflection
{
    /// <summary>
    ///     Extension methods to aid working with custom attributes.
    /// </summary>
    public static class CustomAttributeExtensions
    {
        /// <summary>
        ///     Determines whether the specified member is decorated with the given custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of custom Attribute to check for.</typeparam>
        /// <param name="member">The member to check.</param>
        /// <returns><c>true</c> if the specified member is decorated with the given custom attribute; otherwise, <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this MemberInfo member) where T : Attribute
            => member.GetCustomAttributes().OfType<T>().Any();

        /// <summary>
        ///     Determines whether the specified <see cref="Assembly"/> is decorated with the given custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of custom Attribute to check for.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <returns><c>true</c> if the specified <see cref="Assembly"/> is decorated with the given custom attribute; otherwise, <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Assembly assembly) where T : Attribute
            => assembly.GetCustomAttributes().OfType<T>().Any();

        /// <summary>
        ///     Determines whether the specified <see cref="Type"/> is decorated with the given custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of custom Attribute to check for.</typeparam>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the specified <see cref="Type"/> is decorated with the given custom attribute; otherwise, <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Type type) where T : Attribute
            => type.GetCustomAttributes().OfType<T>().Any();

        /// <summary>
        ///     Determines whether the specified member is decorated with the given custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of custom Attribute to check for.</typeparam>
        /// <param name="member">The member to check.</param>
        /// <param name="attribute">An instance of the custom Attribute that was found.</param>
        /// <returns><c>true</c> if the specified member is decorated with the given custom attribute; otherwise, <c>false</c>.</returns>
        public static bool TryGetCustomAttribute<T>(this MemberInfo member, out T attribute) where T : Attribute
        {
            var attributes = member.GetCustomAttributes().OfType<T>().ToList();
            attribute = attributes.FirstOrDefault();
            return attributes.Any();
        }

        /// <summary>
        ///     Determines whether the specified <see cref="Assembly"/> is decorated with the given custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of custom Attribute to check for.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <param name="attribute">An instance of the custom Attribute that was found.</param>
        /// <returns><c>true</c> if the specified <see cref="Assembly"/> is decorated with the given custom attribute; otherwise, <c>false</c>.</returns>
        public static bool TryGetCustomAttribute<T>(this Assembly assembly, out T attribute) where T : Attribute
        {
            var attributes = assembly.GetCustomAttributes().OfType<T>().ToList();
            attribute = attributes.FirstOrDefault();
            return attributes.Any();
        }

        /// <summary>
        ///     Determines whether the specified <see cref="Type"/> is decorated with the given custom attribute.
        /// </summary>
        /// <typeparam name="T">The type of custom Attribute to check for.</typeparam>
        /// <param name="type">The type to check.</param>
        /// <param name="attribute">An instance of the custom Attribute that was found.</param>
        /// <returns><c>true</c> if the specified <see cref="Type"/> is decorated with the given custom attribute; otherwise, <c>false</c>.</returns>
        public static bool TryGetCustomAttribute<T>(this Type type, out T attribute) where T : Attribute
        {
            var attributes = type.GetCustomAttributes().OfType<T>().ToList();
            attribute = attributes.FirstOrDefault();
            return attributes.Any();
        }

        /// <summary>
        ///     Gets the derived types of a specified Attribute, within a given assembly.
        /// </summary>
        /// <typeparam name="T">The type of class level attribute to scan for.</typeparam>
        /// <param name="attribute">The attribute to scan for.</param>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>Returns an array of Types that are decorated with the specified class level attribute.</returns>
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Extension Method")]
        public static IEnumerable<(Type Type, T Attribute)> GetDerivedTypesFromAssembly<T>(this T attribute, Assembly assembly) where T : Attribute 
            => assembly.GetTypesWithAttribute<T>();

        /// <summary>   
        ///     Gets the derived types of a specified Attribute, within the assembly.
        /// </summary>
        /// <typeparam name="T">The type of class level attribute to scan for.</typeparam>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>Returns an array of Types that are decorated with the specified class level attribute.</returns>
        public static IEnumerable<(Type Type, T Attribute)> GetTypesWithAttribute<T>(this Assembly assembly)
            where T : Attribute
        {
            return assembly.GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(T), false).Length > 0)
                .Select(p => (p, (T)p.GetCustomAttribute(typeof(T), false)));
        }
    }
}