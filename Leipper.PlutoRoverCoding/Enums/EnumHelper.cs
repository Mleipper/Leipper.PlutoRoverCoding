using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Leipper.PlutoRoverCoding.Enums
{
    public class EnumHelper
    {
        public static string GetEnumDescription<T>(T value) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new NotSupportedException("Only enums are supported.");
            }

            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
