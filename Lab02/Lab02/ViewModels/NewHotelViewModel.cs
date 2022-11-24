using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab02.ViewModels
{
    public class NewHotelViewModel : BaseViewModel
    {
        private string hotelname;
        private string image;
        private string city;
        public ObservableCollection<Location> Locations { get; }

        public List<Location> CityList { get; set; }

        public NewHotelViewModel()
        {
            Locations = new ObservableCollection<Location>();
            SaveCommand = new Command(OnSave, ValidateSave);
            _ = ExecuteLoadLocationsCommand();
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        async Task ExecuteLoadLocationsCommand()
        {
                Locations.Clear();
                var locations = await LocationDataStore.GetLocationsAsync(true);
                foreach (var location in locations)
                {
                    Locations.Add(location);
                }
                CityList = Locations.ToList();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(hotelname)
                && !String.IsNullOrWhiteSpace(image)
                && !String.IsNullOrWhiteSpace(city);
        }

        public string HotelName
        {
            get => hotelname;
            set => SetProperty(ref hotelname, value);
        }

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public Command SaveCommand { get; }

        private async void OnSave()
        {
            Hotel newHotels = new Hotel()
            {
                HotelID = Guid.NewGuid().ToString(),
                HotelName = HotelName,
                Image = Image,
                LocationID = City
            };

            string message = "Thêm mới thành công";
            try
            {
            await HotelDataStore.AddHotelAsync(newHotels);
            } catch (Exception ex)
            {
                message = ex.Message;
            } finally
            {
                await App.Current.MainPage.DisplayAlert("Alert", message, "OK");
            }

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
