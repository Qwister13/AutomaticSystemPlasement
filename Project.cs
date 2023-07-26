using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Interface2
{
    [Table("Проект")]
    public class Project
    {
        [Column("Номер проекта")]
        public int ID { get; set; }

        //public ProjectState State { get; set; }

        [Column("Название проекта")]
        public string Name { get; set; } = string.Empty;
        public PlanRoom PlanRooms { get; set; }
        public ICollection<CoordinatesAccessPoints> CoordinatesAccessPoints { get; set; }
    }
}
