using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lukky_Reader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class configuraciones : ContentPage
    {
        public int id_usuario;
        public configuraciones(int id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            BuscarUsuario();
            


        }

        public async void BuscarUsuario()
        {
            string url = "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/usuario/" + id_usuario;

            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetAsync(url);
            var json = resultado.Content.ReadAsStringAsync().Result;
            await DisplayAlert("Alert", json.ToString(),"OK");

        }

        private async void GoingBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Lukky_Reader.MainPage(id_usuario));
        }

      
    }
}