using XamarinExamen.Models;
using XamarinExamen.IServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace XamarinExamen.Services
{
    public class ProductService : Service<Product>, IProductService
    {        
        public ProductService(HttpClient httpclient) : base(httpclient)
        {

        }        
    }
}
