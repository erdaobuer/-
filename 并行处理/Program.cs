using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 并行处理
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 5000000; i++)
            {
                list.Add(i);
            }

            CalcTime(() => list.ForEach(item => Do(ref item)));//遍历,未并行处理
            //CalcTime(() => list.AsParallel().ForAll(item => Do(ref item)));//并行处理
            //CalcTime(() => Parallel.ForEach(list, item => Do(ref item)));//并行处理
        }

        private static void Do(ref int i)
        {
            i = (int)Math.Abs(Math.Sin(i));
        }

        private static void CalcTime(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //遍历集合，给每个数加一
            action();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}