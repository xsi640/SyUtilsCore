using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

namespace SyUtilsCore
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            string result = string.Empty;
            FieldInfo fieldInfo = value.GetType().GetRuntimeField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            result = (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            Array.Clear(attributes, 0, attributes.Length);
            return result;
        }

        public static Dictionary<Enum, string> GetDescriptionLists<T>()
        {
            Dictionary<System.Enum, string> result = new Dictionary<Enum, string>();
            Array array = Enum.GetValues(typeof(T));
            foreach (object value in array)
            {
                string des = GetDescription((Enum)value);
                result.Add((System.Enum)value, des);
            }

            return result;
        }

        public static Dictionary<string, int> GetEnumList<T>()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Array arr = Enum.GetValues(typeof(T));
            string description = null;
            foreach (object value in arr)
            {
                description = GetDescription((Enum)value);
                dict.Add(description, (int)value);
            }
            Array.Clear(arr, 0, arr.Length);
            return dict;
        }

        public static int[] GetEnumValues<T>()
        {
            int[] array = null;
            try
            {
                array = (int[])Enum.GetValues(typeof(T));
            }
            catch
            {
                array = null;
            }
            return array;
        }
    }
}