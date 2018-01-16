using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDriveStandard.Models;
using TestDriveStandard.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDriveStandard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : ContentPage
	{
	    public MasterViewModel ViewModel { get; set; }

		public MasterView (Usuario usuario)
		{
			InitializeComponent ();

		    ViewModel = new MasterViewModel(usuario);
		    BindingContext = ViewModel;
            
		}
	}
}