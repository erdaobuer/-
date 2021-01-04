using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 后台线程
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                //Thread.Sleep(1000);
                Console.WriteLine($"线程0启动");
            });
            //thread.IsBackground = true;//设置为后台线程，应用程序结束，他结束
            thread.Start();

            Thread thread1 = new Thread(() =>
            {
                //Thread.Sleep(1000);
                Console.WriteLine($"线程1启动");
            });
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                //Thread.Sleep(1000);
                Console.WriteLine($"线程2启动");
            });
            thread2.Priority = ThreadPriority.Highest;
            thread2.Start();

            Thread thread3 = new Thread(() =>
            {
                //Thread.Sleep(5000);
                Console.WriteLine($"线程3启动");
            });
            thread3.Start();
        }
    }
}