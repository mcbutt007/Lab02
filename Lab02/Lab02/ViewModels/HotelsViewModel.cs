using Lab02.Models;
using Lab02.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab02.ViewModels
{
    public class HotelsViewModel : BaseViewModel
    {
        public ObservableCollection<Hotel> Hotels { get; }
        public Command LoadHotelsCommand { get; }
        public Command AddHotelCommand { get; }
        public Command<Hotel> HotelTapped { get; }

        public HotelsViewModel()
        {
            Title = "Browse";
            Hotels = new ObservableCollection<Hotel>();
            LoadHotelsCommand = new Command(async () => await ExecuteLoadHotelsCommand());
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