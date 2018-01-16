using TestDriveStandard.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDriveStandard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
		}

        protected  override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "LoginFalha",
                async (exc) => { await DisplayAlert("Login", exc.Message, "Ok"); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "LoginFalha");
        }
    }
}