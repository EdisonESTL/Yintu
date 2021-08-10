using Yintu.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yintu.DataBase
{
    public class AccesDB
    {
        static SQLiteAsyncConnection _dataBase;

        public static readonly AsyncLazy<AccesDB> Instance = new AsyncLazy<AccesDB>(async () =>
        {
            var instance = new AccesDB();
            await _dataBase.CreateTableAsync<ProductModel>();
            await _dataBase.CreateTableAsync<ProductPriceModel>();
            return instance;
        });

        public AccesDB()
        {
            _dataBase = new SQLiteAsyncConnection(DataBase.DbPath, DataBase.flags);
        }

        //Funcion de Guardado de Productos
        public Task<int> SaveItemAsync(ProductModel products)
        {
            if (products.IdProducto != 0)
            {
                return _dataBase.UpdateAsync(products);
            }
            else
            {
                return _dataBase.InsertAsync(products);
            }
        }

        public Task<int> SaveImageProduct(ProductImageModel imagePr)
        {
            if(imagePr.IdFotoProducto != 0)
            {
                return _dataBase.UpdateAsync(imagePr);
            }
            else
            {
                return _dataBase.InsertAsync(imagePr);
            }
        }

        //Funcion de Listar Productos
        public Task<List<ProductModel>> GetProductsAsync()
        {
            return _dataBase.Table<ProductModel>().ToListAsync();
        }

        public Task<List<ProductImageModel>> GetImagePrAsync()
        {
            return _dataBase.Table<ProductImageModel>().ToListAsync();
        }
        //Funcion Eliminar Producto
        public Task<int> DeleteProductAsync(ProductModel products)
        {
            return _dataBase.DeleteAsync(products);
        }

        public Task<List<ProductModel>> ListaProductos()
        {
            //string sqlQuery = "SELECT * FROM ProductModel";
            return _dataBase.QueryAsync<ProductModel>("SELECT * FROM ProductModel");
          
        }
    }
}
