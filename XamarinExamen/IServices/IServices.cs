using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinExamen.Models;

namespace XamarinExamen.IServices
{
    public interface IServices<T> where T : class
    {
        Task<T> AddItemAsync(string url, T item);
        Task<bool> UpdateItemAsync(string url, T item);
        Task<bool> DeleteItemAsync(string url);
        Task<T> GetItemAsync(string url);
        Task<List<T>> GetItemsAsync(string url);
    }
}
