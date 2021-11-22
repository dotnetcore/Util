using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RazorEngineCore
{
    public static class ObjectExtenders
    {
        public static ExpandoObject ToExpando(this object obj)
        {
            ExpandoObject expando = new ExpandoObject();
            IDictionary<string, object> dictionary = expando;

            foreach (var property in obj.GetType().GetProperties())
            {
                dictionary.Add(property.Name, property.GetValue(obj));
            }

            return expando;
        }

        public static bool IsAnonymous(this object obj)
        {
            Type type = obj.GetType();

            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && type.Name.Contains("AnonymousType")
                   && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                   && type.Attributes.HasFlag(TypeAttributes.NotPublic);
        }
    }
}