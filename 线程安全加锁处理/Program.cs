using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程安全加锁处理
{
    internal class Program
    {
        private static int Count = 0;
        private static readonly object sync = new object();
        /*
         * Lock关键字  使得操作具有原子性
         * 最佳用处
         *
         * 对可变的状态进行同步
         * 不可改变的东西不需要同步
         * 多个线程访问同一个对象时，必须加锁
         */

        private static void Main(string[] args)
        {
            var task1 = new Task(Increment);
            var task2 = new Task(Decrement);

            task1.Start();
            task2.Start();
            Task.WaitAll(task1, task2);
            Console.WriteLine(Count);
        }

        /// <summary>
        /// ++
        /// </summary>
        private static void Increment()
        {
            for (int i = 0; i < 5000000; i++)
            {
                lock (sync)
                {
                    Count++;
                }
            }
        }

        /// <summary>
        /// --
        /// </summary>
        private static void Decrement()
        {
            for (int i = 0; i < 5000000; i++)
            {
                lock (sync)
                {
                    Count--;
                }
            }
        }
    }
}