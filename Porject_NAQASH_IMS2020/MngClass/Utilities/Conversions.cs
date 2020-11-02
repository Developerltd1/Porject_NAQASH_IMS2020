using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porject_NAQASH_IMS2020.MngClass.Utilities
{
    public static class Conversions
    {
            public static char ToChar(this object obj)
            {
                return Convert.ToChar(obj);
            }
            public static Int16 ToShortInt(this object obj)
            {
                return Convert.ToInt16(obj);
            }
            public static string ToString2(this object obj)
            {
                return Convert.ToString(obj);
            }
            public static int ToInt32(this object obj)
            {
                return Convert.ToInt32(obj);
            }
            public static byte ToByte(this object obj)
            {
                return Convert.ToByte(obj);
            }
            public static Int64 ToInt64(this object obj)
            {
                return Convert.ToInt64(obj);
            }
            public static decimal ToDecimal(this object obj)
            {
                return Convert.ToDecimal(obj);
            }
            public static Double ToDouble(this object obj)
            {
                return Convert.ToDouble(obj);
            }
            public static string ToPkNum(this string number)
            {
                switch (number.Length)
                {
                    case 11:
                        {

                            return "+92" + number.Substring(1);

                        }


                    case 10:
                        {
                            return "+92" + number;
                        }

                    case 12:
                        {
                            return "+" + number;
                        }

                    case 14:
                        {
                            return "+" + number.Substring(2);
                        }

                }
                throw new Exception("Invalid String");
            }
            public static DateTime ToDate(this object obj)
            {
                return Convert.ToDateTime(obj);
            }
            public static bool ToBool(this object obj)
            {
                try
                {
                    return Convert.ToBoolean(obj);
                }
                catch
                {
                    return false;
                }
            }
        }
    }

