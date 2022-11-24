using Lab02.Models;
using Lab02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
    public class MockLocationDataStore : LocationDataStore<Location>
    {
        readonly List<Location> locations;

        public MockLocationDataStore()
        {
            locations = new List<Location>()
            {
                new Location { LocationName = "Đà Lạt", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationName = "Vũng Tàu", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationName = "Phú Quốc", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationName = "Hà Nội", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationName = "TP Hồ Chí Minh", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"}
            };
        }

        public async Task<bool> AddLocationAsync(Location location)
        {
            locations.Add(location);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateLocationAsync(Location location)
        {
            var oldLocation = locations.Where((Location arg) => arg.LocationID == location.LocationID).FirstOrDefault();
            locations.Remove(oldLocation);
            locations.Add(location);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var oldLocation = locations.Where((Location arg) => arg.LocationID == id).FirstOrDefault();
            locations.Remove(oldLocation);

            return await Task.FromResult(true);
        }

        public async Task<Location> GetLocationAsync(int id)
        {
            return await Task.FromResult(locations.FirstOrDefault(s => s.LocationID == id));
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(locations);
        }
    }

    public class MockHotelDataStore : HotelDataStore<Hotel>
    {
        readonly List<Hotel> hotels;

        public MockHotelDataStore()
        {
            hotels = new List<Hotel>()
            {
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Đà Lạt 1", LocationID="1", Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Đà Lạt 2", LocationID="1" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Đà Lạt 3", LocationID="1" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Đà Lạt 4", LocationID="1" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Đà Lạt 5", LocationID="1" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Vũng Tàu 1", LocationID="2" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Vũng Tàu 2", LocationID="2" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Vũng Tàu 3", LocationID="2" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Vũng Tàu 4", LocationID="2" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Vũng Tàu 5", LocationID="2" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Phú Quốc 1", LocationID="3" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Phú Quốc 2", LocationID="3" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Phú Quốc 3", LocationID="3" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Phú Quốc 4", LocationID="3" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Phú Quốc 5", LocationID="3" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Hà Nội 1", LocationID="4" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Hà Nội 2", LocationID="4" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Hà Nội 3", LocationID="4" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Hà Nội 4", LocationID="4", Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available" },
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="Hà Nội 5", LocationID="4" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="TP Hồ Chí Minh 1", LocationID="5" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="TP Hồ Chí Minh 2", LocationID="5" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="TP Hồ Chí Minh 3", LocationID="5" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="TP Hồ Chí Minh 4", LocationID="5" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"},
                new Hotel { HotelID = Guid.NewGuid().ToString(), HotelName="TP Hồ Chí Minh 5", LocationID="5" , Image = "https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg", Status="Available"}
            };
        }
        public async Task<bool> AddHotelAsync(Hotel hotel)
        {
            hotels.Add(hotel);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateHotelAsync(Hotel hotel)
        {
            var oldHotel = hotels.Where((Hotel arg) => arg.HotelID == hotel.HotelID).FirstOrDefault();
            hotels.Remove(oldHotel);
            hotels.Add(hotel);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteHotelAsync(string id)
        {
            var oldHotel = hotels.Where((Hotel arg) => arg.HotelID == id).FirstOrDefault();
            hotels.Remove(oldHotel);

            return await Task.FromResult(true);
        }

        public async Task<Hotel> GetHotelAsync(string id)
        {
            return await Task.FromResult(hotels.FirstOrDefault(s => s.HotelID == id));
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(hotels);
        }
    }
}