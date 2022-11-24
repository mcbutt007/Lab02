using Lab02.Models;
using Lab02.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab02.ViewModels
{
    public class LocationsViewModel : BaseViewModel
    {
        private Location _selectedLocation;

        public ObservableCollection<Location> Locations { get; }
        public Command LoadLocationsCommand { get; }
        public Command<Location> LocationTapped { get; }
        public Command AddLocationCommand { get; }

        public LocationsViewModel()
        {
            Title = "Thành phố";
            Locations = new ObservableCollection<Location>();
            LoadLocationsCommand = new Command(async () => await ExecuteLoadLocationsCommand());

            LocationTapped = new Command<Location>(OnLocationSelected);
            AddLocationCommand = new Command(OnAddLocation);
        }

        async void OnAddLocation(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewLocationPage));
        }

        async Task ExecuteLoadLocationsCommand()
        {
            IsBusy = true;

            try
            {
                Locations.Clear();
                var locations = await LocationDataStore.GetLocationsAsync(true);
                foreach (var location in locations)
                {
                    Locations.Add(location);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedLocation = null;
        }

        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                SetProperty(ref _selectedLocation, value);
                OnLocationSelected(value);
            }
        }

        async void OnLocationSelected(Location location)
        {
            if (location == null)
            {
            //await App.Current.MainPage.DisplayAlert("Alert", "Hello" , "OK");

                return;
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(HotelsPage)}?{nameof(HotelsViewModel.LocationID)}={location.LocationID}");
        }
    }
}