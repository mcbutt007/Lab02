using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public interface LocationDataStore<T>
    {
        Task<T> GetLocationAsync(string id);
        Task<IEnumerable<T>> GetLocationsAsync(bool forceRefresh = false);
    }
}
