using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage (TripTrackerEntry entry)
		{
			InitializeComponent ();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(entry.Latitude, entry.Longitude), Distance.FromMiles(1)));

            MyMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = entry.Title,
                Position = new Position(entry.Latitude, entry.Longitude)
            });

            title.Text = entry.Title;
            date.Text = entry.Date.ToString("M");
            rating.Text = $"{entry.Rating} star rating";
            notes.Text = entry.Notes;
        }
	}
}