using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab02.ViewModels
{
    public class NewHotelViewModel : BaseViewModel
    {
        private string hotelname;
        private string image;
        private string city;

        public NewHotelViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
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

            await HotelDataStore.AddHotelAsync(newHotels);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
