using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("Venta")]
    public class SalesModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idVenta")]
        public int IdVenta { get; set; }

        [Column("fechaVenta")]
        public DateTime FechaVenta { get; set; }
        
        [ForeignKey(typeof(ClientModel))]
        [Column("idCliente")]
        public int IdCliente { get; set; }

        [Column("totalVenta")]
        public string TotalVenta { get; set; }

        [ManyToMany(typeof(SalesProductModel))]
        public List<SalesModel> Sales { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert)]
        public ClientModel Client { get; set; }
    }

    [Table("VentaProducto")]
    public class SalesProductModel
    {
        [ForeignKey(typeof(SalesModel))]
        [Column("idVenta")]
        public int IdVenta { get; set; }

        [ForeignKey(typeof(ProductModel))]
        [Column("idProducto")]
        public int IdProducto { get; set; }

        [Column("cantidadProducto")]
        public int CantidadProducto { get; set; }

        [Column("colorProducto")]
        public string ColorProducto { get; set; }
    }
}
