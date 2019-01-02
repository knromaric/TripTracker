using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using TripTracker.Services;

namespace TripTracker.ViewModels
{
    public class DetailViewModel: BaseViewModel<TripTrackerEntry>
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

        public DetailViewModel(INavService navService): base(navService)
        {

        }

        public override async Task Init(TripTrackerEntry entry)
        {
            _entry = entry;
        }
    }
}
