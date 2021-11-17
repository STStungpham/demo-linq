using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class SingleDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            Console.WriteLine("Single: There is exactly 1 result, an exception is thrown if no result is returned or more than one result");
            Console.WriteLine("Single: The query is 'select.....'");
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

                    Console.WriteLine($@"Single: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomName != null).SingleOrDefault();");
                    var obj = context.Room.Where(r => r.RoomName != null).Single();
                    Console.WriteLine($@"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }
            
        }

        private static void ShowExample_HaveOnly1Result()
        {
            try
            {
                using (var context = new eroomContext())
                {
                    Console.WriteLine($@"Single: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '004').Single();");
                    var obj = context.Room.Where(r => r.RoomId == "004").Single();
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
                    Console.WriteLine($@"Single: when have 0 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '7777777').Single();");
                    var obj = context.Room.Where(r => r.RoomId == "7777777").Single();
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
