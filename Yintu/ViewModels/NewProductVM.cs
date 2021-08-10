using Yintu.DataBase;
using Yintu.Models;
//using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Yintu.ViewModels
{
    class NewProductVM : BaseViewModel
    {
        //Propiedades que seran usadas en la clase
        //private string _modeloProduct;
    
        /*public string ModeloProduct
        {
            get { return _modeloProduct; }
            set 
            { 
                SetValue(ref this._modeloProduct, value);
                OnPropertyChanged();
            }
        }

        private string _descripcionProduct;
        public string DescripcionProduct
        {
            get { return this._descripcionProduct; }
            set 
            { 
                SetValue(ref this._descripcionProduct, value);
                OnPropertyChanged();
            }
        }

        private decimal _precioProduct;

        public decimal PrecioProduct
        {
            get { return _precioProduct; }
            set 
            { 
                SetValue(ref this._precioProduct, value);
                OnPropertyChanged();
            }
        }

        private int _stockDisponibleProduct;
        public int StockDisponibleProduct
        {
            get { return _stockDisponibleProduct; }
            set 
            { 
                SetValue(ref this._stockDisponibleProduct, value);
                OnPropertyChanged();
            }
        }

        public byte[] _byteImageProduct;
        public byte[] ByteImageProduct
        {
            get { return this._byteImageProduct; }
            set { SetValue(ref this._byteImageProduct, value); }
        }

        public ImageSource _imageProdcut;
        public ImageSource ImageProduct
        {
            get { return this._imageProdcut; }
            set { SetValue(ref this._imageProdcut, value); }
        }
        //Fin de las propiedades
        */
        public ICommand CancelarNewProduct { get; set; }
        public ICommand GuardarNewProduct { get; set; }
        public ICommand FotoProducto { get; set; }
        
        public NewProductVM()
        {
            CancelarNewProduct = new Command(() => CancecelarNP());
            //GuardarNewProduct = new Command(() => SaveNP());
            //FotoProducto = new Command(() => PhotoProduct());
        }
        
        /*async private void PhotoProduct()
        {
            //toma de foto
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            if(photo != null)
            {
                //visualizar foto en la vista
                ImageProduct = ImageSource.FromStream(() =>
                {
                    var stream = photo.GetStream();
                    return stream;
                });
            }

            //transformar foto a Byte[]
            using (var memoryStream = new MemoryStream())
            {
                photo.GetStream().CopyTo(memoryStream);
                photo.Dispose();
                ByteImageProduct = memoryStream.ToArray();
            }
        }*/
        /*
        private async void SaveNP()
        {
            if (!string.IsNullOrEmpty(this.ModeloProduct) 
                && !string.IsNullOrEmpty(this.DescripcionProduct) 
                && this.PrecioProduct != 0 
                && this.ImageProduct != null)
            {
                AccesDB data = await AccesDB.Instance;
                await data.SaveItemAsync(new ProductModel
                {
                    ModeloProducto = this.ModeloProduct,
                    DescripcionProducto = this.DescripcionProduct,
                    StockDisponibleProducto = this.StockDisponibleProduct
                });
                await data.SaveImageProduct(new ProductImageModel
                {     
                    Fotoproducto = this.ByteImageProduct
                });
                await Application.Current.MainPage.DisplayAlert("Felicidades", "Producto Guardado", "Aceptar");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Producto No Guardado, complete los datos", "Aceptar");

            }
        }*/

        private async void CancecelarNP()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        
    }
}
