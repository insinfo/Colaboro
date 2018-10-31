
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colaboro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            btnCadastro.Clicked += BtnCadastro_Clicked;
        }

        private async void BtnCadastro_Clicked(object sender, System.EventArgs e)
        {
            // await Navigation.PushAsync(new CadastroPage());

            await Navigation.PushModalAsync(new CadastroPage());
        }

        /*
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        */

    }
}