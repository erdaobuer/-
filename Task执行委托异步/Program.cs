using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task执行委托异步
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action<string> action = DoSomeThing;
            Thread.CurrentThread.Name = "Main";
            var userName = "Tate";
            //action.Invoke(userName);//同步
            //action(userName);//同步
            IAsyncResult asyncResult = null;
            AsyncCallback callback = new AsyncCallback(ia =>
            {
                //Console.WriteLine("ok???" + object.ReferenceEquals(ia, asyncResult));//返回值作为参数传递给回调函数
                //Console.WriteLine(ia.AsyncState);//状态，“bibobibo”
                //Console.WriteLine(ia.IsCompleted);
                //Console.WriteLine("what are you doing？");
            });

            asyncResult = action.BeginInvoke(userName, callback, "bibobibo");//委托异步调用,返回值作为参数传递给回调函数
                                                                             //Thread.CurrentThread.Join();//阻塞主线程

            //注意：等待都会卡界面

            #region 等待线程执行完成方法一

            //int i = 0;
            //while (!asyncResult.IsCompleted)
            //{
            //    //Thread.Sleep(200);//先判断，再sleep，再打印
            //    if (i < 10)
            //    {
            //        Console.WriteLine($"{ i++ * 10}% ");
            //    }
            //    else
            //    {
            //        Console.WriteLine("99.9%");
            //    }
            //    Thread.Sleep(200);//先判断，再打印，再sleep
            //}

            #endregion 等待线程执行完成方法一

            Thread.Sleep(200);
            Console.WriteLine("do something!!!!");
            Console.WriteLine("do something!!!!");
            Console.WriteLine("do something!!!!");

            #region 等待执行完成方法二

            //asyncResult.AsyncWaitHandle.WaitOne();//等待任务的完成
            //asyncResult.AsyncWaitHandle.WaitOne(-1);//等待任务的完成
            //asyncResult.AsyncWaitHandle.WaitOne(1000);//等待，但最多等待1000ms

            #endregion 等待执行完成方法二

            #region 等待执行完成方法三

            action.EndInvoke(asyncResult);//对应BeginInvoke，可以得到返回值

            #endregion 等待执行完成方法三

            {
                //带返回值的委托
                Func<string, string> func = (x) =>
                 {
                     Thread.Sleep(200);
                     return DateTime.Now.Day + "";
                 };

                Console.WriteLine($"Func.Invoke()={func.Invoke("tate")}");
                IAsyncResult asyncResult1 = func.BeginInvoke("aaa", r =>
                   {
                       Console.WriteLine(r.AsyncState);
                   }, "tate");
                Console.WriteLine($"func.EndInvoke(asyncResult)={func.EndInvoke(asyncResult1)}");
            }

            Console.WriteLine("upload success");
        }

        private static void DoSomeThing(string name)
        {
            Thread.CurrentThread.Name = "thread2";
            Console.WriteLine($"********DoSomeThing Start********{Thread.CurrentThread.Name}");
            long IResult = 0;
            for (int i = 0; i < 1000000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"********DoSomeThing End********{Thread.CurrentThread.Name}");
        }
    }
}