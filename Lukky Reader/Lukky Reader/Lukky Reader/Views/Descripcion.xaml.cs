using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lukky_Reader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Descripcion : ContentPage
    {
        public int id_usuario;
        public Descripcion(int id_usuario, string id, string url, string ip, string create)
        {
            this.id_usuario = id_usuario;

            if (id_usuario > 0)
            {
                InitializeComponent();

                lblurl.Text = url;
                enturl.Text = url;
                //lblip.Text = ip;
                entid.Text = id;
                //lblcreate.Text = create;

            }
            else
            {
                id_usuario = 0;
                Navigation.PushModalAsync(new Views.IniciarSesion());
            }



        }

        private void BrowserGo_Clicked(object sender, EventArgs e)
        {
            var url = enturl.Text;
            Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlert("Alerta", "¿Quieres eliminar este codigo escaneado de tu historial?", "Si", "No");
            if (respuesta == true)
            {

                var id = Convert.ToInt32(entid.Text);

                if (id != 0)
                {
                    Escaneos escaneo = new Escaneos
                    {
                        Id = id
                    };

                    MainPage main = new MainPage(id_usuario);
                    //string urlgeneral = main.URL();
                    HttpClient cliente = new HttpClient();
                    string url = "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos/" + id; //"https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos" + "/" + id;

                    String jsonPoroducto = JsonConvert.SerializeObject(escaneo);
                    var resultado = await cliente.DeleteAsync(url);
                    var json = resultado.Content.ReadAsStringAsync().Result;
                    if (resultado.StatusCode == HttpStatusCode.OK)
                    {

                        await DisplayAlert("Historial", "Eliminado del historial", "Ok");
                        await Navigation.PushModalAsync(new MainPage(id_usuario));
                        MainPage principal = new MainPage(id_usuario);
                        principal.LlenarEscaneos();
                        
                    }
                    else
                    {
                        await DisplayAlert("Historial", "No se pudo eliminar del historial", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se reconoce el identificador", "Ok");
                }
            }

        }

        private async void GoingBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage(id_usuario));
        }
    }
}