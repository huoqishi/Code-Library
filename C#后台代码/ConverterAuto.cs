// ***********************************************************************
// Project          : Micua Infrastructure
// Assembly         : Micua.Infrastructure.Utility
// Author           : 火骑士空空
// Created          : 2014-1-03 10:56:22
// 
// Last Modified By : 火骑士空空
// Last Modified On : 2015-09-13 12:55:02
// ***********************************************************************
// <copyright file="Convert.cs" company="kkisc.com">
//     Copyright © 2015 kkisc.com . All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace System
{
    /// <summary>
    /// 转换拓展方法
    /// </summary>
    public static partial class Converter
    {
        #region Convert string type to other types


        #region String to Boolean +static bool ToBoolean(this string s, bool def = default(Boolean))
        /// <summary>
        /// String to Boolean(字符串 转换成 布尔型)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static bool ToBoolean(this string s, bool def = default(bool))
        {
            bool result;
            return Boolean.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Char +static char ToChar(this string s, char def = default(Char))
        /// <summary>
        /// String to Char(字符串 转换成 无符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static char ToChar(this string s, char def = default(char))
        {
            char result;
            return Char.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Decimal +static decimal ToDecimal(this string s, decimal def = default(Decimal))
        /// <summary>
        /// String to Decimal(字符串 转换成 数值、十进制)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static decimal ToDecimal(this string s, decimal def = default(decimal))
        {
            decimal result;
            return Decimal.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Double +static double ToDouble(this string s, double def = default(Double))
        /// <summary>
        /// String to Double(字符串 转换成 数值、浮点)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static double ToDouble(this string s, double def = default(double))
        {
            double result;
            return Double.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Single +static float ToSingle(this string s, float def = default(Single))
        /// <summary>
        /// String to Single(字符串 转换成 数值、浮点)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static float ToSingle(this string s, float def = default(float))
        {
            float result;
            return Single.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Byte +static byte ToByte(this string s, byte def = default(Byte))
        /// <summary>
        /// String to Byte(字符串 转换成 无符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static byte ToByte(this string s, byte def = default(byte))
        {
            byte result;
            return Byte.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to SByte +static sbyte ToSByte(this string s, sbyte def = default(SByte))
        /// <summary>
        /// String to SByte(字符串 转换成 有符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static sbyte ToSByte(this string s, sbyte def = default(sbyte))
        {
            sbyte result;
            return SByte.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Int16 +static short ToInt16(this string s, short def = default(Int16))
        /// <summary>
        /// String to Int16(字符串 转换成 有符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static short ToInt16(this string s, short def = default(short))
        {
            short result;
            return Int16.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to UInt16 +static ushort ToUInt16(this string s, ushort def = default(UInt16))
        /// <summary>
        /// String to UInt16(字符串 转换成 无符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static ushort ToUInt16(this string s, ushort def = default(ushort))
        {
            ushort result;
            return UInt16.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Int32 +static int ToInt32(this string s, int def = default(Int32))
        /// <summary>
        /// String to Int32(字符串 转换成 有符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static int ToInt32(this string s, int def = default(int))
        {
            int result;
            return Int32.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to UInt32 +static uint ToUInt32(this string s, uint def = default(UInt32))
        /// <summary>
        /// String to UInt32(字符串 转换成 无符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static uint ToUInt32(this string s, uint def = default(uint))
        {
            uint result;
            return UInt32.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Int64 +static long ToInt64(this string s, long def = default(Int64))
        /// <summary>
        /// String to Int64(字符串 转换成 有符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static long ToInt64(this string s, long def = default(long))
        {
            long result;
            return Int64.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to UInt64 +static ulong ToUInt64(this string s, ulong def = default(UInt64))
        /// <summary>
        /// String to UInt64(字符串 转换成 无符号、数值、整数)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static ulong ToUInt64(this string s, ulong def = default(ulong))
        {
            ulong result;
            return UInt64.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to DateTime +static DateTime ToDateTime(this string s, DateTime def = default(DateTime))
        /// <summary>
        /// String to DateTime(字符串 转换成 时间)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static DateTime ToDateTime(this string s, DateTime def = default(DateTime))
        {
            DateTime result;
            return DateTime.TryParse(s, out result) ? result : def;
        }
        #endregion


        #region String to Guid +static Guid ToGuid(this string s, Guid def = default(Guid))
        /// <summary>
        /// String to Guid(字符串 转换成 Guid)
        /// </summary>
        /// <remarks>
        ///  2014-06-23 16:31 Created By 火骑士空空
        /// </remarks>
        /// <param name="s">String</param>
        /// <param name="def">Default</param>
        /// <returns>Byte</returns>
        public static Guid ToGuid(this string s, Guid def = default(Guid))
        {
            Guid result;
            return Guid.TryParse(s, out result) ? result : def;
        }
        #endregion


        #endregion

        #region Convert object to other types
        public static int ToInt32(this object o, int def = default(Int32))
        {
            if (o==null)
            {
                return def;
            }
            return o.ToString().ToInt32();
        }

        public static decimal ToDecimal(this object o, decimal def = default(Decimal))
        {
            try
            {
                def=Convert.ToDecimal(o);
            }
            catch (Exception e)
            {
            }
            return def;
        }
        public static double ToDouble(this object o, double def = default(double))
        {
            try
            {
                def=Convert.ToDouble(o);
            }
            catch (Exception e)
            {
            }
            return def;
        }
        #endregion
    }
}
