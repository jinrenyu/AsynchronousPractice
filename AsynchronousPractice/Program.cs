using System;
using System.Threading;

namespace AsynchronousPractice
{
    /**
     * 线程池是为突然大量爆发的线程设计的，通过有限的几个固定线程为大量的操作服务，
     * 减少了创建和销毁线程所需的时间，从而提高效率，这也是线程池的主要好处
     * 
     * ThreadPool适用于并发运行若干个任务且运行时间不长互不干扰的场景
     * 
     * 通过线程池创建的任务是后台任务
     * 
     * 从运行结果可以看出，程序并没有每次执行任务都创建新的线程，而是循环利用线程池中维护的线程
     * 
     * 如果去掉最后一句 Console.ReadLine() ，会发现程序仅输出 主线程开始！ 就直接退出，从而确定ThreadPool创建的
     * 线程都是后台线程
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始!");

            //创建要执行的任务
            WaitCallback workItem = state => Console.WriteLine("当前线程Id为："+Thread.CurrentThread.ManagedThreadId);

            //重复调用10次
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem);
            }
            Console.ReadLine();
        }
    }
}
