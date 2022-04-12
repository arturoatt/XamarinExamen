using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinExamen.IServices;
using System.Text.Json;
using System.Text;

namespace XamarinExamen.Services
{
    public class Service<T> : IServices<T> where T : class
    {
        protected readonly HttpClient _httpclient;

        public Service(HttpClient httpclient)
        {
            this._httpclient = httpclient;
        }

        public async Task<T> AddItemAsync(string url, T item)
        {

            var serialize = JsonSerializer.Serialize(item);
            var body = new StringContent(serialize, Encoding.UTF8, "application/json");
            var response = await _httpclient.PostAsync(url, body);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(result);
            }

            return null;
        }

        public async Task<bool> DeleteItemAsync(string url)
        {
            var response = await _httpclient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<T> GetItemAsync(string url)
        {

            var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(result);
            }

            return null;
        }

        public async Task<List<T>> GetItemsAsync(string url)
        {
            var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<T>>(result);
            }

            return null;
        }

        public async Task<bool> UpdateItemAsync(string url, T item)
        {
            var serialize = JsonSerializer.Serialize(item);
            var body = new StringContent(serialize, Encoding.UTF8, "application/json");
            var response = await _httpclient.PutAsync(url, body);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
