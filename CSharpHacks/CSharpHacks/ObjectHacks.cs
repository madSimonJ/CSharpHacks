using System;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace CSharpHacks
{
    public static class ObjectHacks
    {
        /// <summary>
        ///     ExtendedData for the <see cref="DynamicProperties"/> extension method.
        /// </summary>
        private static readonly ConditionalWeakTable<object, object> ExtendedData = new();

        public static T Also<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }

        /// <summary>
        ///     Gets a dynamic collection of properties associated with an object instance, with a lifetime scoped to the lifetime of the object.
        /// </summary>
        /// <param name="obj">The object the properties are associated with.</param>
        /// <returns>A dynamic collection of properties associated with an object instance.</returns>
        public static dynamic DynamicProperties(this object obj) 
            => ExtendedData.GetValue(obj, _ => new ExpandoObject());

        /// <summary>
        ///     Directly casts the object instance to a specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to cast to.</typeparam>
        /// <param name="obj">The instance to cast.</param>
        /// <returns>An instance of Type <typeparamref name="T" />.</returns>
        public static T To<T>(this object obj)
            => Type.GetTypeCode(typeof(T)) is TypeCode.DateTime or TypeCode.DBNull or TypeCode.Empty
                ? throw new ArgumentOutOfRangeException(nameof(T),
                    "Objects of this TypeCode cannot be cast to, dynamically.")
                : (T)obj;

        /// <summary>
        ///     Safely casts the object instance to a specified type.
        /// </summary>
        /// <typeparam name="TFromType">The type of object to cast from.</typeparam>
        /// <typeparam name="TToType">The type of object to cast to.</typeparam>
        /// <param name="obj">The instance to cast.</param>
        /// <returns>An instance of Type <typeparamref name="TToType" />.</returns>
        public static TToType As<TFromType, TToType>(this TFromType obj) where TToType: class
            => Type.GetTypeCode(typeof(TToType)) is TypeCode.DateTime or TypeCode.DBNull or TypeCode.Empty
                ? throw new ArgumentOutOfRangeException(nameof(TToType),
                    "Objects of this TypeCode cannot be cast to, dynamically.")
                : obj as TToType;
    }
}
