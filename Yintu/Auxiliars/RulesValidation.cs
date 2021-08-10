using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Yintu.Auxiliars
{
    public class RulesValidation
    {
        public int ValidarLoginCamps(string Ci, string Password)
        {
            //Indica si Ci es nulo o vacio
            if (string.IsNullOrWhiteSpace(Ci))
            {
                Application.Current.MainPage.DisplayAlert("", "El campo Serie de usuario, se encuentra vacio", "Aceptar");
                return 0;
            }
            else
            {
                if (Ci.Length != 10)
                {
                    Application.Current.MainPage.DisplayAlert("", "El campo Serie de usuario, se encuentra incompleto", "Aceptar");
                    return 0;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        Application.Current.MainPage.DisplayAlert("", "El campo Contraseña, se encuentra vacio", "Aceptar");
                        return 0;
                    }
                    else
                    {
                        if (Password.Length < 7)
                        {
                            Application.Current.MainPage.DisplayAlert("", "Contraseña Incorrecta", "Aceptar");
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }


        }
    }
}
