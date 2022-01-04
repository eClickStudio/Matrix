using System;
using System.Diagnostics;

namespace List_tests
{
    class Program
    {
        static Stopwatch stopWatch = new Stopwatch();
        static Matrix<string> matrixNormal = new Matrix<string>(5, 4, 10, 20, "@");
        static void Main(string[] args)
        {
            Console.WriteLine($"NormalMatrix---------------");
            stopWatch.Start();
            for (byte y = 0; y < 100; y++)
            {
                for (byte x = 0; x < 100; x++)
                {
                    if (matrixNormal.CanAddToIndex(x, y))
                    {
                        string res = (x + y) % 3 == 0 || (x + y) % 3 == 1 ? ":" : "@";
                        matrixNormal.AddToIndex(x, y, res);
                    }
                }
            }
            matrixNormal.PrintMatrix();
            stopWatch.Stop();
            Console.WriteLine($"Worked time is {stopWatch.Elapsed}");
            Console.ReadKey();
        }
    }
}
