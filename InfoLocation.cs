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
    public partial class InfoLocation : Form
    {
        private string currentProjectId;

        public InfoLocation(string _currentProjectId)
        {
            InitializeComponent();
            currentProjectId = _currentProjectId;
            LoadData();

        }


        private void InfoLocation_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (var db = new MyDbContext())
            {
                // Запрашиваем только записи, которые соответствуют текущему открытому проекту

                var openProject = db.PlanRooms.Where(planroom => planroom.Project.Name == currentProjectId).ToList();

                dataGridView1.DataSource = openProject;

                dataGridView1.Columns["project"].Visible = false;

            }
        }
    }
}
