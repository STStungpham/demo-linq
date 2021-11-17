using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class CountAndAnyDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            Console.WriteLine("Count(): iterate over all elements, return total count");
            Console.WriteLine("Any(): return when meet first element");
            ShowExample();
        }
        private static void ShowExample()
        {
            Console.WriteLine("----------------------------------------------------------------Example----------------------------------------------------------------");
            //InitData();
            var countTime = UsingCount().TotalMilliseconds;
            var anyTime = UsingAny().TotalMilliseconds;
            Console.WriteLine($"countTime/anyTime = {countTime/anyTime}");
            Console.WriteLine("----------------------------------------------------------------END Example----------------------------------------------------------------");
        }

        private static TimeSpan UsingAny()
        {
            using (var context = new eroomContext())
            {
                //Check List<T> is empty or not with Any()
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                if (context.RoomDetail.Any())
                {
                    Console.WriteLine("Check list with Any()");
                }
                stopWatch.Stop();
                Console.WriteLine($"Time consumed - Any(): {stopWatch.Elapsed}");
                return stopWatch.Elapsed;
            }
        }

        private static TimeSpan UsingCount()
        {
            using (var context = new eroomContext())
            {
                //Check List<T> is empty or not with Count()
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                if (context.RoomDetail.Count() > 0)
                {
                    Console.WriteLine("Check list with Count()");
                }
                stopWatch.Stop();
                Console.WriteLine($"Time consumed - Count(): {stopWatch.Elapsed}");
                return stopWatch.Elapsed;
            }
        }
    }
}
