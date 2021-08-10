using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Yintu.Models
{
    [Table("Egresos")]
    class EgressModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idEgreso")]
        public int IdEgreso { get; set; }

        [Column("totalCompras")]
        public decimal TotalCompras { get; set; }

        [Column("totalServicios")]
        public decimal TotalServicios { get; set; }
        
        [Column("totalEgresos")]
        public decimal TotalEgresos { get; set; }

        [Column("fechaEgreso")]
        public DateTime FechaEgreso { get; set; }
    }

    [Table("ServicioBasico")]
    class BasicServiceModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("idServicio")]
        public int IdServicio { get; set; }

        [Column("nombreServicio")]
        public string NombreServicio { get; set; }

        [Column("totalServicio")]
        public decimal TotalServicio { get; set; }

        [Column("mesServicio")]
        public string MesServicio { get; set; }

        [Column("fechaIngresoSistema")]
        public DateTime FechaIngresoSistema { get; set; }
    }
}
