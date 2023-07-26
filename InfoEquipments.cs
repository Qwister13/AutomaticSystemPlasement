using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Design;

namespace Interface2
{
    public partial class InfoEquipments : Form
    {
        public InfoEquipments()
        {

            InitializeComponent();
            LoadData();
        }

        private void InfoEquipments_Load(object sender, EventArgs e)
        {

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
