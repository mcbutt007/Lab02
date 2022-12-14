using Lab02.ViewModels;
using Lab02.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lab02
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(HotelsPage), typeof(HotelsPage));
            Routing.RegisterRoute(nameof(NewLocationPage), typeof(NewLocationPage));
            Routing.RegisterRoute(nameof(NewHotelPage), typeof(NewHotelPage));
        }

    }
}
