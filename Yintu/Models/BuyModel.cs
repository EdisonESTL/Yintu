using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("Compra")]
    public class BuyModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idCompra")]
        public int IdCompra { get; set; }

        [Column("fechaCompra")]
        public DateTime FechaCompra { get; set; }

        [Column("numeroLista")]
        public int NumeroLista { get; set; }

        [Column("totalCompra")]
        public decimal TotalCompra { get; set; }

        //relacion con la tabla LISTA COMPRA
        [OneToOne("NumeroLista")]
        public BuyListModel BuyList { get; set; }
    }

    [Table("ListaCompra")]
    public class BuyListModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idElemento")]
        public int IdElemento { get; set; }

        [Column("numeroLista")]
        public int NumeroLista { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Column("cantidadComprar")]
        public string CantidadComprar { get; set; }

        [Column ("medidaCompra")]
        public string MedidaCompra { get; set; }

        //relacion con la tabla MATERIAL
        [OneToOne]
        public RawMaterialModel RawMaterial { get; set; }

        //relacion con la tabla COMPRA
        [OneToOne]
        public BuyModel Buy { get; set; }

        //relacion con la tabla FOTO COMPRA
    }

    [Table("fotoCompra")]
    public class PhotoBuy
    {
        [PrimaryKey, AutoIncrement]
        [Column("idFotoCompra")]
        public int IdFotoCompra { get; set; }

        [ForeignKey(typeof(BuyModel))]
        [Column("idCompra")]
        public int IdCompra { get; set; }

        [Column("reciboCompra")]
        public byte FotoCompra { get; set; }

        //relacion con la tabla COMPRA
        [ManyToOne]
        public ObservableCollection<BuyModel> Buys { get; set; }
    }
}
