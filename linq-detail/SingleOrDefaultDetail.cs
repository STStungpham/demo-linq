using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class SingleOrDefaultDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            Console.WriteLine("SingleOrDefault: There is exactly 1 result, an exception is thrown if more than one result, null value will be returned when no result is returned");
            Console.WriteLine("SingleOrDefault: The query is 'select.....'");
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

                    Console.WriteLine($@"SingleOrDefault: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomName != null).SingleOrDefaultOrDefault();");
                    var obj = context.Room.Where(r => r.RoomName != null).SingleOrDefault();
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
                    Console.WriteLine($@"SingleOrDefault: when have more than 1 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '004').SingleOrDefault();");
                    var obj = context.Room.Where(r => r.RoomId == "004").SingleOrDefault();
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
                    Console.WriteLine($@"SingleOrDefault: when have 0 result");
                    Console.WriteLine($@"      var obj = context.Room.Where(r => r.RoomId == '7777777').SingleOrDefault();");
                    var obj = context.Room.Where(r => r.RoomId == "7777777").SingleOrDefault();
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
