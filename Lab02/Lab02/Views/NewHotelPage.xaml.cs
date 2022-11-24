using Lab02.Models;
using Lab02.ViewModels;
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
	public partial class NewHotelPage : ContentPage
	{
        public Hotel Hotel { get; set; }
		public NewHotelPage ()
		{
			InitializeComponent ();
            BindingContext = new NewHotelViewModel();
		}
	}
}