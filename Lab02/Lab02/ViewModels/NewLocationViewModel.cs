using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab02.ViewModels
{
    public class NewLocationViewModel : BaseViewModel
    {
        private string cityname;
        private string image;

        public NewLocationViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(cityname)
                && !String.IsNullOrWhiteSpace(image);
        }

        public string CityName
        {
            get => cityname;
            set => SetProperty(ref cityname, value);
        }

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public Command SaveCommand { get; }

        private async void OnSave()
        {
            Location newLocation = new Location()
            {
                LocationID = Guid.NewGuid().ToString(),
                LocationName = CityName,
                Image = Image
            };

            await LocationDataStore.AddLocationAsync(newLocation);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
