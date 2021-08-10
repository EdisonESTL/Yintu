using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Yintu.Models
{
    [Table("ClienteModel")]
    public class ClientModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idCliente")]
        public int IdCliente { get; set; }

        [Column("nombreCliente")]
        public string NombreCliente { get; set; }

        [Column("apellidoCliente")]
        public string ApellidoCliente { get; set; }

        [Column("celularCliente")]
        public char CelularCliente { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<SalesModel> Ventas { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<OrderModel> Orders { get; set; }
    }
}
