using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewEntryPage : ContentPage
	{
		public NewEntryPage ()
		{
			InitializeComponent ();
            BindingContext = new NewEntryViewModel();
		}

	}
}