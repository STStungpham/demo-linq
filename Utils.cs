using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace demo_linq
{
    public static class Utils
    {
        public static void WriteHeader(string header)
        {
            Console.WriteLine(header);
        }

        public static void WriteContent(string content)
        {
            Console.WriteLine($@"      {content}");
        }

        public static void WriteSubContent(string content)
        {
            Console.WriteLine($@"            {content}");
        }

        public static void WriteSelect(string content)
        {
            Console.WriteLine($@"                  {content}");
        }

        public static void WriteSubSelect(string content)
        {
            Console.WriteLine($@"                         {content}");
        }

        public static void WriteFrom(string content)
        {
            Console.WriteLine($@"                    {content}");
        }

        public static void WriteSubFrom(string content)
        {
            Console.WriteLine($@"                         {content}");
        }

        public static void WriteWhere(string content)
        {
            Console.WriteLine($@"                   {content}");
        }

        public static void WriteSubWhere(string content)
        {
            Console.WriteLine($@"                         {content}");
        }

        public static void WriteError(Exception ex)
        {
            Console.WriteLine(string.Format("            ERROR - {0}", ex.Message));
            Console.WriteLine($@"");
        }

        public static void WriteContentObject(object obj)
        {
            string str = JsonConvert.SerializeObject(obj);
            int length = str.Length / 77;
            int from = 0;
            int take = 0;
            for (int i = 0; i <= length; i++)
            {
                from = i * 77;
                take = 77 < (str.Length - from)  ? 77 : (str.Length - from);
                WriteContent(str.Substring(from, take));
            }
            
        }

        public static void WriteSubContentObject(object obj)
        {
            string str = JsonConvert.SerializeObject(obj);
            int length = str.Length / 77;
            int from = 0;
            int take = 0;
            for (int i = 0; i <= length; i++)
            {
                from = i * 77;
                take = 77 < (str.Length - from) ? 77 : (str.Length - from);
                WriteSubContent(str.Substring(from, take));
            }

        }

        public static void WriteSubContentObjectForEachObj(object obj)
        {
            string str = JsonConvert.SerializeObject(obj);
            string[] strArr = str.Split(',');
            foreach (var item in strArr)
            {
                WriteSubContent(item);
            }

        }
    }
}
