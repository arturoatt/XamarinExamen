using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExamen.Models;
using XamarinExamen.ViewModels;
using XamarinExamen.Views;

namespace XamarinExamen.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
           
            subscribeMessages();
        }

        private void subscribeMessages()
        {
            MessagingCenter.Subscribe<ItemsViewModel, string>(this, "EX", async (sender, arg) =>
            {
                await DisplayAlert("Aviso", "Servicio no disponible, intente mas tarde", "OK");
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();            
        }
    }
}