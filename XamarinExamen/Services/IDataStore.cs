using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinExamen.Models;

namespace XamarinExamen.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(Item item);
        Task<bool> UpdateItemAsync(Item item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false);
    }
}