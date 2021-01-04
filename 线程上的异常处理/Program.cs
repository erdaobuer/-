using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程上的异常处理
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //fun1();//多线程异常捕获方法一
            fun2();//多线程异常捕获方法二
        }

        /// <summary>
        /// 在task.Wait(),task.Result,task.WaitAll(),task.WaitAny()语句外加try...catch...语句捕获异常
        /// </summary>
        private static void fun1()
        {
            var task = Task.Factory.StartNew(() => { throw new ApplicationException("这是一个异常"); });
            try
            {
                task.Wait();
            }
            //AggregateException是一个异常集合
            catch (AggregateException exs)
            {
                foreach (var ex in exs.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// ContinueWith是Task根据其自身状况，决定后续应该作何操作。也就是说，在运行完task后，
        /// 会执行task.continuewith(XX)中的XX语句，但是是否执行、如何执行等需要看task的运行情况。
        /// </summary>
        private static void fun2()
        {
            Task task = new Task(() => { throw new ApplicationException("我是一个异常"); });
            //参数t指的是调用ContinueWith方法的Task
            task.ContinueWith((t) =>
            {
                foreach (var ex in t.Exception.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            task.Start();
            Task.WaitAll(task);
        }
    }
}