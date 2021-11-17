using demo_linq.database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class MultiTablesDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            ShowExample();
        }
        private static void ShowExample()
        {
            Console.WriteLine("----------------------------------------------------------------Example----------------------------------------------------------------");
            ShowExample_Join();
            ShowExample_GroupBy();
            Console.WriteLine("----------------------------------------------------------------END Example----------------------------------------------------------------");
        }

        private static void ShowCode_Join()
        {
            Utils.WriteContent("Code");
            Utils.WriteSubContent(@"var rst = from r in context.Room");
            Utils.WriteSubContent(@"join rd in context.RoomDetail");
            Utils.WriteSubContent(@"on r.RoomId equals rd.RoomId");
            Utils.WriteSubContent(@"select new");
            Utils.WriteSubContent(@"{");
            Utils.WriteSubContent(@"    RoomId = r.RoomId,");
            Utils.WriteSubContent(@"    DateIn = rd.DateIn,");
            Utils.WriteSubContent(@"    DateOut = rd.DateOut,");
            Utils.WriteSubContent(@"    Desc = rd.Description");
            Utils.WriteSubContent(@"};");
        }
        private static void ShowExample_Join()
        {
            try
            {
                Utils.WriteHeader("Join");
                ShowCode_Join();
                using (var context = new eroomContext())
                {
                    var rst = from r in context.Room
                              join rd in context.RoomDetail
                              on r.RoomId equals rd.RoomId
                              where r.RoomId == "004"
                              select new
                              {
                                  RoomId = r.RoomId,
                                  DateIn = rd.DateIn,
                                  DateOut = rd.DateOut,
                                  Desc = rd.Description
                              };

                    Utils.WriteContent("Result");
                    foreach (var item in rst)
                    {
                        Utils.WriteSubContentObject(item);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }
        }

        private static void ShowCode_GroupBy()
        {
            Utils.WriteContent("Code");
            Utils.WriteSubContent(@"var query = from b in context.Room");
            Utils.WriteSubContent(@"            let Details = context.RoomDetail.Where(rd => rd.RoomId == b.RoomId)");
            Utils.WriteSubContent(@"                                             .Select(rd => new {DateIn= rd.DateIn, DateOut = rd.DateOut, Desc = rd.Description } )");
            Utils.WriteSubContent(@"                                             .ToList()");
            Utils.WriteSubContent(@"            where b.RoomId == ""004""");
            Utils.WriteSubContent(@"            select new { RoomId = b.RoomId, Details }");
            Utils.WriteSubContent(@"            ;");
        }
        private static void ShowExample_GroupBy()
        {
            try
            {
                Utils.WriteHeader("GroupBy");
                ShowCode_GroupBy();
                using (var context = new eroomContext())
                {
                
                    var query = from b in context.Room
                                let Details = context.RoomDetail.Where(rd => rd.RoomId == b.RoomId)
                                                                 .Select(rd => new {DateIn= rd.DateIn, DateOut = rd.DateOut, Desc = rd.Description } )
                                                                 .ToList() 
                                where b.RoomId == "004"
                                select new { RoomId = b.RoomId, Details }
                                ;
                    Utils.WriteContent("Result");
                    foreach (var item in query)
                    {
                        Utils.WriteSubContentObject(item);
                    }
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
