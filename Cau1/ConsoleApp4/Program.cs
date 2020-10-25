using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp4
{
    static class Program
    {

        enum Mammals { Cat, Dog, Horse, Dolphin };
        public static T To<T>(object value, T idefault) where T : struct
        {
            var result = idefault;
            try
            {
                if (value == null || value == DBNull.Value) return idefault;
                else if(typeof(T).IsEnum)
                {
                    result = (T)Enum.ToObject(typeof(T), To(value, Convert.ToInt32(idefault)));
                }
                else
                {
                    result = (T)Convert.ChangeType(value, typeof(T));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public static void Main(string[] args)
        {
            Object obj = Enum.ToObject(Mammals.Cat.GetType(), 1);
            Console.WriteLine(To<int>(obj,1));
        }
    }
}
