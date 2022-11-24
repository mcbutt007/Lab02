using SQLite;
using System;

namespace Lab02.Models
{
    public class Hotel
    {
        [PrimaryKey, AutoIncrement]
        public string HotelID { get; set; }
        public string LocationID { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Introduce { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
    }
}
