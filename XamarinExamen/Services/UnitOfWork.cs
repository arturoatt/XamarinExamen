using System;
using System.Net.Http;
using System.Net.Http.Headers;
using XamarinExamen.IServices;

namespace XamarinExamen.Services
{
    public class UnitOfWork : IUnitOfwork
    {        
        private readonly HttpClient _httpclient;
        public UnitOfWork(HttpClient httpclient)
        {
            //httpclient.BaseAddress = new Uri(App.Current.Resources["BaseURL"].ToString());
            httpclient.DefaultRequestHeaders.Accept.Clear();
            httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpclient = httpclient;
            Products = new ProductService(_httpclient);
        }

        static readonly UnitOfWork instance = new UnitOfWork(new HttpClient());
        public static UnitOfWork GetInstance
        {
            get { return instance; }
        }

        public IProductService Products { get; private set; }

        public void Dispose()
        {
            _httpclient.Dispose();
        }
    }
}
