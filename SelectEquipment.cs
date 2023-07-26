using AForge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface2
{
    public partial class SelectEquipment : Form
    {
        public double radius;
        public SelectEquipment()
        {
            InitializeComponent();
            ShowEquipmentBD();
            ShowPointsBD();
        }

        private void SelectEquipment_Load(object sender, EventArgs e)
        {

        }

        private void ShowEquipmentBD()
        {
            using (var db = new MyDbContext())
            {
                var equipments = db.NetEquipments.ToList();

                foreach (var NetEquipments in equipments)
                {
                    listBox1.Items.Add(NetEquipments.ToString());
                }
            }
        }

        private void ShowPointsBD()
        {

            if (OpenedProjectInfo.OpenedProject != null)
            {
                using (var MyDbContext = new MyDbContext())
                {
                    var points = MyDbContext.CoordinatesAccessPoints
                        .Where(p => p.ProjectId == OpenedProjectInfo.OpenedProject.ID)
                        .ToList();

                    foreach (var point in points)
                    {
                        listBox2.Items.Add($" Номер точки: {point.ID}, X: {point.Coordinate_X}, Y: {point.Coordinate_Y}");
                    }
                }
            }
        }

        private void DeleteBind_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                if (listBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Сначала выберите связь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string selectedBind = listBox3.SelectedItem.ToString();

                string[] parameters = selectedBind.Split(',');
                string pointIdString = parameters[1].Trim().Split(':')[1].Trim();
                int pointId = int.Parse(pointIdString);

                using (var dbContext = new MyDbContext())
                {
                    var existingUseNetEquipment = dbContext.UseNetEquipments.FirstOrDefault(u => u.PointId == pointId);

                    if (existingUseNetEquipment != null)
                    {
                        dbContext.UseNetEquipments.Remove(existingUseNetEquipment);
                        dbContext.SaveChanges();

                        listBox3.Items.Remove(selectedBind);

                        string oldListBoxItem = listBox4.Items.Cast<string>().FirstOrDefault(item => item.Contains($"Точка: {pointId}"));
                        if (oldListBoxItem != null)
                        {
                            listBox3.Items.Remove(oldListBoxItem);
                        }

                        MessageBox.Show("Связь удалена.");
                    }
                }
            }
        }

        private void SelectBind_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
            {
                string selectedEquipment = listBox1.SelectedItem.ToString();
                string selectedPoint = listBox2.SelectedItem.ToString();

                string[] pointParameters = selectedPoint.Split(',');
                string pointIdString = pointParameters[0].Split(':')[1].Trim();
                int pointId = int.Parse(pointIdString);

                string[] parameters = selectedEquipment.Split(',');
                string id = parameters[0].Trim().Split(':')[1].Trim();
                string name = parameters[1].Trim().Split(':')[1].Trim();
                string radiusString = parameters[2].Trim().Split(':')[1].Trim();
                string typeOfConnection = parameters[3].Trim().Split(':')[1].Trim();
                string equipmentId = id;

                using (var dbContext = new MyDbContext())
                {
                    // Проверяем, существуют ли оборудование и точка
                    var equipmentExists = dbContext.NetEquipments.Any(ne => ne.ID == equipmentId);
                    var pointExists = dbContext.CoordinatesAccessPoints.Any(ca => ca.ID == pointId);

                    if (!equipmentExists || !pointExists)
                    {
                        MessageBox.Show("Оборудование или точка не существуют.");
                        return;
                    }

                    var existingUseNetEquipment = dbContext.UseNetEquipments.FirstOrDefault(u => u.PointId == pointId);

                    if (existingUseNetEquipment == null)
                    {

                        var useNetEquipment = new UseNetEquipments
                        {
                            NetEquipmentsId = equipmentId,
                            PointId = pointId,
                            ProjectId = OpenedProjectInfo.OpenedProject?.ID ?? 0
                        };

                        dbContext.UseNetEquipments.Add(useNetEquipment);

                        string ListItem = $"Оборудование: {equipmentId}, Точка: {pointId}";
                        listBox3.Items.Add(ListItem);
                        string listBoxItem = $"Точка: {pointId}, Радиус: {radiusString}";
                        listBox4.Items.Add(listBoxItem);
                    }
                    else
                    {
                        // Если такая связь уже существует, обновляем ее, заменяя старое оборудование на новое
                        var existingBind = dbContext.UseNetEquipments.FirstOrDefault(u => u.PointId == pointId);
                        if (existingBind != null)
                        {
                            MessageBox.Show("Сначала удалите существующую связь.");
                            return;
                        }

                        existingUseNetEquipment.NetEquipmentsId = equipmentId;
                        existingUseNetEquipment.PointId = pointId;
                        string oldComboItem = listBox3.Items.Cast<string>().FirstOrDefault(item => item.Contains($"Точка: {pointId}"));
                        if (oldComboItem != null)
                        {
                            listBox3.Items.Remove(oldComboItem);
                        }


                        string newComboItem = $"Оборудование: {equipmentId}, Точка: {pointId}";
                        listBox3.Items.Add(newComboItem);

                        string oldListBoxItem = listBox4.Items.Cast<string>().FirstOrDefault(item => item.Contains($"Точка: {pointId}"));
                        if (oldListBoxItem != null)
                        {
                            listBox4.Items.Remove(oldListBoxItem);
                        }


                        string newListBoxItem = $"Точка: {pointId}, Радиус: {radiusString}";
                        listBox4.Items.Add(newListBoxItem);
                    }

                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        // Здесь вы можете обработать исключение. Например, вы можете показать сообщение об ошибке:
                        MessageBox.Show($"Произошла ошибка при сохранении изменений в базе данных: {ex.Message}\nInner exception: {ex.InnerException?.Message}");
                    }


                    Main mainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();

                    if (mainForm != null)
                    {
                        using (var dbContextForMain = new MyDbContext())
                        {
                            var pointForMain = dbContextForMain.CoordinatesAccessPoints.FirstOrDefault(p => p.ID == pointId);

                            if (pointForMain != null)
                            {
                                string newListBoxItem = $"Точка: {pointId}, X: {pointForMain.Coordinate_X}, Y: {pointForMain.Coordinate_Y}, Радиус: {radiusString}";
                                string oldListBoxItem = mainForm.listBox1.Items.Cast<string>().FirstOrDefault(item => item.Contains($"Точка: {pointId}"));

                                if (oldListBoxItem != null)
                                {
                                    mainForm.listBox1.Items.Remove(oldListBoxItem);
                                }

                                mainForm.listBox1.Items.Add(newListBoxItem);
                            }
                        }
                    }
                }
            }

        }

        private void SaveBind_Clik(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
