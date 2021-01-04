using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 线程操作1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_async_Click(object sender, EventArgs e)
        {
            Action<string> action = DoSomeThing;
            Console.WriteLine("btn_async_Click---Start---线程id：" + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 5; i++)
            {
                action("我");
                //Console.WriteLine("btn_async_Click---Doing---线程id：" + Thread.CurrentThread.ManagedThreadId);
            }

            Console.WriteLine("btn_async_Click---End---线程id：" + Thread.CurrentThread.ManagedThreadId);
        }

        private void DoSomeThing(string name)
        {
            Console.WriteLine("DoSomeThing---Start---线程id：" + Thread.CurrentThread.ManagedThreadId);

            int sum = 0;
            for (int i = 0; i < 10000; i++)
            {
                sum += i;
            }
            Console.WriteLine(Thread.CurrentThread.IsBackground);
            //Thread.CurrentThread.IsBackground = true;
            Console.WriteLine("DoSomeThing---End---线程id：" + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// 后台线程，应用程序不考虑是否运行完毕就直接退出，所有的后台线程在应用程序退出时都会自动结束。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundThread_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Thread.Sleep(3000); });
            thread.IsBackground = true;
            thread.Start();
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((name) => { DoSomeThing(Name); });
        }
    }
}