using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExamen.Models;
using XamarinExamen.Services;

namespace XamarinExamen.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private int itemId = 0;
        private string name;
        private string price = "0";
        public int Id { get; set; }

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            decimal _try;
            if(String.IsNullOrWhiteSpace(name)||!Decimal.TryParse(price,out _try))
                return false;

            return true;                
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private void OnSave()
        {
            if (itemId == 0)
                AddItem();
            else
                ModifyItem();
        }

        public async void AddItem()
        {
            try
            {
                Product newItem = new Product()
                {
                    Name = Name,
                    Price = Decimal.Parse(Name)
                };
                var url = $"{App.Current.Resources["BaseURL"]}{App.Current.Resources["ProductsURL"]}";
                await UnitOfWork.GetInstance.Products.AddItemAsync(url, newItem);
                
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                MessagingCenter.Send<NewItemViewModel, string>(this, "EX", "");
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
                MessagingCenter.Send<NewItemViewModel, string>(this, "EX", "");
            }
        }

        public async void ModifyItem()
        {
            try
            {
                Product item = new Product()
                {
                    Id = Id,
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
                MessagingCenter.Send<NewItemViewModel, string>(this, "EX", "");
            }
        }
    }
}
