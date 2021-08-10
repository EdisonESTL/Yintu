using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("ProductoModelo")]
    public class ProductModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idProductoM")]
        public int IdProducto { get; set; }

        [Column("modeloProducto")]
        public string ModeloProducto { get; set; }

        [Column("colorProducto")]
        public string ColorProducto { get; set; }

        [Column("descripcionProducto")]
        public string DescripcionProducto { get; set; }

        [Column("stockDisponibleProducto")]
        public int StockDisponibleProducto { get; set; }

        //Relacion con la tabla Producto Foto
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<ProductImageModel> Fotos { get; set; }

        //Relacion tabla PRECIOS PRODUCTO 
        [OneToOne(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<ProductPriceModel> Precios { get; set; }

        //Relacion tabla VENTA PRODUCTO
        [ManyToMany(typeof(SalesProductModel))]
        public List<ProductModel> Products { get; set; }

        //Relacion tabla PEDIDO PRODUCTO
        [OneToMany]
        public List<OrderProductModel> OrderProduct { get; set; }

        //Relacion tabla PEDIDO PERSONALIZACION
        [OneToMany]
        public List<OrderPersonalizationModel> OrderPersonalizations { get; set; }
    }

    [Table("ProductoPrecio")]
    public class ProductPriceModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idProductoPrecio")]
        public int IdProductoPrecio { get; set; }

        [ForeignKey(typeof(ProductModel))]
        [Column("idProducto")]
        public string IdProducto { get; set; }

        [Column("nombreProducto")]
        public string NombreProducto { get; set; }

        [Column("precioProducto")]
        public decimal PrecioProducto { get; set; }

        //Relacion con tabla PRODUCTO
        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public ProductModel Product { get; set; }
    }

    [Table("ProductoFoto")]
    public class ProductImageModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idFotoProducto")]
        public int IdFotoProducto { get; set; }

        [ForeignKey(typeof(ProductModel))]
        [Column("idProducto")]
        public int IdProducto { get; set; }

        [Column("fotoproducto")]
        public byte[] Fotoproducto { get; set; } 

        //Relacion con la tabla Producto
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public ProductModel Product { get; set; }
    }
}
