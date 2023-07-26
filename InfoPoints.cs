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
    public partial class InfoPoints : Form
    {
        private string currentProjectId;
        public InfoPoints(string _currentProjectId)
        {
            InitializeComponent();
            currentProjectId = _currentProjectId;
            LoadData();
        }

        private void InfoPoints_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (var dbContext = new MyDbContext())
            {
                using (var db = new MyDbContext())
                {
                    // Запрашиваем только записи, которые соответствуют текущему открытому проекту

                    var openProject = db.CoordinatesAccessPoints.Where(p => p.Project.Name == currentProjectId).ToList();

                    dataGridView1.DataSource = openProject;

                    dataGridView1.Columns["ProjectId"].Visible = false;

                }
            }
        }
    }
}
