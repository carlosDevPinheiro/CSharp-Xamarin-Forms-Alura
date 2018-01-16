using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using TestDriveStandard.Models;
using TestDriveStandard.Services;
using TestDriveStandard.ViewModels.Base;
using Xamarin.Forms;

namespace TestDriveStandard.ViewModels
{
    public class LoginViewModel
    {

        public LoginViewModel()
        {
           

            EntrarCommand = new Command(async () =>
                {
                    //MessagingCenter.Send<Usuario>(new Usuario(), "LoginSucesso");

                    var loginService = new LoginService();
                    await loginService.FazerLogin(new Login(_usuario, _senha));
                },
                () => !string.IsNullOrEmpty(_usuario) && !string.IsNullOrEmpty(_senha));
        }


        private string _usuario;
        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                ((Command)EntrarCommand)?.ChangeCanExecute();
            }
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set
            {
                _senha = value;
                ((Command)EntrarCommand)?.ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }
    }
}