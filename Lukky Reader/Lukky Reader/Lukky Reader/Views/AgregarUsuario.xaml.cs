using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lukky_Reader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarUsuario : ContentPage
    {
        public int contador;
        public AgregarUsuario()
        {
            InitializeComponent();
            btnAgregar.BackgroundColor = Color.FromHex("#364064");
            btnAgregar.IsEnabled = false;
            frmAlert.IsVisible = false;
            frmAlert.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            contador = 0;
            lblAlert.Text = "";
            shaAlert.IsVisible = false;
            btnIniciarSession.IsVisible = false;
        }

        private async void GoingBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Lukky_Reader.MasterPage());
        }

        private async void AgregarUsuario_Clicked(object sender, EventArgs e)
        {
            string nombre, email, contrasenia, contrasenia2;

            nombre = entusuario.Text;
            email = entcorreo.Text;
            contrasenia = entcontrasenia.Text;
            contrasenia2 = entcontrasenia2.Text;

            if (nombre != null && email != null && contrasenia != null && contrasenia2 != null && nombre != "" && email != "" && contrasenia != "" && contrasenia2 != "")
            {
                if (contrasenia == contrasenia2)
                {
                    contrasenia = Encrypt.GetSHA256(contrasenia);

                    LoginModel usuario = new LoginModel
                    {

                        Name = nombre,
                        Email = email,
                        Password = contrasenia

                    };

                    HttpClient cliente = new HttpClient();
                    string url = "https://kenvnjgj.lucusvirtual.es/lukkyreader/public/api/usuario/add";
                    String jsonUsuario = JsonConvert.SerializeObject(usuario);
                    var resultado = await cliente.PostAsync(url, new StringContent(jsonUsuario, Encoding.UTF8, "application/json"));
                    var json = resultado.Content.ReadAsStringAsync().Result;
                    if (resultado.StatusCode == HttpStatusCode.OK)
                    {
                        frmAlert.IsVisible = true;
                        frmAlert.BackgroundColor = Color.FromHex("#26D266");//#26D266
                        lblAlert.Text = "Tu perfil ha sido creado";
                        shaAlert.IsVisible = true;
                        btnIniciarSession.IsVisible = true;
                        btnAgregar.IsVisible = false;
                    }
                    else
                    {
                        frmAlert.IsVisible = true;
                        frmAlert.BackgroundColor = Color.FromHex("#FAB81C");//#26D266
                        lblAlert.Text = "Hubo un problema al crear el perfil";
                        shaAlert.IsVisible = true;
                    }

                  
                }
                else
                {
                    frmAlert.IsVisible = true;
                    frmAlert.BackgroundColor = Color.FromHex("#FAB81C");//#26D266
                    lblAlert.Text = "Contraseñas, no coinciden";
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

        private void entcontrasenia2_Focused(object sender, FocusEventArgs e)
        {
            contador++;
            
        }

        private void entcorreo_Focused(object sender, FocusEventArgs e)
        {
            contador++;
        }

        private void entusuario_Focused(object sender, FocusEventArgs e)
        {
            contador++;
        }

        private void entcontrasenia_Focused(object sender, FocusEventArgs e)
        {
            contador++;
        }

        private void entcontrasenia2_Unfocused(object sender, FocusEventArgs e)
        {
            if (contador > 3)
            {
                /*
                  nombre = entusuario.Text;
            email = entcorreo.Text;
            contrasenia = entcontrasenia.Text;
            contrasenia2 = entcontrasenia2.Text;
                 */
                if (entusuario.Text != null && entcorreo.Text != null && entcontrasenia.Text != null && entcontrasenia2.Text != null && entusuario.Text != "" && entcorreo.Text != "" && entcontrasenia.Text != "" && entcontrasenia2.Text != "")
                {

                    btnAgregar.IsEnabled = true;
                    btnAgregar.BackgroundColor = Color.FromHex("#FAB81C");
                }

            }
        }

        private void btnAgregar_Unfocused(object sender, FocusEventArgs e)
        {
            frmAlert.IsVisible = false;
            frmAlert.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            lblAlert.Text = "";
            shaAlert.IsVisible = false;

        }

        private async void btnIniciarSession_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IniciarSesion());
        }
    }
}