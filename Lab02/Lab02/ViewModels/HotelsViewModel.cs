using Lab02.Models;
using Lab02.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab02.ViewModels
{
    [QueryProperty(nameof(LocationID), nameof(LocationID))]
    public class HotelsViewModel : BaseViewModel
    {
        private string locationID;
        public ObservableCollection<Hotel> Hotels { get; }
        public Command LoadHotelsCommand { get; }
        public Command DeleteLastHotelCommand { get; }
        public Command AddHotelCommand { get; }
        public Command<Hotel> HotelTapped { get; }
        public string LocationID
        {
            get
            {
                return locationID;
            }
            set
            {
                locationID = value;
            }
        }

        public HotelsViewModel()
        {
            Title = "Browse";
            Hotels = new ObservableCollection<Hotel>();
            LoadHotelsCommand = new Command(async () => await ExecuteLoadHotelsCommand());

            DeleteLastHotelCommand = new Command(async () => await DeleteLastHotel());
        }

        async Task DeleteLastHotel()
        {
            bool answer = false;
            answer = await Application.Current.MainPage.DisplayAlert("Warning!", "Do you want to delete it?", "Yes", "No");
            if (Hotels.Count > 0 && answer == true)
            {
                await HotelDataStore.DeleteLastHotelAsync();
                await ExecuteLoadHotelsCommand();
            }
        }

        async Task ExecuteLoadHotelsCommand()
        {
            IsBusy = true;

            try
            {
                Hotels.Clear();
                var hotels = await HotelDataStore.GetHotelsAsync(true);
                foreach (var hotel in hotels)
                {
                    if (hotel.LocationID != locationID)
                        continue;
                    Hotels.Add(hotel);
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
        }
    }
}