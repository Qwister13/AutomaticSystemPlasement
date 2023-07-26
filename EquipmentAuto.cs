using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface2
{
    public partial class EquipmentAuto : Form
    {
        private GetPoints getPoints;

        public EquipmentAuto(GetPoints getPoints)
        {
            InitializeComponent();
            LoadData();
            this.getPoints = getPoints; // Сохраняем ссылку на главную форму
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, что есть выбранная строка
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс первой выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Получаем значение из конкретного столбца этой строки
                object value = dataGridView1.Rows[rowIndex].Cells["Radius"].Value;

                // Передаем значение в главную форму
                getPoints.UpdateValueInMainForm(value);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку перед тем как нажать кнопку");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            using (var db = new MyDbContext())
            {
                var netEquipments = db.NetEquipments.ToList();
                dataGridView1.DataSource = netEquipments;
            }
        }
    }
}
