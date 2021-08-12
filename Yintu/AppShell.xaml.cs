using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yintu.Views;

namespace Yintu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("RoomAdmin", typeof(RoomView));
            Routing.RegisterRoute("registration", typeof(RegistrationView));
        }
    }
}