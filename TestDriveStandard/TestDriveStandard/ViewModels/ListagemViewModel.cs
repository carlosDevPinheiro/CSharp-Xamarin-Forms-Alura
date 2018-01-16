using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDriveStandard.Models;
using Xamarin.Forms;
using System.Linq;
using TestDriveStandard.ViewModels.Base;

namespace TestDriveStandard.ViewModels
{
    public class ListagemViewModel: BaseViewModel
    {
        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Veiculo>();
        }

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        private bool _aguarde;

        public bool Aguarde
        {
            get =>_aguarde; 
            set
            {
                _aguarde = value;
                OnPropertyChanged();
            }
        }



        private Veiculo _veiculo;

        public Veiculo VeiculoSelecionado
        {
            get => _veiculo;
            set
            {
                _veiculo = value;
                if (_veiculo != null)
                    // enviando para listagemViewModel.xaml.cs  pois ela tem a propriedade de Navegação
                    MessagingCenter.Send(_veiculo, "VeiculoSelecionado");
            }
        }

        private const string UrlGetVeiculos = "http://aluracar.herokuapp.com/";

        public async Task GetVeiculos()
        {
            Aguarde = true;

            try
            {
                HttpClient cliente = new HttpClient();
                var resultado = await cliente.GetStringAsync(UrlGetVeiculos);
                var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

                veiculosJson.ToList().ForEach(veic => Veiculos.Add(new Veiculo
                {
                    Nome = veic.nome,
                    Preco = veic.preco
                }));

            }
            catch (Exception exc)
            {
                MessagingCenter.Send(exc, "FalhaListagem");
            }

            Aguarde = false;
        }
    }
}