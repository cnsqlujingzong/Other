using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SHUniversity.KPI
{
 public   class Common
    {
  
     /// <summary>
     /// 字符串转换为datetime?
     /// </summary>
     /// <param name="str"></param>
     /// <returns></returns>
     public static DateTime? ConvertDatetime(string str)
     {
         if (string.IsNullOrEmpty(str))
         {
             return null;
         }
         else
         {
             return DateTime.Parse(str);
         }
     }
    private static Random random = new Random();
     /// <summary>
     /// 随机数
     /// </summary>
     /// <returns></returns>
     public static string CreatRandom()
     {        
         string y = string.Format("{0:yyyyMMddHHmm}",DateTime.Now);
         int r = random.Next(999,10000);
         return y + r.ToString();
     }
     /// <summary>
     /// string型转换为int型
     /// </summary>
     /// <param name="strValue">要转换的字符串</param>
     /// <param name="defValue">缺省值</param>
     /// <returns>转换后的int类型结果</returns>
     public static int StrToInt(string str, int defValue)
     {
         if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
             return defValue;

         int rv;
         if (Int32.TryParse(str, out rv))
             return rv;

         return Convert.ToInt32(StrToFloat(str, defValue));
     }

     /// <summary>
     /// string型转换为long型
     /// </summary>
     /// <param name="strValue">要转换的字符串</param>
     /// <param name="defValue">缺省值</param>
     /// <returns>转换后的int类型结果</returns>
     public static long StrToLong(string str, long defValue)
     {
         if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
             return defValue;

         long rv;
         if (Int64.TryParse(str, out rv))
             return rv;

         return Convert.ToInt64(StrToLong(str, defValue));
     }

     /// <summary>
     /// string型转换为float型
     /// </summary>
     /// <param name="strValue">要转换的字符串</param>
     /// <param name="defValue">缺省值</param>
     /// <returns>转换后的int类型结果</returns>
     public static float StrToFloat(string strValue, float defValue)
     {
         if (strValue == null)
             return defValue;

         float intValue = defValue;
         if (strValue != null)
         {
             bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
             if (IsFloat)
                 float.TryParse(strValue, out intValue);
         }
         return intValue;
     }
     /// <summary>
     /// string型转换为decimal型
     /// </summary>
     /// <param name="strValue">要转换的字符串</param>
     /// <param name="defValue">缺省值</param>
     /// <returns>转换后的int类型结果</returns>
     public static decimal StrToDecimal(string strValue, decimal defValue)
     {

         if (strValue == null)
             return defValue;

         decimal intValue = defValue;
         if (strValue != null)
         {
             bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
             if (IsFloat)
                 decimal.TryParse(strValue, out intValue);
         }
         return intValue;
     }



    }
}
