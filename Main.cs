using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Math.Geometry;
using AForge;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Interface2
{
    public partial class Main : Form
    {
        private MyDbContext MyDbContext;
        private ToolStripMenuItem fileParametersData;
        private string databasePath;
        private Project _currentProject;
        private string _currentProjectId;
        private Bitmap originalImage;
        private bool isImageOpened = false;
        private volatile bool stopAlgorithm = false;
        ToolStripMenuItem OpenScheme;
        ToolStripMenuItem OpenSelectEquipment;
        ToolStripMenuItem fileItemData;
        ToolStripMenuItem MakeProjectItem;
        private OptionType userChoice = OptionType.None;

        public Main()
        {
            InitializeComponent();
            StopGenAlgorithm.Enabled = false;
            OpenedProjectInfo.StateChanged += OnStateChanged;
            MyDbContext = new MyDbContext();
            UpdateEquipment.Enabled = false;
            RefreshPoint.Enabled = false;

            //����� ���� ������
            ToolStripMenuItem fileItem = new ToolStripMenuItem("������");
            ToolStripMenuItem CreateProject = new ToolStripMenuItem("������� ������");
            CreateProject.Click += CreateProjeck_Click;
            CreateProject.ShortcutKeys = Keys.Control | Keys.F2;
            fileItem.DropDownItems.Add(CreateProject);

            ToolStripMenuItem OpenProject = new ToolStripMenuItem("������� ������");
            OpenProject.Click += OpenProject_Click;
            OpenProject.ShortcutKeys = Keys.Control | Keys.R;
            fileItem.DropDownItems.Add(OpenProject);

            ToolStripMenuItem Save = new ToolStripMenuItem("��������� ������");
            Save.Click += Save_Click;
            Save.ShortcutKeys = Keys.Control | Keys.S;
            fileItem.DropDownItems.Add(Save);

            //�������� ���� ������
            ToolStripMenuItem Close = new ToolStripMenuItem("�������");
            Close.Click += Close_Click;
            Close.ShortcutKeys = Keys.Control | Keys.Escape;
            fileItem.DropDownItems.Add(Close);
            menuStrip1.Items.Add(fileItem);

            //����� ���� ��������� �������
            fileParametersData = new ToolStripMenuItem("��������� �������");
            fileParametersData.Enabled = false;
            ToolStripMenuItem OpenPlan = new ToolStripMenuItem("������ ��������� ���������");
            OpenPlan.Click += InputParameters_Click;
            OpenPlan.ShortcutKeys = Keys.Control | Keys.A;
            fileParametersData.DropDownItems.Add(OpenPlan);

            OpenScheme = new ToolStripMenuItem("������� ���� ���������");
            OpenScheme.Enabled = false;
            OpenScheme.Click += OpenSelectType;
            OpenScheme.ShortcutKeys = Keys.Control | Keys.E;
            fileParametersData.DropDownItems.Add(OpenScheme);

            OpenSelectEquipment = new ToolStripMenuItem("������� ������� ������������");
            OpenSelectEquipment.Enabled = false;
            OpenSelectEquipment.Click += OpenSelectEquipment_Click;
            OpenSelectEquipment.ShortcutKeys = Keys.Control | Keys.D;
            fileParametersData.DropDownItems.Add(OpenSelectEquipment);
            menuStrip1.Items.Add(fileParametersData);

            //����� ���� ��������� ������
            fileItemData = new ToolStripMenuItem("��������� ������");
            fileItemData.Enabled = false;
            ToolStripMenuItem DataItem = new ToolStripMenuItem("������ �� ������������");
            DataItem.Click += DataItem_Click;
            fileItemData.DropDownItems.Add(DataItem);

            //�������� ���� ��������� ������
            ToolStripMenuItem DataOffice = new ToolStripMenuItem("������ � ���������");
            DataOffice.Click += DataOffice_Click;
            fileItemData.DropDownItems.Add(DataOffice);

            //�������� ���� ��������� ������
            ToolStripMenuItem DataPoint = new ToolStripMenuItem("������ � ����������� ������");
            DataPoint.Click += DataPoint_Click;
            fileItemData.DropDownItems.Add(DataPoint);
            menuStrip1.Items.Add(fileItemData);

            //����� ���� ���������
            MakeProjectItem = new ToolStripMenuItem("���������");
            MakeProjectItem.Enabled = false;
            ToolStripMenuItem AlgorithmParameters = new ToolStripMenuItem("��������� ���������� ���������");
            AlgorithmParameters.Click += AlgorithmParameters_Click;
            MakeProjectItem.DropDownItems.Add(AlgorithmParameters);

            ToolStripMenuItem StartAlgorithm = new ToolStripMenuItem("������ ��������� ���������� �������� ������������");
            StartAlgorithm.Click += StartAlgorithm_ClickAsync;
            MakeProjectItem.DropDownItems.Add(StartAlgorithm);

            ToolStripMenuItem CreateDoc = new ToolStripMenuItem("���������� ��������� ������������");
            CreateDoc.Click += CreateDoc_Click;
            MakeProjectItem.DropDownItems.Add(CreateDoc);
            menuStrip1.Items.Add(MakeProjectItem);

            //����� ���� �������
            ToolStripMenuItem Referens = new ToolStripMenuItem("�������");
            ToolStripMenuItem Support = new ToolStripMenuItem("������");
            Support.Click += Support_Clickl;
            Referens.DropDownItems.Add(Support);

            ToolStripMenuItem aboutProgram = new ToolStripMenuItem("� ���������");
            aboutProgram.Click += AboutProgram_Click;
            Referens.DropDownItems.Add(aboutProgram);
            menuStrip1.Items.Add(Referens);

        }

        public void OnStateChanged()
        {
            if (OpenedProjectInfo.State == ProjectState.Startup)
            {
                fileParametersData.Enabled = false;
            }
            if (OpenedProjectInfo.State == ProjectState.OpenedProject)
            {
                fileParametersData.Enabled = true;
            }
        }

        //����� ���������� �� ������ ������ ������������
        private void OpenSelectEquipment_Click(object? sender, EventArgs e)
        {
            using (var dbContext = new MyDbContext())
            {
                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == toolStripLabel3.Text);
                var existingConnections = dbContext.UseNetEquipments.Where(u => u.ProjectId == currentProject.ID).ToList();

                dbContext.UseNetEquipments.RemoveRange(existingConnections);
                dbContext.SaveChanges();

                SelectEquipment selectEquipmentForm = new SelectEquipment();
                selectEquipmentForm.Show();
                listBox1.Items.Clear();
                MakeProjectItem.Enabled = true;
            }

        }

        //����� ���������� �� �������� ������� 
        private void OpenProject_Click(object? sender, EventArgs e)
        {
            var openProjectForm = new OpenProjectForm();
            var result = openProjectForm.ShowDialog();
            if (result != DialogResult.OK) return;
            var projectName = openProjectForm.SelectedProjectName;
            var currentProject = openProjectForm.SelectedProjectName;
            _currentProjectId = openProjectForm.SelectedProjectName;

            toolStripLabel3.Text = projectName;
            OpenedProjectInfo.State = ProjectState.OpenedProject;
            OpenedProjectInfo.OpenedProject = GetProjectName(projectName);
        }

        //����� ���������� �� ����� ���������� �� �������� �������
        private Project? GetProjectName(string projectName)
        {
            using (var dbContext = new MyDbContext())
            {

                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                var pointList = new List<string>();

                listBox1.Items.Clear();

                //����� ������� ��������������� ������������ � ������� �������� �� ������ 
                var BindPoints = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions
                    .Include(dbContext.UseNetEquipments, u => u.NetEquipments)
                    .Where(p => p.ProjectId == currentProject.ID)
                    .ToList();
                if (BindPoints != null)
                {
                    foreach (var bindPoint in BindPoints)
                    {
                        var pointInfo = dbContext.CoordinatesAccessPoints.FirstOrDefault(p => p.ID == bindPoint.PointId);
                        if (pointInfo != null)
                        {
                            string listBoxItem = $"�����: {bindPoint.PointId}, X: {pointInfo.Coordinate_X}, Y: {pointInfo.Coordinate_Y}, ������: {bindPoint.NetEquipments.Radius}";
                            listBox1.Items.Add(listBoxItem);
                        }

                    }
                }

                //����� ���������� ����� ������� ����������� �� �����
                var CountPoint = dbContext.CoordinatesAccessPoints.Count(p => p.ProjectId == currentProject.ID);
                if (CountPoint != 0)
                {
                    toolStripLabel9.Text = CountPoint.ToString();
                    fileItemData.Enabled = true;
                    OpenScheme.Enabled = true;
                    OpenSelectEquipment.Enabled = false;
                }

                //����� ������� ��������� �������
                var CountArea = dbContext.PlanRooms.FirstOrDefault(p => p.ProjectId == currentProject.ID);
                if (CountArea != null)
                {
                    double width = CountArea.Width;
                    double height = CountArea.Height;
                    double Area = height * width;
                    toolStripLabel11.Text = $"{Area} �^2";
                    fileItemData.Enabled = true;
                    OpenScheme.Enabled = true;
                }
                return dbContext.Projects.FirstOrDefault(p => p.Name == projectName);

            }
        }

        //����� ���������� �� �������� �������
        private void CreateProjeck_Click(object? sender, EventArgs e)
        {
            string newProjectName = Microsoft.VisualBasic.Interaction.InputBox("������� �������� �������:", "�������� �������");

            databasePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"{newProjectName}.sqlite");
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlite($"Data Source={databasePath}")
                .Options;

            // ���� �������� ������� ������, ����������
            if (string.IsNullOrEmpty(newProjectName))
                return;

            // �������� ������� ������� � ����� �� ��������� � ���� ������
            var existingProject = MyDbContext.Projects.FirstOrDefault(p => p.Name == newProjectName);
            if (existingProject != null)
            {
                MessageBox.Show("������ � ����� ��������� ��� ����������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string.IsNullOrWhiteSpace(toolStripLabel9.Text);
            toolStripLabel3.Text = newProjectName;
            if (fileParametersData != null)
            {
                fileParametersData.Enabled = true;
                fileItemData.Enabled = true;
            }
            var project = new Project
            {
                Name = newProjectName,

            };
            MyDbContext.Projects.Add(project); // ���������� ������� � ��
            MyDbContext.SaveChanges(); 
            _currentProject = project; // ���������� ���������� ������� ���������� _currentProject
        }

        //����� ���������� �� �������� ��������� ������������ 
        private void CreateDoc_Click(object? sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // ������ ���� � ��� ����� ��� ����������
                SaveFileDialog saveDlg = new SaveFileDialog();
                string filename = "";

                saveDlg.Filter = "Text File (*.png)|*.png";
                saveDlg.DefaultExt = "*.png";
                saveDlg.FilterIndex = 1;
                saveDlg.Title = "Save the Project";

                DialogResult retval = saveDlg.ShowDialog();
                // ��������� ����������� � ����
                if (retval == DialogResult.OK)
                    filename = saveDlg.FileName;
                else
                    return;

                RichTextBoxStreamType stream_type;
                if (saveDlg.FilterIndex == 2)
                    stream_type = RichTextBoxStreamType.PlainText;
                else
                    stream_type = RichTextBoxStreamType.RichText;

                MessageBox.Show("���� ��������");

            }
            else
            {
                // ��������� ������, ����� � PictureBox ��� �����������
                MessageBox.Show("No image to save.");
            }
        }

        //����� ������� ��������� �������� ���������� 
        private async void StartAlgorithm_ClickAsync(object? sender, EventArgs e)
        {
            toolStripProgressBar2.Value = 0;
            // ��������� ��������� �����������
            this.Invoke(new Action(() =>
            {
                StopGenAlgorithm.Enabled = true;
                UpdateEquipment.Enabled = false;
                RefreshPoint.Enabled = false;
                menuStrip1.Enabled = false;
            }));

            await Task.Run(() => SolvePlacement(userChoice));

            // �������� ���� ���������� 
            this.Invoke(new Action(() =>
            {
                StopGenAlgorithm.Enabled = false;
                UpdateEquipment.Enabled = true;
                RefreshPoint.Enabled = true;
                menuStrip1.Enabled = true;
            }));
        }

        //����� ����������� ����� ��� ����� ���������� ���������
        public void AlgorithmParameters_Click(object? sender, EventArgs e)
        {
            AlgorithmParameters AlgorithmParameters = new();
            AlgorithmParameters.Show();

        }

        //������� ������ ���-�� � ���������
        private void AboutProgram_Click(object? sender, EventArgs e)
        {
            DialogResult result = DialogResult = MessageBox.Show("������������������ ������� ���������� �������� ������������ " +
                  "\n\n�����: ������� ����� ��������� \n������ 4414 ",
                  "� ���������", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //������� ������ ������
        private void Support_Clickl(object? sender, EventArgs e)
        {
            DialogResult result = DialogResult = MessageBox.Show("��� ������ ���������� �� �����: \nBasyrovNI@gmail.com ",
                 "������", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //������� ������ ������ � ������
        private void DataPoint_Click(object? sender, EventArgs e)
        {
            if (_currentProject == null && _currentProjectId == null)
            {
                DialogResult result = MessageBox.Show("������ �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (listBox1.Items.Count == 0)
            {
                DialogResult result = MessageBox.Show("����� �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string projectId = _currentProjectId;

            if (string.IsNullOrEmpty(projectId) && _currentProject != null)
            {
                projectId = _currentProject.Name.ToString();
            }

            if (!string.IsNullOrEmpty(projectId))
            {
                InfoPoints infoPointsForm = new InfoPoints(projectId);
                infoPointsForm.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("�� ������� ���������� ID �������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //������� ������ ������ � ��������� 
        private void DataOffice_Click(object? sender, EventArgs e)
        {
            if (_currentProject == null && _currentProjectId == null)
            {
                DialogResult result = MessageBox.Show("������ �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (string.IsNullOrWhiteSpace(toolStripLabel11.Text))
            {
                DialogResult result = MessageBox.Show("��������� �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string projectId = _currentProjectId;

            if (string.IsNullOrEmpty(projectId) && _currentProject != null)
            {
                projectId = _currentProject.Name.ToString();
            }

            if (!string.IsNullOrEmpty(projectId))
            {
                InfoLocation newForm = new InfoLocation(projectId);
                newForm.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("�� ������� ���������� ID �������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //������� ������ ������ � ��������� ������������
        private void DataItem_Click(object? sender, EventArgs e)
        {

            InfoEquipments newForm = new InfoEquipments();
            newForm.Show();
        }

        //���������� ������ �������� �������
        private void Close_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("������������� ������ �����?", "����� �� ���������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {

            }
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //���������� ������ ���������� �������
        private void Save_Click(object? sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            saveDlg.Filter = "Text File (*.txt)|*.txt|Text File (*.png)|*.png";
            saveDlg.DefaultExt = "*.png";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the Project";

            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;

            RichTextBoxStreamType stream_type;
            if (saveDlg.FilterIndex == 2)
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;

            MessageBox.Show("���� ��������");


        }

        //���������� �������: SavePoint_Click
        private void SavePoint_Click(object? sender, EventArgs e)
        {
            // �������� ������ ��������� �����
            List<System.Drawing.Point> selectedPoints = new List<System.Drawing.Point>();

            foreach (var point in selectedPoints)
            {
                var coordinates = new CoordinatesAccessPoints
                {
                    Coordinate_X = point.X,
                    Coordinate_Y = point.Y
                };

                MyDbContext.CoordinatesAccessPoints.Add(coordinates);
            }

            MyDbContext.SaveChanges();
            MessageBox.Show("���������� ����� ��������� � ���� ������.");
        }

        //���������� ��������� � ��
        private void AddCoordinatesToDatabase(List<System.Drawing.Point> points)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.BeginTransaction(); // ������ ����������

                string projectName = toolStripLabel3.Text;

                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                if (currentProject == null)
                {
                    MessageBox.Show("������ �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var oldPoints = dbContext.CoordinatesAccessPoints.Where(p => p.ProjectId == currentProject.ID);
                dbContext.CoordinatesAccessPoints.RemoveRange(oldPoints);



                foreach (var point in points)
                {
                    var coordinatesAccessPoints = new CoordinatesAccessPoints
                    {
                        Coordinate_X = point.X,
                        Coordinate_Y = point.Y,
                        ProjectId = currentProject.ID
                    };
                    dbContext.CoordinatesAccessPoints.Add(coordinatesAccessPoints);

                }

                dbContext.SaveChanges();

                dbContext.Database.CommitTransaction(); // �������� ���������
                OpenedProjectInfo.OpenedProject = currentProject;

                if (currentProject != null)
                {
                    var CountPoint = dbContext.CoordinatesAccessPoints.Count(p => p.ProjectId == currentProject.ID);
                    if (CountPoint != null)
                    {
                        toolStripLabel9.Text = CountPoint.ToString();
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        //����� ���������� �� ������ "�������� �����"
        private void RefreshPoint_Click(object? sender, EventArgs e)
        {
            if(userChoice == OptionType.Option2)
            {
                OpenScheme_Click(sender, e, userChoice);
            }
            else
            {
                return;
            }
        }

        //����� ���������� �� ��������� ��� ����������
        private void OpenSelectType(object? sender, EventArgs e)
        {
            SelectEquipmentType selectEquipmentType = new SelectEquipmentType(this);
            selectEquipmentType.OnUserMadeChoice += SelectEquipmentType_OnUserMadeChoice;
            selectEquipmentType.Show();
        }

        private void SelectEquipmentType_OnUserMadeChoice(OptionType selectedOption)
        {
            // ������������� ����� ������������
            userChoice = selectedOption;
        }

        //����� ���������� �� �������� ����� ���������
        public void OpenScheme_Click(object? sender, EventArgs e, OptionType selectedOption)
        {
            if (isImageOpened)
            {
                DialogResult result = MessageBox.Show("������� ����������� ����� �������! ����������?", "��������������",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK) // ��
                {
                    CloseImage();
                    pictureBox1.Invalidate();
                    listBox1.Items.Clear();

                    // ����� ��������� ��� ��� �������� ����� GetPoints
                    using (var dbContext = new MyDbContext())
                    {
                        var project = dbContext.Projects.FirstOrDefault(p => p.Name == toolStripLabel3.Text);
                        if (project != null)
                        {
                            var ParamPictureBox = dbContext.PlanRooms.FirstOrDefault(pr => pr.ProjectId == project.ID);
                            if (ParamPictureBox != null)
                            {
                                double Width = ParamPictureBox.Width;
                                double Height = ParamPictureBox.Height;
                                GetPoints.SetRoomDimensions(Width, Height);
                                GetPoints controlPoints = new GetPoints(this, selectedOption);
                                controlPoints.PointsTransferred += AddCoordinatesToDatabase;
                                controlPoints.ImageOpened += ControlPointsForm_ImageOpened;
                                controlPoints.Show();
                            }
                        }
                    }
                }
                else // Cansel
                {
                    return;
                }
            }
            else
            {
                using (var dbContext = new MyDbContext())
                {
                    var project = dbContext.Projects.FirstOrDefault(p => p.Name == toolStripLabel3.Text);
                    if (project != null)
                    {
                        var ParamPictureBox = dbContext.PlanRooms.FirstOrDefault(pr => pr.ProjectId == project.ID);
                        if (ParamPictureBox != null)
                        {
                            double Widht = ParamPictureBox.Width;
                            double Height = ParamPictureBox.Height;
                            GetPoints.SetRoomDimensions(Widht, Height);
                            GetPoints ControlPoints = new GetPoints(this, selectedOption);
                            ControlPoints.PointsTransferred += AddCoordinatesToDatabase;
                            ControlPoints.ImageOpened += ControlPointsForm_ImageOpened;
                            ControlPoints.Show();

                        }
                    }
                }

            }
            if (selectedOption == OptionType.Option2)
            {
                OpenSelectEquipment.Enabled = true;
                MakeProjectItem.Enabled = false;
                fileItemData.Enabled = true;
                UpdateEquipment.Enabled = true;
                RefreshPoint.Enabled = true;
            }
            else
            {
                using (var dbContext = new MyDbContext())
                {
                    string projectName = toolStripLabel3.Text;
                    var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                    if (currentProject != null)
                    {
                        var oldPoints = dbContext.CoordinatesAccessPoints.Where(p => p.ProjectId == currentProject.ID);
                        dbContext.CoordinatesAccessPoints.RemoveRange(oldPoints);
                        dbContext.SaveChanges();
                        toolStripLabel9.Text = " ";
                    }
                }

                listBox1.Items.Clear();
                MakeProjectItem.Enabled = true;
                OpenSelectEquipment.Enabled = false;
                fileItemData.Enabled = true;
                UpdateEquipment.Enabled = true;

            }
       

        }

        //����� ���������� �� �������� ��������� ����������� �� �����
        private void ControlPointsForm_ImageOpened(Bitmap openedImage)
        {
            if (isImageOpened)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                originalImage.Dispose();
                originalImage = null;
            }

            pictureBox1.Image = openedImage;
            originalImage = openedImage;
            CropImageByContour();

            isImageOpened = true; // ��������� �����, ��� ����������� �������
        }

        //��� �������� �������� �����������
        private void CloseImage()
        {
            if (isImageOpened)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                originalImage.Dispose();
                originalImage = null;
                isImageOpened = false; // ����� �����

                // ����� ��������, ������������ ��� ���������
                pictureBox1.Invalidate();
                accessPoints = null;
            }

        }

        //����� ��������� �� ��������� �� pictureBox
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (pictureBox1.Image == null)
                return;

            if (bestSolution == null || accessPoints == null) // �������� ��� ���������
                return;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Color[] colors = {
            Color.FromArgb(128, Color.Red),
            Color.FromArgb(128, Color.Blue),
            Color.FromArgb(128, Color.Green),
            Color.FromArgb(128, Color.Yellow),
            Color.FromArgb(128, Color.Purple)
            };

            Font font = new Font("Arial", 10); // ����� ��� �������
            Brush textBrush = Brushes.White; // ���� ������

            // ��������������� ��������� ����� �� �����������
            double scaleX = (double)pictureBox1.Width / roomWidth;
            double scaleY = (double)pictureBox1.Height / roomHeight;
            double scaleCoefficient = 1.04; // ����������� ���������������

            // ���������� ��� ���� � ������ ���������
            if (bestSolution != null && accessPoints != null)
            {
                for (int i = 0; i < bestSolution.Genes.Length; i++)
                {
                    // ���� ��� ����� 1, ������ ������ ����� �������������� � ��������� � � ����� ����������
                    if (bestSolution.Genes[i] == 1)
                    {
                        int coordinateX = accessPoints[i, 0]; // � �������� �������� ���������
                        int coordinateY = accessPoints[i, 1]; // � �������� �������� ���������

                        // ���������� �������
                        int radius = accessPoints[i, 2]; // � �������� �������� ���������

                        // ���������� ��������� ����� � �������� �� �����������
                        int x = (int)(coordinateX * scaleX);
                        int y = (int)(coordinateY * scaleY);
                        int r = (int)(radius * (scaleX + scaleY) / 2 * scaleCoefficient);

                        // ����� ����� �����
                        Color color = colors[i % colors.Length];
                        Brush brush = new SolidBrush(color);

                        // ��������� �����
                        g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r);

                        // ��������� ������ �����
                        string pointNumber = (i + 1).ToString();
                        SizeF textSize = g.MeasureString(pointNumber, font);
                        g.DrawString(pointNumber, font, Brushes.Black, x - textSize.Width / 2, y - textSize.Height / 2);
                    }
                }
            }
        }

        //����� ��� ������������� ���������� ����� ����� �������
        public class PointDistance
        {
            public System.Drawing.Point Point1 { get; }  // ������ �����
            public System.Drawing.Point Point2 { get; }  // ������ �����
            public double Distance { get; }  // ���������� ����� �������

            public PointDistance(System.Drawing.Point point1, System.Drawing.Point point2, double distance)
            {
                Point1 = point1;
                Point2 = point2;
                Distance = distance;
            }
        }

        //���������� ���������� ��������� � ��
        private void InputParameters_Click(object? sender, EventArgs e)
        {
            string projectName = toolStripLabel3.Text;

            InputParameters newForm = new InputParameters();

            var project = MyDbContext.Projects.FirstOrDefault(p => p.Name == projectName);
            if (project == null)
            {
                MessageBox.Show("������ �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            newForm.RoomDimensionsEntered += (width, height) =>
            {
                var existingPlanRoom = MyDbContext.PlanRooms.FirstOrDefault(pr => pr.ProjectId == project.ID);
                if (existingPlanRoom != null)
                {
                    MyDbContext.PlanRooms.Remove(existingPlanRoom);
                }

                var planRoom = new PlanRoom
                {
                    Width = width,
                    Height = height,
                    ProjectId = project.ID,
                    Project = project
                };

                MyDbContext.PlanRooms.Add(planRoom);
                MyDbContext.SaveChanges();

                var AreaProject = MyDbContext.PlanRooms.FirstOrDefault(p => p.ProjectId == project.ID);
                if (AreaProject != null)
                {
                    double Area = AreaProject.Height * AreaProject.Width;
                    toolStripLabel11.Text = $"{Area} �^2";
                }
            };

            newForm.Show();
            OpenScheme.Enabled = true;
        }

        //����� ���������� �� ������� ����������� �� �������
        private void CropImageByContour()
        {
            if (originalImage == null)
                return;

            // ���������� ����������� ������� ���������
            List<PointF> contour = DetectFloorPlanContour();

            if (contour == null)
            {
                MessageBox.Show("Floor plan contour not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ����������� ��������������� �������������� ������ �������
            RectangleF boundingBox = GetBoundingBox(contour);

            // �������� ������ ����������� ��� �������
            Bitmap croppedImage = new Bitmap((int)boundingBox.Width, (int)boundingBox.Height);

            // ������������� Graphics ��� ��������� ������� �� ����� �����������
            using (Graphics graphics = Graphics.FromImage(croppedImage))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.FillPolygon(Brushes.Black, contour.ToArray());
            }

            // ����������� ������ �������� ������ ������� �� ������������� ����������� � ���������� �����������
            for (int y = 0; y < croppedImage.Height; y++)
            {
                for (int x = 0; x < croppedImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel((int)(x + boundingBox.X), (int)(y + boundingBox.Y));
                    croppedImage.SetPixel(x, y, originalColor);
                }
            }
            pictureBox1.Image = croppedImage;
        }

        //�������� �������������� ������ �������������
        private RectangleF GetBoundingBox(List<PointF> contour)
        {
            float padding = -2f; // �������� �������
            float minX = Math.Max(0, contour.Min(p => p.X) - padding);
            float minY = Math.Max(0, contour.Min(p => p.Y) - padding);
            float maxX = Math.Min(originalImage.Width, contour.Max(p => p.X) + padding);
            float maxY = Math.Min(originalImage.Height, contour.Max(p => p.Y) + padding);
            return RectangleF.FromLTRB(minX, minY, maxX, maxY);
        }
       
        private List<PointF> DetectFloorPlanContour()
        {
            if (originalImage == null)
                return null;

            // �������������� ����������� � ������ Grayscale
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayscaleImage = grayscaleFilter.Apply(originalImage);

            // ���������� ������� Canny Edge Detector
            CannyEdgeDetector edgeDetector = new CannyEdgeDetector();
            Bitmap edgesImage = edgeDetector.Apply(grayscaleImage);

            // ������������� ������� SimpleShapeChecker ��� ������ ������� ���������
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            shapeChecker.MinAcceptableDistortion = 0.5f;
            shapeChecker.RelativeDistortionLimit = 0.03f;

            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(edgesImage);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // ����� ����������� ������� ���������
            List<IntPoint> floorPlanContour = null;
            double maxArea = 0;

            foreach (Blob blob in blobs)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blob);
                List<IntPoint> contour;
                if (shapeChecker.IsConvexPolygon(edgePoints, out contour))
                {
                    double area = CalculatePolygonArea(contour);
                    if (area > maxArea)
                    {
                        maxArea = area;
                        floorPlanContour = contour;
                    }
                }
            }

            if (floorPlanContour != null)
            {
                // �������������� ����� ������� � PointF
                List<PointF> contourPoints = new List<PointF>();
                foreach (IntPoint point in floorPlanContour)
                {
                    contourPoints.Add(new PointF(point.X, point.Y));
                }

                // ������������ ��������
                edgesImage.Dispose();
                grayscaleImage.Dispose();

                return contourPoints;
            }
            else
            {
                // ������������ ��������
                edgesImage.Dispose();
                grayscaleImage.Dispose();

                return null;
            }
        }

        //������� ������������� �������
        private double CalculatePolygonArea(List<IntPoint> polygon)
        {

            PointF[] points = new PointF[polygon.Count];

            for (int i = 0; i < polygon.Count; i++)
            {
                points[i] = new PointF(polygon[i].X, polygon[i].Y);
            }

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points);

            using (PathGradientBrush brush = new PathGradientBrush(path))
            {
                GraphicsPath brushPath = (GraphicsPath)path.Clone();
                RectangleF bounds = brushPath.GetBounds();
                double area = bounds.Width * bounds.Height;

                // ������������ ��������
                brushPath.Dispose();

                return area;
            }

        }


        //������������ �������� 
        static Random random = new Random();
        static List<Chromosome> population = new List<Chromosome>();
        static double[] lastBestFitness = { -1, -1, -1, -1, -1, -1, -1 };
        private static int[,] accessPoints;
        public static int? K;
        private static double coverageRadius;
        private static double coverageArea;
        private static int populationSize;
        public static double? crossoverRate;
        public static double? mutationRate;
        public static int? numberGeneration;
        public static double roomWidth;
        public static double roomHeight;
        static Chromosome bestSolution = null;


        public void UpdateValue(object value)
        {
            coverageRadius = (double)value;
        }
        public class AccessPoint
        {
            public int Coordinate_X { get; set; }
            public int Coordinate_Y { get; set; }
            public double? Radius { get; set; }
        }

        //����� ������������ �� ���������� ���������
        private void SolvePlacement(OptionType userChoice)
        {
            bool isManualPlacement = false; // ����, �����������, ������������ �� ������ ����������
            bool isRepeatedAutomaticPlacement = false; // ����, �����������, ����������� �� �������������� ����������

            // ���������, ������ �� ��������� ���������
            if (mutationRate == null || crossoverRate == null || numberGeneration == null || K == null)
            {
                MessageBox.Show("������� ��������� ��������� ���������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AlgorithmParameters algorithmParameters = new AlgorithmParameters();
                algorithmParameters.ShowDialog();
                return;
            }

            int index = 0;

            // �������� � ����� ������
            using (var dbContext = new MyDbContext())
            {
                string projectName = toolStripLabel3.Text;
                // �������� ������� ������
                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                if (currentProject == null)
                {
                    MessageBox.Show("������ �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // �������� ������� �������
                var room = dbContext.PlanRooms.FirstOrDefault(r => r.ProjectId == currentProject.ID);
                if (room != null)
                {
                    roomWidth = room.Width;
                    roomHeight = room.Height;
                }

                // �������� ����� ������� � �� �������
                var points = dbContext.CoordinatesAccessPoints
                .Where(p => p.ProjectId == currentProject.ID)
                .Select(p => new AccessPoint
                {
                    Coordinate_X = p.Coordinate_X,
                    Coordinate_Y = p.Coordinate_Y,
                    Radius = dbContext.UseNetEquipments
                    .Where(u => u.PointId == p.ID)
                    .Select(u => u.NetEquipments.Radius)
                    .FirstOrDefault()
                })
                .ToArray();

                // ��������� ������� ���������
                populationSize = points.Length > 0 ? points.Length : CalculatePopulationSize(roomWidth, roomHeight, coverageRadius);

                // ���������, ���� ���� ����� �������, �� ���������� ������
                if (userChoice == OptionType.Option2)
                {
                    isManualPlacement = true;

                }
                else if (userChoice == OptionType.Option1) // �������������� ����������
                {
                    points = AutomaticPlacement(populationSize, coverageRadius, roomWidth, roomHeight).ToArray();
                    foreach (var point in points)
                    {
                        dbContext.CoordinatesAccessPoints.Add(new CoordinatesAccessPoints
                        {
                            Coordinate_X = point.Coordinate_X,
                            Coordinate_Y = point.Coordinate_Y,
                            ProjectId = currentProject.ID
                        });

                        coverageRadius = point.Radius.HasValue ? Convert.ToInt32(point.Radius.Value) : 0;
                        coverageArea += Math.PI * Math.Pow(coverageRadius, 2);
                    }
                    dbContext.SaveChanges();
                }
                else if (isRepeatedAutomaticPlacement) // ��������� ������� ��� ���������� ��������������� ����������
                {
                    // �������� ������������ ����� ������� �� ���� ������
                    var existingPoints = dbContext.CoordinatesAccessPoints.Where(p => p.ProjectId == currentProject.ID);
                    dbContext.CoordinatesAccessPoints.RemoveRange(existingPoints);
                    dbContext.SaveChanges();

                    // ��������� �������������� ����������
                    points = AutomaticPlacement(populationSize, coverageRadius, roomWidth, roomHeight).ToArray();
                    foreach (var point in points)
                    {
                        dbContext.CoordinatesAccessPoints.Add(new CoordinatesAccessPoints
                        {
                            Coordinate_X = point.Coordinate_X,
                            Coordinate_Y = point.Coordinate_Y,
                            ProjectId = currentProject.ID
                        });

                        coverageRadius = point.Radius.HasValue ? Convert.ToInt32(point.Radius.Value) : 0;
                        coverageArea += Math.PI * Math.Pow(coverageRadius, 2);
                    }
                    dbContext.SaveChanges();
                }

                var pointsArray = points.Select(p => new { p.Coordinate_X, p.Coordinate_Y, p.Radius }).ToArray();

                // �������������� ������ ����� � ��������� ������
                accessPoints = new int[pointsArray.Length, 3];
                foreach (var point in pointsArray)
                {
                    accessPoints[index, 0] = point.Coordinate_X;
                    accessPoints[index, 1] = point.Coordinate_Y;
                    accessPoints[index, 2] = point.Radius.HasValue ? Convert.ToInt32(point.Radius.Value) : 0;
                    index++;

                    coverageRadius = point.Radius.HasValue ? Convert.ToInt32(point.Radius.Value) : 0;
                    coverageArea += Math.PI * Math.Pow(coverageRadius, 2);
                }

            }


            for (int i = 0; i < populationSize; i++)
            {
                population.Add(GenerateRandomChromosome());
            }

            // ������������ ������ �������� ����������� ��� �������� ���������
            ConcurrentBag<double> fitnessResults = new ConcurrentBag<double>();

            System.Threading.Tasks.Parallel.For(0, populationSize, i =>
            {
                double fitness = CalculateFitness(population[i]);
                fitnessResults.Add(fitness);
            });

            // ���������� ������� ���������� �����������
            lastBestFitness[0] = CalculateFitness(population[0]);

            // ������������� ���������� ��� ����� ���������
            int maxGenerations = (int)numberGeneration;
            int currentGeneration = 0;

            this.Invoke(new Action(() =>
            {
                toolStripProgressBar2.Maximum = maxGenerations;
                toolStripProgressBar2.Value = 0;
            }));

            // ���� ������������� ���������
            while (currentGeneration < maxGenerations && !stopAlgorithm)
            {
                Crossover();
                Mutate();

                // ���������� ��������� �� �������� �����������
                population = population
                    .OrderByDescending(c => CalculateFitness(c))
                    .Take(populationSize)
                    .ToList();

                lastBestFitness[6] = lastBestFitness[5];
                lastBestFitness[5] = lastBestFitness[4];
                lastBestFitness[4] = lastBestFitness[3];
                lastBestFitness[3] = lastBestFitness[2];
                lastBestFitness[2] = lastBestFitness[1];
                lastBestFitness[1] = lastBestFitness[0];
                lastBestFitness[0] = CalculateFitness(population[0]);

                if (lastBestFitness[0] == lastBestFitness[1] && lastBestFitness[0] == lastBestFitness[2])
                {
                    break;
                }

                // ���������� ��������� ����������
                this.Invoke(new Action(() => { toolStripProgressBar2.Value = currentGeneration; }));

                currentGeneration++;
            }

            // ��������, ���� �������� ��� ���������� �������������
            if (stopAlgorithm)
            {
                DialogResult result = DialogResult = MessageBox.Show("�������� �������",
                  "��������!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            this.Invoke(new Action(() =>
            {
                // ���������� ���������� ����� ���������� ���������
                toolStripProgressBar2.Value = toolStripProgressBar2.Maximum;

                int countOnes = population[0].Genes.Count(g => g == 1);
                DialogResult resul = DialogResult = MessageBox.Show($"\n���������� ������������� ������������: {countOnes}, " +
                  $"\n�������� ������� �����������: {CalculateFitness(population[0]).ToString("F2")}",
                  "��������", MessageBoxButtons.OK, MessageBoxIcon.Question);
                string formattedFitness = CalculateFitness(population[0]).ToString("F2");
                toolStripLabel7.Text = formattedFitness + " �^2";
                bestSolution = population[0];
                pictureBox1.Invalidate();
                StopGenAlgorithm.Enabled = false;

                // �������������� �������� � ��������� ��� ������� ����������
                if (isManualPlacement && !isRepeatedAutomaticPlacement && bestSolution != null)
                {
                    List<AccessPoint> accessPointList = new List<AccessPoint>();
                    for (int i = 0; i < accessPoints.GetLength(0); i++)
                    {
                        if (population[0].Genes[i] == 1)
                        {
                            int coordinateX = accessPoints[i, 0];
                            int coordinateY = accessPoints[i, 1];
                            int Radius = accessPoints[i, 2];
                            accessPointList.Add(new AccessPoint { Coordinate_X = coordinateX, Coordinate_Y = coordinateY, Radius = coverageRadius });
                        }
                    }

                    int additionalAPsNeeded = CalculateAdditionalAccessPointsNeeded(accessPointList, coverageRadius, roomWidth, roomHeight);
                    DialogResult result = DialogResult = MessageBox.Show($"��� ������� �������� ��������� ����������� ��� �������:" +
                        $"\n{additionalAPsNeeded} �������������� ����� �������.", "��������!", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }

                // ����� ��������� ����� ������� � �������� 
                listBox1.Items.Clear();
                for (int i = 0; i < accessPoints.GetLength(0); i++)
                {
                    if (population[0].Genes[i] == 1)
                    {
                        int coordinateX = accessPoints[i, 0];
                        int coordinateY = accessPoints[i, 1];
                        int Radius = accessPoints[i, 2];
                        listBox1.Items.Add($"����� {i + 1}: X = {coordinateX}, Y = {coordinateY}, ������: {Radius} ");
                        toolStripLabel9.Text = countOnes.ToString();
                    }
                }

            }));
        }

        //����� ��� ��������������� ����������, ������������ ������ ���������
        private int CalculatePopulationSize(double roomWidth, double roomHeight, double coverageRadius)
        {
            double roomArea = roomWidth * roomHeight;
            int populationSize = 0;
            double remainingArea = roomArea;
            double overlappingArea = 0;

            while (remainingArea > 0)
            {
                populationSize++;
                List<AccessPoint> accessPoints = AutomaticPlacement(populationSize, coverageRadius, roomWidth, roomHeight);

                bool isOverlapping = false;

                for (int i = 0; i < accessPoints.Count; i++)
                {
                    for (int j = i + 1; j < accessPoints.Count; j++)
                    {
                        double dist = Distance(new int[] { accessPoints[i].Coordinate_X, accessPoints[i].Coordinate_Y },
                                               new int[] { accessPoints[j].Coordinate_X, accessPoints[j].Coordinate_Y });

                        double overlap = OverlapArea(dist, coverageRadius, coverageRadius);

                        if (overlap > 0)
                        {
                            overlappingArea += overlap;
                            isOverlapping = true;
                        }
                    }
                }

                double effectiveCoverageArea = populationSize * Math.PI * Math.Pow(coverageRadius, 2) - overlappingArea;
                remainingArea = roomArea - effectiveCoverageArea;

                if (remainingArea >= roomArea)
                {
                    break;
                }
            }

            return populationSize;
        }

        //����� ��� ������� ����������, ������������ ������� ����������� ��� ����� �������
        private int CalculateAdditionalAccessPointsNeeded(List<AccessPoint> currentAccessPoints, double coverageRadius, double roomWidth, double roomHeight)
        {
            double effectiveCoveredArea = 0;
            double overlappingArea = 0;

            // ������� �������, �������� �������� ������� �������
            for (int i = 0; i < currentAccessPoints.Count; i++)
            {
                for (int j = i + 1; j < currentAccessPoints.Count; j++)
                {
                    double dist = Distance(new int[] { currentAccessPoints[i].Coordinate_X, currentAccessPoints[i].Coordinate_Y },
                                            new int[] { currentAccessPoints[j].Coordinate_X, currentAccessPoints[j].Coordinate_Y });
                    double overlap = OverlapArea(dist, coverageRadius, coverageRadius);
                    if (overlap > 0)
                    {
                        overlappingArea += overlap;
                    }
                }
            }

            effectiveCoveredArea = currentAccessPoints.Count * Math.PI * Math.Pow(coverageRadius, 2) - overlappingArea;

            double roomArea = roomWidth * roomHeight;
            double remainingArea = roomArea - effectiveCoveredArea;

            // �������, ������� �������������� ����� ������� ����������
            double singleAPCoverageArea = Math.PI * Math.Pow(coverageRadius, 2);
            return (int)Math.Ceiling(remainingArea / singleAPCoverageArea);
        }

        public class Chromosome
        {
            public int[] Genes { get; set; }
        }

        //����� ���������� �� �������
        public static void Mutate()
        {

            foreach (var individual in population)
            {
                if (random.NextDouble() < mutationRate)
                {
                    int j = random.Next(individual.Genes.Length);
                    individual.Genes[j] = 1 - individual.Genes[j];
                }
            }
        }

        //����� ���������� �� ����� ��� ���������
        static Chromosome SelectParent()
        {
            double totalFitness = population.Sum(CalculateFitness);
            double spin = random.NextDouble() * totalFitness;
            double current = 0;
            foreach (var individual in population)
            {
                current += CalculateFitness(individual);
                if (current >= spin)
                {
                    return individual;
                }
            }
            return population[0];
        }

        //����� ���������� �� �����������
        static void Crossover()
        {
            var newGeneration = new List<Chromosome>();
            int numGenes = accessPoints.GetLength(0);

            for (int i = 0; i < populationSize; i++)
            {
                Chromosome parent1 = SelectParent();
                Chromosome parent2 = SelectParent();
                Chromosome child = new Chromosome { Genes = new int[numGenes] };

                for (int j = 0; j < numGenes; j++)
                {
                    if (random.NextDouble() < crossoverRate)
                    {
                        child.Genes[j] = random.NextDouble() < 0.5 ? parent1.Genes[j] : parent2.Genes[j];
                    }
                    else
                    {
                        child.Genes[j] = parent1.Genes[j];
                    }
                }

                newGeneration.Add(child);
            }

            population.AddRange(newGeneration);
        }

        static Chromosome GenerateRandomChromosome()
        {
            var newChromosome = new Chromosome();
            if (accessPoints != null)
            {
                newChromosome.Genes = new int[accessPoints.GetLength(0)];
                for (int i = 0; i < accessPoints.GetLength(0); i++)
                {
                    newChromosome.Genes[i] = random.Next(2);
                }
            }
            return newChromosome;
        }

        //������ ������� �������
        static double CalculateFitness(Chromosome c)
        {

            int usedAccessPoints = c.Genes.Sum();
            double totalCoverage = 0;

            int accessPointsCount = accessPoints.GetLength(0);

            for (int i = 0; i < c.Genes.Length; i++)
            {
                if (i >= accessPointsCount) break;
                if (c.Genes[i] == 0) continue;

                int coordinateX_i = accessPoints[i, 0];
                int coordinateY_i = accessPoints[i, 1];
                int radius_i = accessPoints[i, 2];

                totalCoverage += CalculateCoverageArea(coordinateX_i, coordinateY_i, radius_i, roomWidth, roomHeight);

                for (int j = i + 1; j < c.Genes.Length; j++)
                {
                    if (j >= accessPointsCount) break;
                    if (c.Genes[j] == 0) continue;

                    int coordinateX_j = accessPoints[j, 0];
                    int coordinateY_j = accessPoints[j, 1];
                    int radius_j = accessPoints[j, 2];

                    double dist = Distance(new int[] { coordinateX_i, coordinateY_i }, new int[] { coordinateX_j, coordinateY_j });
                    if (dist < 2 * Math.Max(radius_i, radius_j))
                    {
                        double overlapArea = OverlapArea(dist, radius_i, radius_j);
                        totalCoverage -= overlapArea;
                    }
                }
            }

            return totalCoverage - (double)K * usedAccessPoints;
        }

        //������ �������� �������
        static double CalculateCoverageArea(int centerX, int centerY, double radius, double roomWidth, double roomHeight)
        {
            double r2 = radius * radius;

            // ��������� ����������� ����� � ��������� �������
            double x1 = Math.Max(centerX - radius, 0);
            double x2 = Math.Min(centerX + radius, roomWidth);
            double y1 = Math.Max(centerY - radius, 0);
            double y2 = Math.Min(centerY + radius, roomHeight);

            int steps = 1000; // �������� �������� ����������
            double step = (x2 - x1) / steps;
            double area = 0;

            for (double x = x1; x <= x2; x += step)
            {
                for (double y = y1; y <= y2; y += step)
                {
                    double dx = x - centerX;
                    double dy = y - centerY;
                    double distanceSquared = dx * dx + dy * dy;

                    if (distanceSquared <= r2)
                    {
                        area += step * step;
                    }
                }
            }

            return area;
        }
        
        //������ ������� ����������
        static double OverlapArea(double d, double r, double R)
        {
            if (d >= r + R) return 0;
            if (d <= Math.Abs(R - r)) return Math.PI * Math.Pow(Math.Min(r, R), 2);

            double r2 = r * r;
            double R2 = R * R;
            double d2 = d * d;

            double alpha = Math.Acos((d2 + r2 - R2) / (2 * d * r));
            double beta = Math.Acos((d2 + R2 - r2) / (2 * d * R));

            double area1 = r2 * alpha - 0.5 * r2 * Math.Sin(2 * alpha);
            double area2 = R2 * beta - 0.5 * R2 * Math.Sin(2 * beta);

            return area1 + area2;
        }
        
        //������ ��������� ����� �������
        static double Distance(int[] point1, int[] point2)
        {
            int xDiff = point1[0] - point2[0];
            int yDiff = point1[1] - point2[1];
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        //������ ����� ��� ������������� ����������
        private List<AccessPoint> AutomaticPlacement(int populationSize, double coverageRadius, double roomWidth, double roomHeight)
        {
            List<AccessPoint> accessPoints = new List<AccessPoint>();

            double step = coverageRadius * Math.Sqrt(2); // ��� ������������ �����, ����� �������������� ����������

            for (double x = step / 2; x < roomWidth; x += step)
            {
                for (double y = step / 2; y < roomHeight; y += step)
                {
                    accessPoints.Add(new AccessPoint
                    {
                        Coordinate_X = (int)x,
                        Coordinate_Y = (int)y,
                        Radius = coverageRadius
                    });


                    if (accessPoints.Count >= populationSize)
                    {
                        return accessPoints;
                    }
                }
            }
            return accessPoints;
        }

        // ����� ���������� �� ������ �������� ������������
        private void UpdateEquipment_Click(object sender, EventArgs e)
        {
            if (userChoice == OptionType.Option1)
            {
                GetPoints getPoints = new GetPoints(this, userChoice);
                getPoints.PlanApproveClick_Click();
            }
            else
            {
                using (var dbContext = new MyDbContext())
                {

                    var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == toolStripLabel3.Text);
                    var existingConnections = dbContext.UseNetEquipments.Where(u => u.ProjectId == currentProject.ID).ToList();

                    dbContext.UseNetEquipments.RemoveRange(existingConnections);
                    dbContext.SaveChanges();

                    SelectEquipment selectEquipmentForm = new SelectEquipment();
                    selectEquipmentForm.Show();

                }
            }
        }

        // ����� ���������� �� ��������� ���������
        private void StopGenAlgorithm_Click(object sender, EventArgs e)
        {
            stopAlgorithm = true;
        }
    }

}