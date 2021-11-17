using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_linq.linq_detail
{
    public static class IQueryableDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            Console.WriteLine("IQueryable: in System.Linq, implements IEnumerable");
            Console.WriteLine("IQueryable: suitable for querying data from out-memory: database");
            Console.WriteLine("IQueryable: beneficial for LINQ to SQL queries");
            Console.WriteLine("IQueryable: executes a 'select query' on server-side with all filters => suitable for paging");
            ShowExample();
        }
        private static void ShowExample()
        {
            Console.WriteLine("----------------------------------------------------------------Example----------------------------------------------------------------");
            ShowExample_QueryFromDb();
            Console.WriteLine("----------------------------------------------------------------END Example----------------------------------------------------------------");
        }
     

        private static void ShowExample_QueryFromDb()
        {
            using (var context = new eroomContext())
            {
                IQueryable<Room> roomsList = context.Room.Where(r => r.RoomName != null);
                Console.WriteLine($@"IQueryable: executes a 'select query' on server-side with all filters");
                Console.WriteLine($@"      get roomList: IQueryable<Room> roomsList = context.Room.Where(r => r.RoomName != null);");
                Console.WriteLine($@"            The query is not called yet => deferred execution");
                Console.WriteLine($@"      ");

                foreach (var room in roomsList) { }

                Console.WriteLine($@"      foreach: foreach (var room in roomsList)");
                Console.WriteLine($@"            The query is:");
                Console.WriteLine($@"                  SELECT [r].[RoomID], [r].[CreateDate], [r].[CreateUser], [r].[DeleteDate],");
                Console.WriteLine($@"                         [r].[DeleteUser], [r].[Description], [r].[IsActive], [r].[IsDelete],");
                Console.WriteLine($@"                         [r].[RoomName], [r].[RoomTypeID], [r].[StatusID], [r].[UpdateDate],");
                Console.WriteLine($@"                         [r].[UpdateUser]");
                Console.WriteLine($@"                  FROM[Room] AS[r]");
                Console.WriteLine($@"                  WHERE[r].[RoomName] IS NOT NULL");
                Console.WriteLine($@"      ");

                roomsList.Count();
                Console.WriteLine($@"      count: roomsList.Count();");
                Console.WriteLine($@"            The query is: SELECT COUNT(*) FROM [Room] AS [r] WHERE [r].[RoomName] IS NOT NULL");
                Console.WriteLine($@"      ");

                roomsList = roomsList.Take<Room>(3);
                Console.WriteLine($@"      take: roomsList = roomsList.Take<Room>(3);");
                Console.WriteLine($@"            The query is:");
                Console.WriteLine($@"                  SELECT top (3) [r].[RoomID], [r].[CreateDate], [r].[CreateUser], [r].[DeleteDate],");
                Console.WriteLine($@"                                 [r].[DeleteUser], [r].[Description], [r].[IsActive], [r].[IsDelete],");
                Console.WriteLine($@"                                 [r].[RoomName], [r].[RoomTypeID], [r].[StatusID], [r].[UpdateDate],");
                Console.WriteLine($@"                                 [r].[UpdateUser]");
                Console.WriteLine($@"                  FROM[Room] AS[r]");
                Console.WriteLine($@"                  WHERE[r].[RoomName] IS NOT NULL");
                Console.WriteLine($@"      ");
                Console.WriteLine($@"      ===>IQueryable is suitable for paging");

                var obj = roomsList.FirstOrDefault();
            }
        }

    }
}
