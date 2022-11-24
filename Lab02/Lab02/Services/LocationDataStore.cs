using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public interface LocationDataStore<T>
    {
        Task<bool> AddLocationAsync(T location);
        Task<bool> UpdateLocationAsync(T location);
        Task<bool> DeleteLocationAsync(int id);
        Task<T> GetLocationAsync(int id);
        Task<IEnumerable<T>> GetLocationsAsync(bool forceRefresh = false);
    }
}
