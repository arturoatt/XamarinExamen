using System;

namespace XamarinExamen.IServices
{
    public interface IUnitOfwork:IDisposable
    {
        IProductService Products { get; }
    }
}
