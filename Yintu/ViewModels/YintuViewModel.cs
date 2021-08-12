using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Yintu.DataBase;
using Yintu.Models;

namespace Yintu.ViewModels
{
    public class YintuViewModel : UserModel
    {
        private bool _isLogin;
        public bool IsLogin 
        {
            get { return _isLogin; }
            set { _isLogin = value; } 
        }

        public YintuViewModel()
        {
            Borrar();
            _ = VerificarUsuarioExistente();   
        }

        private async void Borrar()
        {
            UserDb d = await UserDb.Instance;
            var h = d.Delete();
            if(h== true)
            {
                await Shell.Current.DisplayAlert("todo borrado", "", "ok");

            }
        }

        private async Task VerificarUsuarioExistente()
        {
            await Task.Delay(2000);
            UserDb user = await UserDb.Instance;
            if(user.listar() != null)
            {
                await Shell.Current.DisplayAlert("hay un usario","","ok");
                //await Shell.Current.GoToAsync("RoomAdmin");
            }
            else
            {
                await Shell.Current.DisplayAlert("logeate", "", "ok");

                //await Shell.Current.GoToAsync("Login");
            }
        }
    }
}
