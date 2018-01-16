using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDriveStandard.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDriveStandard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailView : MasterDetailPage
	{
        private readonly Usuario _usuario;
		public MasterDetailView (Usuario usuario)
		{
			InitializeComponent ();

		    _usuario = usuario;
		    Master = new MasterView(usuario);
		}
	}
}