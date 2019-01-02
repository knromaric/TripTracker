using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using TripTracker.Services;
using TripTracker.ViewModels;
using Xamarin.Forms;

namespace TripTracker.Views
{
	public partial class MainPage : ContentPage
	{
        private MainViewModel _vm
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainViewModel(DependencyService.Get<INavService>());
		}

		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new NewEntryPage());
		}

		private async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var trip = (TripTrackerEntry)e.Item;

            _vm.ViewCommand.Execute(trip);

            Trips.SelectedItem = null;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Initialize MainViewModel

            if (_vm != null)
                await _vm.Init();
        }
    }
}
