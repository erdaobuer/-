using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程知识总结
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*2020年1月1日20:00 元旦 跨年夜，思绪万千，感慨万千，2019年结了婚，2020年有了女儿
            短短2年，自己从浪子变成了人夫，人父，角色的转变，心智也变了许多，做什么事情都
            开始瞻前顾后，左思右想，活得小心翼翼，如履薄冰，妻子的不理解，家人的无能为力，
            让我有时候感觉自己很无助，一次次想放弃，一次次告诉自己男人的责任，马上就
            2021年了，告诉自己不要再想那么多了，活得简单一点，不为无关紧要的事情烦恼，
            集中注意力努力赚钱，相信日子好了，一切都会超好的方向发展。*/

            //Main函数属于主线程，在主线程创建子线程并启动，需要添加阻塞等待，不然不等子线程执行，主线程已结束
            //Console.Read() 也带阻塞功能

            //fun1();//创建线程方法一
            fun2();
        }

        public static void fun2()
        {
            int sum = 50000;

            //StartNew会立刻执行,下面穿参为fun类型的委托，带返回值
            //var task = Task.Factory.StartNew(() => "a");//lambda表达式返回一个“a”
            //task.Result获取线程的返回值，也就是上面的a，task.Result带阻塞作用
            //Console.WriteLine(task.Result);

            var task = Task.Factory.StartNew(() => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 });
            foreach (var item in task.Result)
            {
                Console.WriteLine(item);
            }
        }

        public static void fun1()
        {
            int sum = 50000;
            var task1 = new Task(() =>
            {
                for (int i = 0; i < sum; i++)
                {
                    //这里面写要执行的代码
                    Console.Write("--");
                }
            });

            var task2 = new Task(() =>
            {
                for (int i = 0; i < sum; i++)
                {
                    //这里面写要执行的代码
                    Console.Write("|");
                }
            });

            //线程都先启动再阻塞，就会按照无序执行
            task1.Start();//启动Task线程
            task2.Start();//启动Task线程
            task1.Wait();
            task2.Wait();

            //线程一边阻塞，一边阻塞就会顺序执行
            //task1.Start();//启动Task线程
            //task1.Wait();
            //task2.Start();//启动Task线程
            //task2.Wait();
        }
    }
}