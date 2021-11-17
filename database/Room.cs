using System;
using System.Collections.Generic;

namespace demo_linq.database
{
    public partial class Room
    {
        public string RoomId { get; set; }
        public string RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public string StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string DeleteUser { get; set; }
        public string Description { get; set; }
    }
}
