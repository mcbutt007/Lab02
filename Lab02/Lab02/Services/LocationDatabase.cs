using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using Lab02.Models;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public class LocationDatabase
    {
        readonly SQLiteAsyncConnection database;
        public LocationDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Location>().Wait();
        }
        public Task<List<Location>> GetLocationsAsync()
        {
            //Get all locations.
            return database.Table<Location>().ToListAsync();
        }

        public Task<Location> GetLocationAsync(int id)
        {
            // Get a specific location.
            return database.Table<Location>()
                            .Where(i => (i.LocationID) == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLocationAsync(Location location)
        {
            if ((location.LocationID) != 0)
            {
                // Update an existing location.
                return database.UpdateAsync(location);
            }
            else
            {
                // Save a new location.
                return database.InsertAsync(location);
            }
        }

        public Task<int> DeleteLocationAsync(Location location)
        {
            // Delete a location.
            return database.DeleteAsync(location);
        }
    }
}
