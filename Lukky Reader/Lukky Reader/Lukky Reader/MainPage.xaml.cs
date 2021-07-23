using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Lukky_Reader
{
    public partial class MainPage : ContentPage
    {
        public int id_usuario;
        public MainPage(int id)
        {
            this.id_usuario = id;

            if (id > 0)
            {
                InitializeComponent();
                LlenarEscaneos();
                //DisplayAlert("", id.ToString(),"ok");
                lblId.Text = "ID usuario: "+id.ToString();

            }
            else
            {
                id_usuario = 0;
                Navigation.PushModalAsync(new Views.IniciarSesion());
            }

            //DisplayAlert("Id: ", id.ToString(),"ok");
        }

        /*public string URL()
        {
            return "http://192.168.0.175:8080/lukky-reader/public/api/escaneos";  //"https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos";
        }*/

        public async void LlenarEscaneos()
        {
            HttpClient cliente = new HttpClient();
            string url = "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos/" + id_usuario;//"https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos";
            var resultado = await cliente.GetAsync(url);
            var json = resultado.Content.ReadAsStringAsync().Result;

            EscaneosModel modelo = EscaneosModel.FromJson(json);
            listaEscaneos.ItemsSource = modelo.Escaneos;
        }

        private async void listaEscaneos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Escaneos modelo = new Escaneos();
            var escaneo = ((ListView)sender).SelectedItem as Escaneos;

            if (escaneo == null)
                return;

            //await DisplayAlert("Alert", producto.Nombre, "OK");
            await Navigation.PushModalAsync(new Views.Descripcion(id_usuario ,escaneo.Id.ToString(), escaneo.Url.ToString(), escaneo.Ip.ToString(), escaneo.CreatedAt.ToString()));
        }


        private async void ScannerQR_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Buscado Código QR para escanear";
                scanner.BottomText = "No olvides visitar nuestra web www.lukkyreader.com";
                var resultado = await scanner.Scan();
                if (resultado != null)
                {
                    //lblmensaje.Text = resultado.Text;
                    var web = resultado.Text;
                    var ip = Dns.GetHostName();

                    String strHostname = Dns.GetHostName();
                    IPHostEntry ipentry = new IPHostEntry();
                    ipentry = Dns.GetHostEntry(strHostname);

                    string iplocal = Convert.ToString(ipentry.AddressList[ipentry.AddressList.Length -1]);
                    //await DisplayAlert("IP", iplocal, "Ok");

                    Escaneos escaneo = new Escaneos
                    {
                        Url = web,
                        Ip = iplocal,
                        Id_usuario = id_usuario
                    };

                    string formato = "http://.";
                    bool accesourl = (formato.Intersect(web).Count() > 5);

                    if (accesourl == true)
                    {

                        HttpClient client = new HttpClient();
                        string url = "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos";//"https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/escaneos";
                        String jsonEscaneos = JsonConvert.SerializeObject(escaneo);
                        var result = await client.PostAsync(url, new StringContent(jsonEscaneos, Encoding.UTF8, "application/json"));
                        var json = result.Content.ReadAsStringAsync().Result;
                        if (result.StatusCode == HttpStatusCode.OK)
                        {

                            await Browser.OpenAsync(web, BrowserLaunchMode.SystemPreferred);
                            LlenarEscaneos();
                        }
                        else
                        {
                            await DisplayAlert("Error", "Codigo ilegible", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Advertencia: ", "Intenta con otro codigo QR", "OK");
                    }


                }
            }
            catch (Exception)
            {

                await DisplayAlert("Advertencia: ","Debe de escanear un codigo QR que lo redirija a una web", "OK");
            }
        }

        private async void CerrarSession_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PushModalAsync(new Views.configuraciones(id_usuario));
            bool respuesta = await DisplayAlert("Cerrar Sesion", "Estas seguro que quieres cerrar sesion ?", "Si", "No");
            if (respuesta == true)
            {
                id_usuario = 0;
                await Navigation.PushModalAsync(new Views.IniciarSesion());
            }
        }
    }
}
