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
	public partial class NewLocationPage : ContentPage
	{
        public Location Location { get; set; }
		public NewLocationPage ()
		{
			InitializeComponent ();
            BindingContext = new NewLocationViewModel();
		}
	}
}