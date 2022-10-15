﻿using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        LocationsViewModel _viewModel;
        public LocationsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new LocationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}