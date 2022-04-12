using System.ComponentModel;
using Xamarin.Forms;
using XamarinExamen.ViewModels;

namespace XamarinExamen.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}