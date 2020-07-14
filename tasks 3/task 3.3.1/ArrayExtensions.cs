using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._3._1
{
    static class ArrayExtensions
    {

        public static void ExtensionMethod<T> (this T[] array, Func<T,T> action) where T : struct
        {
            if (action == null)
            {
                throw new NullReferenceException("Delegate is null");
            }
            else if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Array is null or empty");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = action(array[i]);
                }
            }
        }

        public static int ExtensionSum(this int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Array is null or empty");
            }
            else
            {
                return array.Sum();
            }
        }

        public static double ExtensionAverage(this int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Array is null or empty");
            }
            else
            {
                return array.Average();
            }
        }

        public static double ExtensionSum(this double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Array is null or empty");
            }
            else
            {
                return array.Sum();
            }
        }

        public static double ExtensionAverage(this double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Array is null or empty");
            }
            else
            {
                return array.Average();
            }
        }

        public static void ExtensionRepeat<T>(this T[] array) where T : struct
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Array is null or empty");
            }
            else
            {
                int repeat = 0;
                int maxrepeat = 0;
                T result = default;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (array[i].Equals(array[j]))
                        {
                            repeat++;
                        }
                    }
                    if (repeat > maxrepeat)
                    {
                        maxrepeat = repeat;
                        result = array[i];
                    }
                    repeat = 0;
                }
                if (maxrepeat > 0)
                {
                    Console.WriteLine(result);
                }
            }
        }

    }
}
