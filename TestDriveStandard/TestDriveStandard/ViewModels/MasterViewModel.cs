using TestDriveStandard.Models;

namespace TestDriveStandard.ViewModels
{
    public class MasterViewModel
    {
        private readonly Usuario _usuario;
        public MasterViewModel(Usuario usuario)
        {
            _usuario = usuario;
        }

        
        public string Nome
        {
            get => _usuario.nome;
            set => _usuario.nome = value;
        }

        
        public string Email
        {
            get  =>  _usuario.email;
            set => _usuario.email = value;
        }
       
    }
}