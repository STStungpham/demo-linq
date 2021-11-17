using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class FirstDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            Console.WriteLine("First: There is at least one result, an exception is thrown if no result is returned");
            Console.WriteLine("First: The query is 'select top 1 ....'");
            ShowExample();
        }
        private static void ShowExample()
        {
            Console.WriteLine("----------------------------------------------------------------Example----------------------------------------------------------------");
            ShowExample_HaveMoreThan1Result();
            ShowExample_HaveOnly1Result();
            ShowExample_Have0Result();
            Console.WriteLine("----------------------------------------------------------------END Example----------------------------------------------------------------");
        }
     

        private static void ShowExample_HaveMoreThan1Result()
        {
            try
            {
                using (var context = new eroomContext())
                {

                    Console.WriteLine($@"First: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomName != null).FirstOrDefault();");
                    var obj = context.Room.First(r => r.RoomName != null);
                    obj = context.Room.Where(r => r.RoomName != null).First();
                    Console.WriteLine($@"            obj.RoomId = " + obj.RoomId);
                    Console.WriteLine($@"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("      ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }
            
        }

        private static void ShowExample_HaveOnly1Result()
        {
            try
            {
                using (var context = new eroomContext())
                {
                    Console.WriteLine($@"First: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '004').First();");
                    var obj = context.Room.Where(r => r.RoomId == "004").First();
                    Console.WriteLine($@"            obj.RoomId = " + obj.RoomId);
                    Console.WriteLine($@"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }

        }

        private static void ShowExample_Have0Result()
        {
            try
            {
                using (var context = new eroomContext())
                {
                    Console.WriteLine($@"First: when have 0 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '7777777').First();");
                    var obj = context.Room.Where(r => r.RoomId == "7777777").First();
                    Console.WriteLine($@"            obj.RoomId = " + obj.RoomId);
                    Console.WriteLine($@"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }

        }

    }
}
