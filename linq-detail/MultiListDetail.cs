using demo_linq.database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace demo_linq.linq_detail
{
    public static class MultiListDetail
    {
        public static void Show()
        {
            ShowDetails();
        }

        private static void ShowDetails()
        {
            ShowExample();
        }
        public static void ShowExample()
        {
            var roomList = GetRoomList();
            var roomDetailList = GetRoomDetailList();


            var watch = new Stopwatch();
            watch.Start();
            var GetRoomInfoList = GetRoomInfoListUsingJoin(roomList, roomDetailList);
            watch.Stop();
            var joinTime = watch.Elapsed;
            Console.WriteLine($"time eplased - GetRoomInfoListUsingJoin       - {joinTime}");


            watch = new Stopwatch();
            watch.Start();
            var GetRoomInfoListDic = GetRoomInfoListUsingDictionary(roomList, roomDetailList);
            watch.Stop();
            var dicTime = watch.Elapsed;
            Console.WriteLine($"time eplased - GetRoomInfoListUsingDictionary - {dicTime}");
            Console.WriteLine($"joinTime / dicTime = {joinTime/dicTime}");
        }

        private static IEnumerable<object> GetRoomInfoListUsingJoin(List<Room> roomList, List<RoomDetail> roomDetailList)
        {
            var rst =   from r in roomList
                        join rd in roomDetailList
                        on r.RoomId equals rd.RoomId
                        select new 
                        {
                            RoomId = r.RoomId,
                            DateIn = rd.DateIn,
                            DateOut = rd.DateOut,
                            Desc = rd.Description
                        };

            return rst;
        }

        private static IEnumerable<object> GetRoomInfoListUsingDictionary(List<Room> roomList, List<RoomDetail> roomDetailList)
        {
            var detailDic = roomDetailList.ToDictionary(x => x.RoomId, x => x);
            foreach (var room in roomList)
            {
                var detail = detailDic[room.RoomId];
                yield return new 
                {
                    RoomId = room.RoomId,
                    DateIn = detail.DateIn,
                    DateOut = detail.DateOut,
                    Desc = detail.Description
                };
            }
        }

        private static List<RoomDetail> GetRoomDetailList()
        {
            using (var context = new eroomContext())
            {
                return context.RoomDetail.ToList();
            }
        }

        private static List<Room> GetRoomList()
        {
            using (var context = new eroomContext())
            {
                return context.Room.ToList();
            }
        }
    }
}
