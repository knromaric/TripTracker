﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using TripTracker.Services;
using TripTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        private DetailViewModel _vm
        {
            get { return BindingContext as DetailViewModel; }
        }

		public DetailPage ()
		{
			InitializeComponent ();
            BindingContext = new DetailViewModel(DependencyService.Get<INavService>());
        }

        private void UpdateMap()
        {
            if (_vm.Entry == null)
                return;

            // Centrer the map around the log location
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_vm.Entry.Latitude, _vm.Entry.Longitude), Distance.FromMiles(0.5)));


            // pin the map 
            MyMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = _vm.Entry.Title,
                Position = new Position(_vm.Entry.Latitude, _vm.Entry.Longitude)
            });
        }

        void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(DetailViewModel.Entry))
            {
                UpdateMap();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_vm != null)
            {
                _vm.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if(_vm != null)
            {
                _vm.PropertyChanged -= OnViewModelPropertyChanged;
            }
        }


    }
}