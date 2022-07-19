using System.Windows.Input;
using Xamarin.Forms;
using Yintu.DataBase;
using System;
using System.Threading.Tasks;
using Yintu.Auxiliars;
using Yintu.Models;
using System.Collections.Generic;
using Yintu.Views;

namespace Yintu.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        /*public string Usuario { get; set; }
        public string Contrasenia { get; set; }*/

        public List<UserModel> _lista;
        public List<UserModel> Lista
        {
            get { return _lista; }
            set { _lista = value; OnPropertyChanged(); }
        }

        public ICommand EntryCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            IsRegister = true;
            EntryCommand = new Command(() => Entry());
            RegisterCommand = new Command(() => Register());
        }

        private async void Entry()
        {
            RulesValidation validar = new RulesValidation();
            int val = validar.ValidarCiPassword(CiUser, PasswordUser);

            if(val == 1)
            {
                UserDb user = await UserDb.Instance;
                var j = user.ValidarUsuario(CiUser, PasswordUser);
                if (j == true)
                {
                    await Application.Current.MainPage.DisplayAlert("Bienvenido", 
                                                                    "Yintu le da la Bienvenida",
                                                                    "Aceptar");
                    await Shell.Current.GoToAsync($"//main");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Losiento", 
                                                                    "Sus datos no se encuentran registrados en nuestro sistema",
                                                                    "Aceptar");
                }
            } 
            if(val == 2)
            {
                await Shell.Current.DisplayAlert("Error",
                    "Alguno de los campos esta incompleto o vacio",
                    "Aceptar");
            }
            if(val == 3)
            {
                await Shell.Current.DisplayAlert("Error",
                    "El numero de serie es incorrecto",
                    "Aceptar");
            }
        }

        private async void Register()
        {
            await Shell.Current.GoToAsync($"//login/registration");
        }
    }
}
