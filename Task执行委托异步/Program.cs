using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 委托异步
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
                Console.WriteLine("1______ok???" + object.ReferenceEquals(ia, asyncResult));//返回值作为参数传递给回调函数
                Console.WriteLine($"2______ia.AsyncState:{ia.AsyncState}");//状态，“bibobibo”
                Console.WriteLine($"3______ia.IsCompleted{ia.IsCompleted}");
                Console.WriteLine("4______what are you doing？");
            });

            asyncResult = action.BeginInvoke(userName, callback, "bibobibo");//委托异步调用,返回值作为参数传递给回调函数
            //Thread.CurrentThread.Join(10000);//阻塞主线程
            //注意：等待都会卡界面

            #region 等待线程执行完成方法一

            int i = 0;
            while (!asyncResult.IsCompleted)
            {
                //Thread.Sleep(200);//先判断，再sleep，再打印
                if (i < 10)
                {
                    Console.WriteLine($"{ i++ * 10}% ");
                }
                else
                {
                    Console.WriteLine("99.9%");
                }
                Thread.Sleep(200);//先判断，再打印，再sleep
            }

            #endregion 等待线程执行完成方法一

            //Thread.Sleep(200);
            //Console.WriteLine("do something!!!!");
            //Console.WriteLine("do something!!!!");
            //Console.WriteLine("do something!!!!");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"do something!!!!**********{i + 1}");
            //}

            #region 等待线程执行完成方法二

            //asyncResult.AsyncWaitHandle.WaitOne();//等待任务的完成
            //asyncResult.AsyncWaitHandle.WaitOne(-1);//等待任务的完成
            //asyncResult.AsyncWaitHandle.WaitOne(10000);//等待，但最多等待1000ms

            #endregion 等待线程执行完成方法二

            #region 等待线程执行完成方法三

            //action.EndInvoke(asyncResult);//对应BeginInvoke，可以得到返回值

            #endregion 等待线程执行完成方法三

            {
                #region 同步调用带参函数，并获取返回值

                //Func<string, string> func = (x) =>
                //        {
                //            Thread.Sleep(200);
                //            return DateTime.Now.Day + "";
                //        };

                //Console.WriteLine($"Func.Invoke()={func.Invoke("tate")}");

                #endregion 同步调用带参函数，并获取返回值

                #region 异步调用带参函数，并获取返回值

                //IAsyncResult asyncResult1 = func.BeginInvoke("aaa", r =>
                //           {
                //               //ds = func.EndInvoke(r);
                //               //Console.WriteLine(r.AsyncState);
                //           }, "tate");

                ////委托.EndInvoke可以获取返回值
                //Console.WriteLine($"func.EndInvoke(asyncResult)={func.EndInvoke(asyncResult1)}");

                #endregion 异步调用带参函数，并获取返回值
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