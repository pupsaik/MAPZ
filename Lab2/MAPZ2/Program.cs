using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Http.Metrics;
using System.Runtime.Versioning;
using ClassLibrary1;
using Microsoft.VisualBasic;

namespace MAPZ
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 10_000_000; i++)
            {
                Class testClass1 = new();
            }
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for creating instances of non static class: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();

            for (int i = 0; i < 10_000_000; i++)
            {
                StaticClass.StaticMethod();
            }
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for static method: {stopwatch.ElapsedMilliseconds}");

            Class testClass2 = new();
            stopwatch.Restart();
            for (int i = 0; i < 10_000_000; i++)
            {
                testClass2.Method();
            }
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for non static method: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            for (int i = 0; i < 10_000_000; i++)
            {
                StaticClass.Depth++;
            }
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for static variable: {stopwatch.ElapsedMilliseconds}");

            Class @class = new();
            stopwatch.Restart();
            for (int i = 0; i < 10_000_000; i++)
            {
                @class.Depth++;
            }
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for non static variable: {stopwatch.ElapsedMilliseconds}");

            testClass2.Recursive();
        }
    }
}