using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("Material")]
    public class RawMaterialModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [ForeignKey(typeof(TypeMaterialModel))]
        [Column("idTipoMaterial")]
        public int IdTipoMaterial { get; set; }

        [Column("colorMaterial")]
        public string ColorMaterial { get; set; }

        [Column("descripcionMaterial")]
        public string DescripcionMaterial { get; set; }

        [Column("cantidadMaterial")]
        public string CantidadMaterial { get; set; }

        [Column("medidaCantidadMaterial")]
        public string MedidaCantidadMaterial { get; set; }

        //Relacion con la tabla Tipo Material
        [OneToOne]
        public TypeMaterialModel TypeMaterial { get; set; }

        //Relacion con la tabla fotos
        [OneToMany]
        public ObservableCollection<ImageMaterialModel> Images { get; set; }

        //relacion con la tabla  PRECIO MATERIAL PROVEEDOR
        [OneToMany]
        public List<PriceMaterialSuplierModel> PriceMaterialSupliers { get; set; }
    }

    [Table("CierreAguja")]
    public class ClosingNeedleModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idCierreAguja")]
        public int IdCierrreAguja { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Column("numeroCierreAguja")]
        public int NumeroCierreAguja { get; set; }

        //Relacion con la tabla Material(Materia Prima)
        [OneToOne]
        public RawMaterialModel RawMaterial { get; set; }
    }

    [Table("Reata")]
    public class ReataModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idReata")]
        public int IdReata { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Column("dimensionReata")]
        public double DimensionReata { get; set; }

        //Relacion con la tabla Material(Materia Prima)
        [OneToOne]
        public RawMaterialModel RawMaterial { get; set; }
    }

    [Table("Herraje")]
    public class IronworkModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idHerraje")]
        public int IdHerraje { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Column("numeroHerraje")]
        public int NumeroHerraje { get; set; }

        [Column("dimensionHeraje")]
        public double DimensionHerrraje { get; set; }

        //Relacion con la tabla Material(Materia Prima)
        [OneToOne]
        public RawMaterialModel RawMaterial { get; set; }
    }

    [Table("Tela")]
    public class ClothModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idTela")]
        public int IdTela { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [ForeignKey(typeof(TypeClothModel))]
        [Column("idTipoTela")]
        public int IdTipoTela { get; set; }

        //Relacion con la tabla Material(Materia Prima)
        [OneToOne]
        public RawMaterialModel RawMaterial { get; set; }

        //relacio con la tabla Tipo Tela
        [OneToOne]
        public TypeClothModel TypeCloth { get; set; }
    }

    [Table("TipoTela")]
    public class TypeClothModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idTipoTela")]
        public int IdTipoTela { get; set; }

        [Column("nombreTela")]
        public string NombreTela { get; set; }
    }

    [Table("TipoMaterial")]
    public class TypeMaterialModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idTipoMaterial")]
        public int IdTipoMaterial { get; set; }

        [Column("nombreMaterial")]
        public string NombreMaterial { get; set; }
    }

    [Table("FotoMaterial")]
    public class ImageMaterialModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idFotoMaterial")]
        public int IdFotoMaterial { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Column("fotoMaterial")]
        public byte FotoMaterial { get; set; }

        //Relacion con la tabla Material
        [ManyToOne]
        public RawMaterialModel RawMaterial { get; set; }
    }
}