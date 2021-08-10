//using GalaSoft.MvvmLight.Command;
using Yintu.DataBase;
using Yintu.Models;
using Yintu.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Yintu.ViewModels
{
    class ProductVM : BaseViewModel
    {
        //Propiedades que seran usadas en la clase
        /*public List<ProductModel> _listProduct;
        public List<ProductModel> ListProduct
        {
            get { return this._listProduct; }
            set { SetValue(ref this._listProduct, value); }
        }

        public ImageSource _image;
        public ImageSource Image
        {
            get { return this._image; }
            set { SetValue(ref this._image, value); }
        }*/
        //Fin de las propiedades

        #region OtrasOp
        /*public Command NuevoProducto
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new NewProductView());
                });
            }
        }*/

        /*public ICommand NuevoProducto
        {
            get
            {
                return new Command(NP);
            }
        }

        private async void NP()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewProductView());
        }*/
        #endregion

        //Declarando ICommand para enlazar a la vista
        public ICommand NuevoProducto { get; set; }
        public ICommand ListaProducto { get; set; }

        //Constructor de clase e inicializador de command's
        public ProductVM()
        {
            /*NuevoProducto = new Command(() => NPP());
            ListarProduct();*/
        }

        //Comandos
        /*private async void NPP()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewProductView()); 
        }*/
        /*
        private async void ListarProduct()
        {
            AccesDB data = await AccesDB.Instance;
            ListProduct = await data.GetProductsAsync();
        }

        public void Convert(object value)
        {
            ImageSource retSource = null;

            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }

            Image = retSource;
        }*/
    }
}
