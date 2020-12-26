using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace WebBuilder.Core.Util
{
    /// <summary>
    ///All enum defination area
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// This is delegate for Enum KeyPropertiesValues table column name; 
        /// </summary>
        /// 

        public enum PrimitiveType:int
        {
            
            String = 0,
            Boolean = 1,
            Integer = 2,
            Decimal = 3,
        }

        public enum Status
        {
            Success,
            Empty,
            Error,
        }

        public enum UnitType:int
        {
            Kilogram=0,
            Piece=1,
            Unit=2,
        }
        /// <summary>
        /// This method returns the value of the enum description.
        /// </summary>
        /// <typeparam name="T">Generic Enum</typeparam>
        /// <param name="source">Enum Value</param>
        /// <returns>Description Attribute Value</returns>
        public static string GetDescription(this Enum source)
        {
            FieldInfo fieldInfo = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
        public enum ViewStatus : int
        {
            Insert = 0,
            Update = 1,
        }
    }
}
