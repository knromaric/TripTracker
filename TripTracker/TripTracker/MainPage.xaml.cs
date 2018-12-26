using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using Xamarin.Forms;

namespace TripTracker
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            var items = new List<TripTrackerEntry>
            {
                new TripTrackerEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing",
                    Rating = 3,
                    Date = new DateTime(2018, 2,5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                 new TripTrackerEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring",
                    Rating = 4,
                    Date = new DateTime(2018, 4,13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new TripTrackerEntry
                {
                    Title = "Golden State Bridge",
                    Notes = "Foggy, But beautiful",
                    Rating = 5,
                    Date = new DateTime(2018, 4,26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
               
            };

            trips.ItemsSource = items;
        }
	}
}
