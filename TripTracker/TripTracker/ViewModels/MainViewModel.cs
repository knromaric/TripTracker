using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripTracker.Models;

namespace TripTracker.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TripTrackerEntry> _tripEntries;

        public ObservableCollection<TripTrackerEntry> TripEntries
        {
            get { return _tripEntries; }
            set
            {
                _tripEntries = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            TripEntries = new ObservableCollection<TripTrackerEntry>
            {
                new TripTrackerEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing",
                    Rating = 3,
                    Date = new DateTime(2018, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },

                new TripTrackerEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring",
                    Rating = 4,
                    Date = new DateTime(2018, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },

                new TripTrackerEntry
                {
                    Title = "Golden State Bridge",
                    Notes = "Foggy, But beautiful",
                    Rating = 5,
                    Date = new DateTime(2018, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };
        }
    }
}
