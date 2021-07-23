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
    public partial class IniciarSesion : ContentPage
    {
        public int contador, id_usuario;
        public IniciarSesion()
        {
            InitializeComponent();
            frmAlert.IsVisible = false;
            frmAlert.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            lblAlert.Text = "";
            shaAlert.IsVisible = false;
            contador = 0;
            id_usuario = 0;
        }

        private async void GoingBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Lukky_Reader.MasterPage());
        }

        private async void WhatsappLukky_Clicked(object sender, EventArgs e)
        {
            string web = "https://wa.link/nu1d0z";
            await Browser.OpenAsync(web, BrowserLaunchMode.SystemPreferred);
        }
        private async void AgregarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.AgregarUsuario());
        }

        private async void ValidarUsuario_Clicked(object sender, EventArgs e)
        {
            if (contador > 1)
            {
                string correo, contrasenia;

                correo = entcorreo.Text;
                contrasenia = entcontrasenia.Text;

                if (correo != null && correo != "" && contrasenia != null && contrasenia != "")
                {
                    contrasenia = Encrypt.GetSHA256(contrasenia);

                    LoginModel usuario = new LoginModel
                    {
                        Email = correo,
                        Password = contrasenia
                    };

                    HttpClient cliente = new HttpClient();
                    string url = "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/usuario/validate";
                    String jsonUsuario = JsonConvert.SerializeObject(usuario);
                    var resultado = await cliente.PostAsync(url, new StringContent(jsonUsuario, Encoding.UTF8, "application/json"));
                    string json = resultado.Content.ReadAsStringAsync().Result;

                   //LoginModel modelo = LoginModel.FromJson(json);
                    //string usuario = modelo.

                    if (resultado.StatusCode == HttpStatusCode.OK && json != "[[]]")
                    {
                        //LoginModel modelo = LoginModel.FromJson(json);
                        //string name = "";
                        // LoginModel modelo = LoginModel.FromJson(json[]);
                        //var miJson = JsonSerializer.Deserialize<LoginModel>(json);

                        /*LoginModel login = LoginModel.FromJson(json);
                        string aa = login.Login.ToString();*/
                        id_usuario = Convert.ToInt32(json.Substring(8, 2));
                        //string nombre_usuario = json.(19,10);
                        await Navigation.PushModalAsync(new Lukky_Reader.MainPage(id_usuario));
                        //await DisplayAlert("Resultado", id, "Ok");
                        //await DisplayAlert("Datos", id_usuario.ToString(), "OK");
                        /*frmAlert.IsVisible = true;
                        frmAlert.BackgroundColor = Color.FromHex("#26D266");//#26D266
                        lblAlert.Text = "Tu perfil ha sido creado";
                        shaAlert.IsVisible = true;*/
                        
                    }
                    else
                    {
                        frmAlert.IsVisible = true;
                        frmAlert.BackgroundColor = Color.FromHex("#FAB81C");//#26D266
                        lblAlert.Text = "Intentalo de nuevo";
                        shaAlert.IsVisible = true;
                    }

                }
                else
                {
                    frmAlert.IsVisible = true;
                    frmAlert.BackgroundColor = Color.FromHex("#FE2E2E");//#26D266
                    lblAlert.Text = "Rellena todos los campos";
                    shaAlert.IsVisible = true;
                }
            }

            //await "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/usuario/validate";

        }

        private void entcorreo_Focused(object sender, FocusEventArgs e)
        {
            contador++;
        }

        private void contrasenia_Focused(object sender, FocusEventArgs e)
        {
            contador++;
        }
    }
}