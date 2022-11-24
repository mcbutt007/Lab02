using System;
using System.Collections.Generic;
using System.Text;
 using System.Threading.Tasks;
 using SQLite;
 using Lab02.Models;

namespace Lab02.Services
{
        public class HotelDatabase
        {
            readonly SQLiteAsyncConnection database;

            public HotelDatabase(string dbPath)
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<Hotel>().Wait();
            }

            public Task<List<Hotel>> GetHotelsAsync()
            {
                //Get all hotels.
                return database.Table<Hotel>().ToListAsync();
            }

            public Task<Hotel> GetHotelAsync(int id)
            {
                // Get a specific hotel.
                return database.Table<Hotel>()
                                .Where(i => Int32.Parse(i.HotelID) == id)
                                .FirstOrDefaultAsync();
            }

            public Task<int> SaveHotelAsync(Hotel hotel)
            {
                if (Int32.Parse(hotel.HotelID) != 0)
                {
                    // Update an existing hotel.
                    return database.UpdateAsync(hotel);
                }
                else
                {
                    // Save a new hotel.
                    return database.InsertAsync(hotel);
                }
            }

            public Task<int> DeleteHotelAsync(Hotel hotel)
            {
                // Delete a hotel.
                return database.DeleteAsync(hotel);
            }
        }
}
