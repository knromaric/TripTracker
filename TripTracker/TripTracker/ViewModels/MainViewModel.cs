using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TripTracker.Models;
using TripTracker.Services;
using Xamarin.Forms;

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

        private Command<TripTrackerEntry> _viewCommand;
        public Command<TripTrackerEntry> ViewCommand
        {
            get
            {
                return _viewCommand ?? (_viewCommand = new Command<TripTrackerEntry>(async (entry) => await ExecuteViewCommand(entry)));
            }
        }

        Command _newCommand;
        public Command NewCommand
        {
            get
            {
                return _newCommand
                    ?? (_newCommand = new Command(async () => await ExecuteNewCommand()));
            }
        }

        private async Task ExecuteViewCommand(TripTrackerEntry entry)
        {
            await NavService.NavigateTo<DetailViewModel, TripTrackerEntry>(entry);
        }

        private async Task ExecuteNewCommand()
        {
            await NavService.NavigateTo<NewEntryViewModel>();
        }

        public MainViewModel(INavService navService) : base(navService)
        {
            TripEntries = new ObservableCollection<TripTrackerEntry>();
        }

        public override async Task Init()
        {
            await LoadEntries();
        }

        async Task LoadEntries()
        {
            _tripEntries.Clear();

            await Task.Factory.StartNew(() => {
                _tripEntries.Add(new TripTrackerEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing",
                    Rating = 3,
                    Date = new DateTime(2018, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                });

                _tripEntries.Add(new TripTrackerEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring",
                    Rating = 4,
                    Date = new DateTime(2018, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                });

                _tripEntries.Add(new TripTrackerEntry
                {
                    Title = "Golden State Bridge",
                    Notes = "Foggy, But beautiful",
                    Rating = 5,
                    Date = new DateTime(2018, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                });
            });
        }
    }
}
