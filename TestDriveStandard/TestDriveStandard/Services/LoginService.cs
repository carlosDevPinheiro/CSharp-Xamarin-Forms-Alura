using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDriveStandard.Models;
using Xamarin.Forms;

namespace TestDriveStandard.Services
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            try
            {
                HttpResponseMessage resultado = null;

                using (var cliente = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("email", login.Email),
                    new KeyValuePair<string, string>("senha", login.Senha)
                });

                    cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                     resultado = await cliente.PostAsync("/login", camposFormulario);
                }

                if (resultado.IsSuccessStatusCode)
                {
                    var conteudoResultado = await resultado.Content.ReadAsStringAsync();
                    var resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);
                    MessagingCenter.Send(resultadoLogin.usuario, "LoginSucesso");  // avisa o app.xaml.cs iniciar a navegação em pilha

                }
                else
                    MessagingCenter.Send(new LoginException("Usuário ou senha incorreto"), "LoginFalha");  // avisa a tela de login que houve um erro
            }
            catch 
            {
                MessagingCenter.Send(new LoginException(@"Houve um erro de cominicação com servidor.
verifique sua Conexão com Iternet e tente novamente.
Talvez seja preciso fechar o aplicativo e abrir novamente"), "LoginFalha");  // avisa a tela de login que houve um erro

            }
        }
    }

    class LoginException: Exception
    {
        public LoginException(string message): base(message)
        {
            
        }
    }
}
