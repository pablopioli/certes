using System;

#if NETCF_1_0 || NETCF_2_0 || SILVERLIGHT || PORTABLE
using System.Collections;
using System.Reflection;
#endif


namespace Org.BouncyCastle.Utilities
{
    internal abstract class Enums
    {
        internal static Enum GetEnumValue(System.Type enumType, string s)
        {
            if (!IsEnumType(enumType))
                throw new ArgumentException("Not an enumeration type", "enumType");

            // We only want to parse single named constants
            if (s.Length > 0 && char.IsLetter(s[0]) && s.IndexOf(',') < 0)
            {
                s = s.Replace('-', '_');
                s = s.Replace('/', '_');

#if NETCF_1_0
                FieldInfo field = enumType.GetField(s, BindingFlags.Static | BindingFlags.Public);
                if (field != null)
                {
                    return (Enum)field.GetValue(null);
                }
#else
                return (Enum)Enum.Parse(enumType, s, false);
#endif		
            }

            throw new ArgumentException();
        }

        internal static Array GetEnumValues(System.Type enumType)
        {
            if (!IsEnumType(enumType))
                throw new ArgumentException("Not an enumeration type", "enumType");

#if NET8_0_OR_GREATER
            return Enum.GetValuesAsUnderlyingType(enumType);
#else
            return Enum.GetValues(enumType);
#endif
        }

        internal static bool IsEnumType(System.Type t)
        {
#if NEW_REFLECTION
            return t.GetTypeInfo().IsEnum;
#else
            return t.IsEnum;
#endif
        }
    }
}
