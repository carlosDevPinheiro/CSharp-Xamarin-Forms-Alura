using System.Windows.Input;
using TestDriveStandard.Models;
using TestDriveStandard.ViewModels.Base;
using Xamarin.Forms;

namespace TestDriveStandard.ViewModels
{
    public class DetalheViewModel: BaseViewModel
    {
        public DetalheViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;

            ProximoCommand = new Command(() => { MessagingCenter.Send(veiculo, "Proximo"); });
        }

        public const int FreiosAbs = 800;
        public const int ArCondcionado = 1000;
        public const int Mp3Player = 400;

        public Veiculo Veiculo { get; }
        public ICommand ProximoCommand { get; }

        public string TextoFreioAbs => $"Freios ABS - R$ {FreiosAbs}";
        public string TextoArCondicionado => string.Format("Ar Condicionado - R$ {0}", ArCondcionado);
        public string TextoMp3Player => string.Format("MP3 PLayer - R$ {0}", Mp3Player);

        private bool _temFreioABS;
        public bool TemFreioAbs
        {
            get => _temFreioABS; 
            set
            {
                _temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool _temArCondicionado;
        public bool TemArCondicionado
        {
            get => _temArCondicionado;
            set
            {
                _temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool _temMP3Player;

        public bool TemMP3Player
        {
            get => _temMP3Player;
            set
            {
                _temMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal => string.Format("Valor Total: R$ {0}", Veiculo.Preco
                                                                         + (TemFreioAbs ? FreiosAbs : 0)
                                                                         + (TemArCondicionado ? ArCondcionado : 0)
                                                                         + (TemMP3Player ? Mp3Player : 0));

    }
}