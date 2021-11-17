using demo_linq.database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class CURDDetail
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
            ShowExample_Create();
            ShowExample_Read();
            ShowExample_Update();
            ShowExample_Delete();
            Console.WriteLine("----------------------------------------------------------------END Example----------------------------------------------------------------");
        }

        private static void ShowCode_Create()
        {
            Utils.WriteContent("Code");
            Utils.WriteSubContent(@"Room obj = new Room { RoomId = ""777"",Description = ""Test for insert"" };");
            Utils.WriteSubContent(@"context.Room.Add(obj);");
            Utils.WriteSubContent(@"context.SaveChanges();");
        }
        private static void ShowExample_Create()
        {
            try
            {
                Utils.WriteHeader("Create");
                ShowCode_Create();
                using (var context = new eroomContext())
                {
                    Utils.WriteContent("Before insert");
                    Utils.WriteSubContent($@"Room.Count = {context.Room.Count()}");
                    Room obj = new Room{ RoomId = "777", Description = "Test for insert"};
                    context.Room.Add(obj);
                    context.SaveChanges();
                    Utils.WriteContent("After insert");
                    Utils.WriteSubContent($@"Room.Count = {context.Room.Count()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }
        }

        private static void ShowCode_Update()
        {
            Utils.WriteContent("Code");
            Utils.WriteSubContent(@"var obj = context.Room.Where(r => r.RoomId == ""777"").Single();");
            Utils.WriteSubContent(@"obj.Description = $@""Test for update { DateTime.Now}"";");
            Utils.WriteSubContent(@"context.Room.Update(obj);");
            Utils.WriteSubContent(@"context.SaveChanges();");
        }
        private static void ShowExample_Update()
        {
            try
            {
                Utils.WriteHeader("Update");
                ShowCode_Update();
                using (var context = new eroomContext())
                {

                    var obj = context.Room.Where(r => r.RoomId == "777").Single();
                    Utils.WriteContent("Before update");
                    Utils.WriteSubContentObject(obj);
                    obj.Description = $@"Test for update {DateTime.Now}";
                    context.Room.Update(obj);
                    context.SaveChanges();
                }

                using (var context = new eroomContext())
                {

                    var rstobj = context.Room.Where(r => r.RoomId == "777").Single();
                    Utils.WriteContent("After update");
                    Utils.WriteSubContentObject(rstobj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }

        }

        private static void ShowCode_Read()
        {
            Utils.WriteContent("Code");
            Utils.WriteSubContent(@"var obj = context.Room.Where(r => r.RoomId == ""777"").Single();");
        }
        private static void ShowExample_Read()
        {
            try
            {
                Utils.WriteHeader("Read");
                ShowCode_Read();
                using (var context = new eroomContext())
                {
                    var obj = context.Room.Where(r => r.RoomId == "777").Single();
                    Utils.WriteContent("Result of read");
                    Utils.WriteSubContentObject(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
                Console.WriteLine($@"");
            }
        }

        private static void ShowCode_Delete()
        {
            Utils.WriteContent("Code");
            Utils.WriteSubContent(@"var obj = context.Room.Where(r => r.RoomId == ""777"").Single();");
            Utils.WriteSubContent(@"context.Room.Remove(obj);");
            Utils.WriteSubContent(@"context.SaveChanges();");
        }

        private static void ShowExample_Delete()
        {
            try
            {
                Utils.WriteHeader("Delete");
                ShowCode_Delete();
                using (var context = new eroomContext())
                {
                    var obj = context.Room.Where(r => r.RoomId == "777").Single();
                    Utils.WriteContent("Before delete");
                    Utils.WriteSubContent($@"Room.Count = {context.Room.Count()}");
                    context.Room.Remove(obj);
                    context.SaveChanges();
                    Utils.WriteContent("After delete");
                    Utils.WriteSubContent($@"Room.Count = {context.Room.Count()}");
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
