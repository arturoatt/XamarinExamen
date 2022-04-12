using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinExamen.Models;
using XamarinExamen.Services;

namespace XamarinExamen.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string name;
        private string price;
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var url = $"{App.Current.Resources["BaseURL"]}{App.Current.Resources["ProductsURL"]}?id={itemId}";
                var item = await UnitOfWork.GetInstance.Products.GetItemAsync(url);
                Id = item.Id;
                Name = item.Name;
                Price = item.Price.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void ModifyItemId()
        {
            try
            {
                Product item = new Product()
                {
                    Id = ItemId,
                    Name = Name,
                    Price = Decimal.Parse(Name)
                };
                var url = $"{App.Current.Resources["BaseURL"]}{App.Current.Resources["ProductsURL"]}?id={ItemId}";
                await UnitOfWork.GetInstance.Products.UpdateItemAsync(url, item);

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                
            }
        }
        public async void DeleteItemId()
        {
            try
            {                
                var url = $"{App.Current.Resources["BaseURL"]}{App.Current.Resources["ProductsURL"]}?id={ItemId}";
                await UnitOfWork.GetInstance.Products.DeleteItemAsync(url);

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                
            }
        }
    }
}
