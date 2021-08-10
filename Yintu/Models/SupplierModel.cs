using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("Proveedor")]
    public class SupplierModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idProveedor")]
        public int IdProveedor { get; set; }

        [Column("nombreProveedor")]
        public string NombreProveedor { get; set; }

        [Column("direccionProveedor")]
        public string DireccionProveedor { get; set; }

        [Column("telefonoProveedor")]
        public string TelefonoProveedor { get; set; }

        //relacion con la tabla PRECIO MATERIAL
        [OneToMany]
        public List<PriceMaterialSuplierModel> PriceMaterialSupliers { get; set; }
    }


    //En esta tabla tambien se encuentra la CANTIDAD (AMOUNT) de cada material (Materia Prima)
    [Table("PrecioMaterialProveedor")]
    public class PriceMaterialSuplierModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idPrecioProveedor")]
        public int IdPrecioProveedor { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Column("precioMaterial")]
        public decimal PrecioMaterial { get; set; }

        [Column("descripcionPrecio")]
        public string DescripcionPrecio { get; set; }

        [ForeignKey(typeof(SupplierModel))]
        [Column("idProveedor")]
        public int IdProveedor { get; set; } 

        //Relacion con la tabla Proveedor
        [ManyToOne]
        public SupplierModel Supplier { get; set; }

        //relacion con la tabla MATERIAL
        [ManyToOne]
        public RawMaterialModel RawMaterial { get; set; }
    }
}
