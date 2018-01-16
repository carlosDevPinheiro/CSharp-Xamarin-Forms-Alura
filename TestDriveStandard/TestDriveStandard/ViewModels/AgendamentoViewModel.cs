using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDriveStandard.Models;
using TestDriveStandard.ViewModels.Base;
using Xamarin.Forms;

namespace TestDriveStandard.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public AgendamentoViewModel(Veiculo veiculo)
        {
            Agendamento = new Agendamento { Veiculo = veiculo };

            AgendarCommand = new Command(() =>
                {
                    MessagingCenter.Send(Agendamento, "Agendamento");
                    Debug.WriteLine(
                        "====================================  metodo acionado ===========================");
                }, () =>    !String.IsNullOrEmpty(Nome) &&
                            !string.IsNullOrEmpty(Fone) &&
                            !string.IsNullOrEmpty(Email));
                
        }


        private const string UrlPostAgendamento = "https://aluracar.herokuapp.com/salvaragendamento";
        public Veiculo Veiculo { get => Agendamento.Veiculo; set => Agendamento.Veiculo = value; }
        public Agendamento Agendamento { get; set; }
        public ICommand AgendarCommand { get; set; }

        public string Nome
        {
            get => Agendamento.Nome;
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command) AgendarCommand).ChangeCanExecute();
            } 
        }

        public string Fone
        {
            get => Agendamento.Fone;
            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public string Email
        {
            get => Agendamento.Email;
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get => Agendamento.DataAgendamento;
            set
            {
                Agendamento.DataAgendamento = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraAgendamento
        {
            get => Agendamento.HoraAgendamento;
            set
            {
                Agendamento.HoraAgendamento = value;
                OnPropertyChanged();
            }
        }

        public async void SalvarAgendamento()
        {
            HttpClient client = new HttpClient();


            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                DataAgendamento.Hour, DataAgendamento.Minute, DataAgendamento.Second);

            var objetoJson = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var body = new StringContent(objetoJson, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync(UrlPostAgendamento, body);

            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send(Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send(new ArgumentException(), "FalhaAgendamento");

            }
        }
    }
}