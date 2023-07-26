using Microsoft.EntityFrameworkCore;
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
    public partial class OpenProjectForm : Form
    {
        private readonly MyDbContext _dbContext;
        public string SelectedProjectName { get; set; }
        public string RadiusEquipment { get; set; }
        public int SelectedProjectId { get; set; }
        public OpenProjectForm()
        {
            InitializeComponent();
            _dbContext = new MyDbContext();
            var projectNames = _dbContext.Projects.Select(project => project.Name).ToList();

            foreach (var name in projectNames)
            {
                var button = new Button();
                button.Text = name;
                button.Dock = DockStyle.Top;
                button.Width = 200;
                button.Click += OpenProjectClick;
                panel.Controls.Add(button);
            }

        }

        private void OpenProjectClick(object? sender, EventArgs args)
        {
            var button = sender as Button;
            SelectedProjectName = button.Text;
            // Получаем выбранный проект из базы данных
            var selectedProject = _dbContext.Projects.FirstOrDefault(p => p.Name == SelectedProjectName);
            // Устанавливаем значение SelectedProjectId
            SelectedProjectId = selectedProject.ID;
            SelectedProjectName = (sender as Button).Text;
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
