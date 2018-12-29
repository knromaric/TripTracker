using System;
using System.Collections.Generic;
using System.Text;
using TripTracker.Models;

namespace TripTracker.ViewModels
{
    public class DetailViewModel: BaseViewModel
    {
        private TripTrackerEntry _entry; 

        public TripTrackerEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public DetailViewModel(TripTrackerEntry entry)
        {
            Entry = entry;
        }
    }
}
