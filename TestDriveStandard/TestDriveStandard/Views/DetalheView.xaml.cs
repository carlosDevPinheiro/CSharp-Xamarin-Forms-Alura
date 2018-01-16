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
	public partial class DetalheView : ContentPage
	{
	    public Veiculo Veiculo { get; set; }

		public DetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
		    Title = veiculo.Nome;

		    Veiculo = veiculo;
		    BindingContext = new DetalheViewModel(veiculo);
		}

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo",
                (veiculo) =>
                {
                    Navigation.PushAsync(new AgendamentoView(veiculo));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}