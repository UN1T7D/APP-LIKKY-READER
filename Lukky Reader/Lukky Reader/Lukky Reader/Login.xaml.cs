using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lukky_Reader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void AgregarUusario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.AgregarUsuario());
        }
    }
}