using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Location> locations;
        readonly List<Hotel> hotels;
        readonly List<Genera> genus;
        readonly List<Specie> species;

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
            locations = new List<Location>()
            {
                new Location { LocationID = Guid.NewGuid().ToString(), LocationName = "Đà Lạt", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationID = Guid.NewGuid().ToString(), LocationName = "Vũng Tàu", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationID = Guid.NewGuid().ToString(), LocationName = "Phú Quốc", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationID = Guid.NewGuid().ToString(), LocationName = "Hà Nội", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"},
                new Location { LocationID = Guid.NewGuid().ToString(), LocationName = "TP Hồ Chí Minh", Image = "https://a.cdn-hotels.com/gdcs/production154/d1245/0a3c326f-cedf-4cf9-ada2-71f7517d0a09.jpg"}
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
}