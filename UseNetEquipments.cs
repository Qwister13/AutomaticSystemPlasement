using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interface2
{
    [Table("Используемое сетевое оборудование")]
    public class UseNetEquipments
    {

        [Key, Column("Номер точки доступа")]
        public int PointId { get; set; }


        [Key, Column("Номер проекта")]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [Column("Модель оборудования")]
        public string NetEquipmentsId { get; set; }
        public NetEquipments NetEquipments { get; set; }
        public Project project { get; set; }
    }
}
