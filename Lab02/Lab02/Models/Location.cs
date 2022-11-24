using SQLite;
using System;

namespace Lab02.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Image { get; set; }
    }
}
