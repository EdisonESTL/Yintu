using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Yintu.Models
{
    [Table("MaterialSinConsumir")]
    public class UnconsumedMaterialModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idMaterialSC")]
        public int IdMaterialSC { get; set; }

        [Column("nombreListaSC")]
        public string NombreListaSC { get; set; }

        [ForeignKey(typeof(RawMaterialModel))]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        //relacion con la tabla MATERIAL
        [OneToMany]
        public List<RawMaterialModel> RawMaterials { get; set; }
    }
}
