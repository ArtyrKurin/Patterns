using System;

namespace Learning
{
    class Program
    {
        public static int[] GenereratePrimeNumbers(int maxValue)
        {
            if (maxValue >= 2)
            {
                int size = maxValue + 1;
                bool[] f = new bool[size];
                int i;
                for (i = 0; i < size; i++)
                {
                    f[i] = true;
                }
                //исключение заведомо не простые числа
                f[0] = f[1] = false;

                //решето
                int j;
                for (j = 0; j < Math.Sqrt(size); j++)
                {
                    if (f[i])
                    {
                        for (j = 2 * i; j < size; j += i)
                        {
                            f[j] = false;
                        }
                    }
                }

                int count = 0;
                for (i = 0; i < size; i++)
                {
                    if (f[i])
                    {
                        count++;
                    }
                }

                int[] primes = new int[count];

                for (i = 0, j = 0; i < size; i++)
                {
                    if (f[i])
                    {
                        primes[j++] = i;
                    }

                }
                return primes;
            }
            else
            {
                return new int[0];
            }
        }
        static void Main(string[] args)
        {
            int[] results = GenereratePrimeNumbers(1000);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }

}
