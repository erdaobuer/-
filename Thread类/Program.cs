using System;
using System.Threading;

namespace Thread类
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "MainThread";

            ThreadDemo();
        }

        private static void ThreadDemo()
        {
            Console.WriteLine("MyThread Start");
            Thread myThread = new Thread(new ThreadStart(RunFunction));
            myThread.Name = "MyThread";
            for (int i = 0; i < 20; i++)
            {
                if (i == 10)//i=10的时候，启动子线程
                {
                    myThread.Start();
                    myThread.Join();//此方法执行后，主线程被阻塞，直到子线程执行完
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "   i = " + i);
                }
            }

            //.IsAlive判断当前线程是否处于活动状态
            //if (!myThread.IsAlive)
            //{
            //    Thread.Sleep(1);//暂停当前线程1毫秒
            //    myThread.Abort();//终止某线程
            //    //当NewThread调用Join方法的时候，MainThread就被停止执行，直到NewThread线程执行完毕
            //    myThread.Join();
            //}
        }

        private static void RunFunction()
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "   j = " + j);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " has finished");
        }
    }
}