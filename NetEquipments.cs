using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.ComponentModel;

namespace Interface2
{
    [Table("Сетевое оборудование")]
    public class NetEquipments
    {
        [Key]
        [DisplayName("Модель оборудования")]
        [Column("Модель оборудования")]
        public string ID { get; set; }

        [DisplayName("Название оборудования")]
        [Column("Название оборудования")]
        public string  Name { get; set; }

        [DisplayName("Радиус покрытия")]
        [Column("Радиус покрытия")]
        public double Radius { get; set; }

        [DisplayName("Тип беспроводной связи")]
        [Column("Тип беспроводной связи")]
        public string? TypeOfConnection { get; set; }

        public override string ToString()
        {
            // Верните строку, содержащую все параметры класса NetEquipments
            return $"Номер оборудования: {ID}, Название оборудования: {Name}, Радиус: {Radius}, Тип беспроводной связи: {TypeOfConnection}";
        }

    }
 
}
