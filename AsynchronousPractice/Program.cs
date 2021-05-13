using System;
using System.Threading;

namespace AsynchronousPractice
{
    /**
     * 主线程
     * 进程的入口点创建的第一个线程被称为主线程
     * .Net执行程序（控制台，Windows Form,WPF等）使用Main()方法作为程序入口点，当调用该方法时，主线程被创建
     * 
     * 工作者线程
     * 由主线程创建的线程，用来去执行某项具体的任务
     * 
     * 什么是前台线程？（工作者线程）
     * 默认情况下Thread.Start()方法创建的线程都是前台线程
     * 前台线程能阻止应用程序终结，只有所有的前台线程执行完毕，CLR才能关闭应用程序（即卸载承载的应用程序域）
     * 
     * 什么是后台线程？（工作者线程）
     * 后台线程不会影响应用程序的终结，当所有前台线程都执行完毕后，后台线程无论是否执行完毕，都会被终结
     * 一般后台线程用来做些无关紧要的任务（比如邮箱每隔一段时间就去检查下邮件，天气应用每隔一段时间去更新天气）
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始!");

            //创建前台工作线程
            Thread thread1 = new Thread(Task1);
            thread1.Start();

            //创建后台工作线程
            Thread thread2 = new Thread(new ParameterizedThreadStart(Task2));
            thread2.IsBackground = true;//设置为后台线程
            thread2.Start("传参");

        }

        private static void Task1()
        {
            //模拟耗时操作，睡眠1s
            Thread.Sleep(3000);

            Console.WriteLine("前台线程被调用！");
        }

        private static void Task2(object data)
        {
            //模拟耗时操作，睡眠2s
            Thread.Sleep(2000);

            Console.WriteLine("后台线程被调用！" + data);
        }
    }
}
