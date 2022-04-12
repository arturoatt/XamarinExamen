using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinExamen.Models;
using XamarinExamen.ViewModels;

namespace XamarinExamen.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
            subscribeMessages();
        }
        private void subscribeMessages()
        {
            MessagingCenter.Subscribe<NewItemViewModel, string>(this, "EX", async (sender, arg) =>
            {
                await DisplayAlert("Aviso", "Servicio no disponible, intente mas tarde", "OK");
            });
        }
    }
}