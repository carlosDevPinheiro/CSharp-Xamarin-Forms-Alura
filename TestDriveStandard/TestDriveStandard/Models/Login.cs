namespace TestDriveStandard.Models
{
    public class Login
    {
        public Login(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; }
        public string Senha { get; }

    }
}