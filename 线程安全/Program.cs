using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程安全错误示范
{
    internal class Program
    {
        private static int Count = 0;
        /*
         * 开两个线程，一个对Count++，一个对Count--
         * 然后分别多线程执行，最后打印出Count的值
         *本应最后Count为0，但实际结果却不一定是0，因为线程是交替执行的，
         *而且++，--都是具有原子性的,不可分割的，但是实际运行中可能会在执行++第一步复制的同时也执行了--第一步复制的动作
         *就会导致最后出错
         */

        private static void Main(string[] args)
        {
            #region 这样处理最后结果

            var task1 = new Task(Increment);
            var task2 = new Task(Decrement);

            task1.Start();
            task2.Start();
            Task.WaitAll(task1, task2);
            Console.WriteLine(Count);

            #endregion 这样处理最后结果
        }

        /// <summary>
        /// ++
        /// </summary>
        private static void Increment()
        {
            for (int i = 0; i < 5000000; i++)
            {
                Count++;//这一步其实包含三步，先复制Count到其他变量，然后给其他变量+1，最后将值赋值给Count
            }
        }

        /// <summary>
        /// --
        /// </summary>
        private static void Decrement()
        {
            for (int i = 0; i < 5000000; i++)
            {
                Count--;//这一步其实包含三步，先复制Count到其他变量，然后给其他变量-1，最后将值赋值给Count
            }
        }
    }
}