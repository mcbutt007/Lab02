using Lab02.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Lab02.Views
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