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
	public partial class ListagemView /*: ContentPage */
	{
        public ListagemViewModel ViewModel { get; set; }

		public ListagemView ()
		{
			InitializeComponent ();

		    ViewModel = new ListagemViewModel();
		    BindingContext = ViewModel;
		}

        // ao aparecer
        protected  override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.GetVeiculos();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",(veiculo) =>
                {
                    Navigation.PushAsync(new DetalheView(veiculo));
                });
        }
    }
}