using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    internal class Program
    {
        private delegate void del(string name);

        [Obsolete]
        private static void Main(string[] args)
        {
            del d = fun1;
            IAsyncResult iar = d.BeginInvoke("zhangsan", CallFun, null);//参1：委托函数参数，2.回调函数，3.null

            //Thread thread = new Thread(() => { Console.WriteLine("我是一个线程,我启动了"); });
            //Console.WriteLine("Create状态：" + thread.ThreadState);
            //thread.Start();
            //Console.WriteLine("Start状态：" + thread.ThreadState);
            //thread.Suspend();
            //Console.WriteLine("Suspend挂起状态：" + thread.ThreadState);
            //thread.Resume();
            //Console.WriteLine("Resume继续运行挂起线程状态：" + thread.ThreadState);
            //thread.Join();//阻塞调用线程，直到某个线程终止
            //Console.WriteLine("Join线程状态：" + thread.ThreadState);
            //thread.Abort();//销毁线程
            //Console.WriteLine("Abort线程状态：" + thread.ThreadState);
        }

        public static void CallFun(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            del del = (del)ar.AsyncDelegate;
            del.EndInvoke(iar);
            Console.WriteLine("回调函数执行EndInvoke");
            Console.WriteLine("回调函数完成");
        }

        public static void fun1(string name)
        {
            Console.WriteLine(name);
        }
    }
}