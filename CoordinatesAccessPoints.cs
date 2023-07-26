using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interface2
{
    [Table("Координаты точек доступа")]
    public class CoordinatesAccessPoints
    {
        [DisplayName("Номер точки доступа")]
        [Column("Номер точки доступа")]
        public int ID { get; set; }

        [DisplayName("Координата Х")]
        [Column("Координата X")]
        public int Coordinate_X { get; set; }

        [DisplayName("Координата Y")]
        [Column("Координата Y")]
        public int Coordinate_Y { get; set; }

        [DisplayName("Номер проекта")]
        [Column("Номер проекта")]
        public int ProjectId { get; set; }

        [Browsable(false)]
        public Project Project { get; set; }
    }
}
