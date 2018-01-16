using System;
using TestDriveStandard.Models;
using TestDriveStandard.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDriveStandard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView /*: ContentPage */
	{
		public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();

		    Veiculo = veiculo;
		    ViewModel = new AgendamentoViewModel(veiculo);
		    BindingContext = ViewModel;
		}


	    public Veiculo Veiculo { get; set; }
	    public AgendamentoViewModel ViewModel { get; set; }

	    protected  override  void OnAppearing()
	    {
	        base.OnAppearing();



            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (agendamento) =>
            {

                var resposta = await DisplayAlert("Agendamento", "Deseja reallizar esse agendamento ?", "Sim", "Nao");

                if (resposta)
                {
                    ViewModel.SalvarAgendamento();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (agendamento) =>
            {
                DisplayAlert("Sucesso", $"Agendamento Carro { agendamento.Veiculo.Nome } efetuado com sucesso", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (erro) =>
            {
                DisplayAlert("Erro", "Não foi possivel realizar o agendamento tente mais tarde :(", "Ok");
            });
        }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();

	        MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");

	        MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
	        MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
	    }
	}


}
