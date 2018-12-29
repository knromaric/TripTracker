using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using TripTracker.ViewModels;
using Xamarin.Forms;

namespace TripTracker.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainViewModel();
		}

		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new NewEntryPage());
		}

		private async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var trip = (TripTrackerEntry)e.Item;

			await Navigation.PushAsync(new DetailPage(trip));

			Trips.SelectedItem = null;
		}
	}
}
