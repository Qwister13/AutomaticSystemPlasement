using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface2
{
    [Table("План помещения")]
    public class PlanRoom
    {
        [Key]
        [DisplayName("Номер проекта")]
        [Column("Номер проекта")]
        public int ProjectId { get; set; }

        [DisplayName("Ширина помещения")]
        [Column("Ширина помещения")]
        public double Width { get; set; }

        [DisplayName("Высота помещения")]
        [Column("Высота помещения")]
        public double Height { get; set; }

        public Project Project { get; set; }
    }
}
