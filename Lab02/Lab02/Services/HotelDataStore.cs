using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public interface HotelDataStore<T>
    {
        Task<bool> AddHotelAsync(T hotel);
        Task<bool> UpdateHotelAsync(T hotel);
        Task<bool> DeleteLastHotelAsync();
        Task<T> GetHotelAsync(string id);
        Task<IEnumerable<T>> GetHotelsAsync(bool forceRefresh = false);
    }
}
