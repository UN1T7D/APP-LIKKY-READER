using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lukky_Reader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new SharedTransitionNavigationPage(new Views.Descripcion(22,"ss","","",""));
            //MainPage = new SharedTransitionNavigationPage(new Views.configuraciones(22));
            MainPage = new SharedTransitionNavigationPage(new MasterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
