using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils
{
    /// <summary>
    /// 类型转换类
    /// </summary>
    public static class TypeConvert
    {
        /// <summary>
        /// 转换为Int
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static int ToInt(this object thisValue)
        {
            int reval = 0;
            if (thisValue == null) return 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 转换为Int
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static int ToInt(this object thisValue, int errorValue)
        {
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out int reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 转换为Decimal
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object thisValue)
        {
            if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out decimal reval))
            {
                return reval;
            }
            return 0;
        }
        /// <summary>
        /// 转换为Decimal
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object thisValue, decimal errorValue)
        {
            if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out decimal reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 转换为Long
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static long ToLong(this object thisValue)
        {
            long reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && long.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 转换为Bool
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool ToBool(this object thisValue)
        {
            bool reval = false;
            if (thisValue != null && thisValue != DBNull.Value && bool.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 转换为Date
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object thisValue, DateTime errorValue)
        {
            if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out DateTime reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 转换为Date
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object thisValue)
        {
            DateTime reval = DateTime.Now;
            if (thisValue != null && thisValue.ToString() != "" && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out reval))
            {
                reval = Convert.ToDateTime(thisValue);
            }
            return reval;
        }
    }
}
