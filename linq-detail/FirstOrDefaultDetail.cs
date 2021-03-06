using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class FirstOrDefaultDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            Console.WriteLine("FirstOrDefault: There is at least one result, if no result is returned, null value will be returned");
            Console.WriteLine("FirstOrDefault: The query is 'select top 1 ....'");
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

                    Console.WriteLine($@"FirstOrDefault: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomName != null).FirstOrDefaultOrDefault();");
                    var obj = context.Room.Where(r => r.RoomName != null).FirstOrDefault();
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
                    Console.WriteLine($@"FirstOrDefault: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '004').FirstOrDefault();");
                    var obj = context.Room.Where(r => r.RoomId == "004").FirstOrDefault();
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
                    Console.WriteLine($@"FirstOrDefault: when have 0 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '7777777').FirstOrDefault();");
                    var obj = context.Room.Where(r => r.RoomId == "7777777").FirstOrDefault();
                    Console.WriteLine($@"            obj == null: " + (obj == null).ToString());
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
