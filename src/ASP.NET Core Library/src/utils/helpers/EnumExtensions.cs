using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Core.Libs.Utils.Helpers
{
    public static class EnumExtensions
    {
        public static string GetName<TEnum>(this TEnum e, bool isLowerCase = true)
        {
            var name = e.ToString();

            var type = e.GetType();

            var field = type.GetField(name, BindingFlags.Static | BindingFlags.Public);

            var displayAttr = field.GetCustomAttribute(typeof(DisplayAttribute), false) as DisplayAttribute;

            if (displayAttr != null && displayAttr.Name != null)
                name = displayAttr.Name;

            if (isLowerCase)
                name = name.ToLower();

            return name;
        }

        public static IDictionary<string, int> ToList<TEnum>() where TEnum : struct
        {
            var dict = new Dictionary<string, int>();

            foreach (var v in Enum.GetValues(typeof(TEnum)))
                dict.Add(v.GetName(), (int)v);

            return dict;
        }

        public static TEnum ToEnum<TEnum>(this string s) where TEnum : struct
        {
            var e = s.ToEnum(null as TEnum?);

            if (e == null)
                throw new InvalidCastException();

            return e.Value;
        }

        public static TEnum? ToEnum<TEnum>(this string s, TEnum? defaultValue) where TEnum : struct
        {
            var type = typeof(TEnum);

            foreach (var name in Enum.GetNames(type))
            {
                if (name.ToLower() == s.ToLower())
                    return (TEnum)Enum.Parse(type, name);

                var field = type.GetField(name, BindingFlags.Static | BindingFlags.Public);

                var displayAttr = field.GetCustomAttribute(typeof(DisplayAttribute), false) as DisplayAttribute;

                if (displayAttr != null && displayAttr.Name != null && displayAttr.Name.ToLower() == s.ToLower())
                    return (TEnum)Enum.Parse(type, name);
            }

            return defaultValue;
        }
        
        public static object ToEnum(this string s, Type enumType)
        {
            var type = enumType;

            foreach (var name in Enum.GetNames(type))
            {
                if (name.ToLower() == s.ToLower())
                    return Enum.Parse(type, name);

                var field = type.GetField(name, BindingFlags.Static | BindingFlags.Public);

                var displayAttr = field.GetCustomAttribute(typeof(DisplayAttribute), false) as DisplayAttribute;

                if (displayAttr != null && displayAttr.Name != null && displayAttr.Name.ToLower() == s.ToLower())
                    return Enum.Parse(type, name);
            }

            return null;
        }
    }
}