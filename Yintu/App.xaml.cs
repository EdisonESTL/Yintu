using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yintu.Views;

namespace Yintu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            //MainPage = new NavigationPage(new WelcomeView());
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
