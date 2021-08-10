using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("Pedido")]
    public class OrderModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [ForeignKey(typeof(ClientModel))]
        [Column("idCliente")]
        public int IdCliente { get; set; }

        [Column("fechaPedido")]
        public DateTime FechaPedido { get; set; }

        [Column("fechaEntrega")]
        public DateTime FechaEntrega { get; set; }

        [Column("totalPedido")]
        public decimal TotalPedido { get; set; }

        [Column("estadoPedido")]
        public string EstadoPedido { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert)]
        public ClientModel Client { get; set; }

        [OneToMany]
        public List<OrderProductModel> OrderProduct { get; set; }

        [OneToMany]
        public List<OrderPersonalizationModel> OrderPersonalization { get; set; }
    }

    [Table("PedidoProducto")]
    public class OrderProductModel
    {
        [PrimaryKey, ForeignKey(typeof(OrderModel))]
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [PrimaryKey, ForeignKey(typeof(ProductModel))]
        [Column("idProducto")]
        public string IdProducto { get; set; }

        [Column("cantidadPedido")]
        public int CantidadPedido { get; set; }

        [Column("colorModelo")]
        public string ColorModelo { get; set; }

        [ManyToOne]
        public OrderModel Order { get; set; }

        [ManyToOne]
        public ProductModel Product {get; set;}
    }

    [Table("PedidoPersonalizacion")]
    public class OrderPersonalizationModel
    {
        [PrimaryKey, ForeignKey(typeof(OrderModel))]
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [PrimaryKey, ForeignKey(typeof(ProductModel))]
        [Column("idProducto")]
        public string IdProducto { get; set; }

        [ForeignKey(typeof(PersonalizationModel))]
        [Column("idPersonalizacion")]
        public int IdPersonalizacion { get; set; }

        [Column("descripcionPersonalizacion")]
        public string DescripcionPersonalizacion { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [ManyToOne]
        public OrderModel Order { get; set; }

        [ManyToOne]
        public ProductModel Product { get; set; }

        [ManyToOne]
        public PersonalizationModel Personalization { get; set; }

        [OneToOne]
        public RawMaterialModel Material { get; set; }
    }

    [Table("Personalizacion")]
    public class PersonalizationModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idPersonalizacion")]
        public int IdPersonalizacion { get; set; }

        [Column("nombrePersonalizacion")]
        public string NombrePersonalizacion { get; set; }

        [Column("precioPersonalizacion")]
        public decimal PrecioPersonalizacion { get; set; }

        [OneToMany]
        public List<OrderPersonalizationModel> OrderPersonalization { get; set; }
    }
}
