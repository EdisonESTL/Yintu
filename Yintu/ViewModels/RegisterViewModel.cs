using Yintu.DataBase;
using Yintu.Models;
using Yintu.Auxiliars;
using System.Windows.Input;
using Xamarin.Forms;

namespace Yintu.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        //Propiedades de Enlace con la vista
        private string _nameUser;
        public string NameUser
        {
            get { return _nameUser; }
            set
            {
                _nameUser = value;
                OnPropertyChanged();
            }
        }
        private string _mailUser;
        public string MailUser
        {
            get { return _mailUser; }
            set { _mailUser = value; 
                OnPropertyChanged(); }
        }
        private string _phoneUser;
        public string PhoneUser
        {
            get { return _phoneUser; }
            set
            {
                _phoneUser = value;
                OnPropertyChanged();
            }
        }

        private string _passClone;
        public string PassClon
        {
            get { return _passClone; }
            set 
            { 
                _passClone = value;
                OnPropertyChanged();
            }
        }

        private string _typeUser;
        public string TypeUser
        {
            get { return _typeUser; }
            set
            {
                _typeUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(() => Register());
            CancelCommand = new Command(() => CancelRegister());
        }

        private async void Register()
        {
            RulesValidation rule = new RulesValidation();
            var confirmVal = rule.ValidarRegisterCamps(CiUser, NameUser, MailUser, PhoneUser, PasswordUser, PasswordUser, TypeUser);
            if(confirmVal == 1)
            {
                UserDb regis = new UserDb();
                var newUser = new UserModel()
                {
                    CiUser = CiUser,
                    NameUser = NameUser,
                    MailUser = MailUser,
                    PhoneUser = PhoneUser,
                    PasswordUser = PasswordUser,
                    TypeUser = TypeUser
                };
                IsRegister = false;
                await regis.SaveUser(newUser);
                await Shell.Current.DisplayAlert("Felicidades","Usuario agregado correctamente","Aceptar");
                await Shell.Current.GoToAsync("//login");
            }
            else
            {
                if(confirmVal == 2)
                {
                    await Shell.Current.DisplayAlert("Error", "Ci incorrecto", "Aceptar");
                }
                else
                {
                    if(confirmVal == 3)
                    {
                        await Shell.Current.DisplayAlert("Error", "Contraseñas no coinciden", "Aceptar");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Datos mal ingresados o incorrectos", "Aceptar");

                    }
                }
            }
        }

        private async void CancelRegister()
        {
            var action = await Shell.Current.DisplayAlert("¿Cancelar?", "Esta seguro de cancelar", "si", "no");
            if (action)
            {
                await Shell.Current.GoToAsync("//login");
            }
        }
    }
}
