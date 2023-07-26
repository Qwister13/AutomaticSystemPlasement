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

            //Пункт меню Проект
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Проект");
            ToolStripMenuItem CreateProject = new ToolStripMenuItem("Создать проект");
            CreateProject.Click += CreateProjeck_Click;
            CreateProject.ShortcutKeys = Keys.Control | Keys.F2;
            fileItem.DropDownItems.Add(CreateProject);

            ToolStripMenuItem OpenProject = new ToolStripMenuItem("Открыть проект");
            OpenProject.Click += OpenProject_Click;
            OpenProject.ShortcutKeys = Keys.Control | Keys.R;
            fileItem.DropDownItems.Add(OpenProject);

            ToolStripMenuItem Save = new ToolStripMenuItem("Сохранить проект");
            Save.Click += Save_Click;
            Save.ShortcutKeys = Keys.Control | Keys.S;
            fileItem.DropDownItems.Add(Save);

            //Подпункт меню Проект
            ToolStripMenuItem Close = new ToolStripMenuItem("Закрыть");
            Close.Click += Close_Click;
            Close.ShortcutKeys = Keys.Control | Keys.Escape;
            fileItem.DropDownItems.Add(Close);
            menuStrip1.Items.Add(fileItem);

            //Пункт меню Параметры проекта
            fileParametersData = new ToolStripMenuItem("Параметры проекта");
            fileParametersData.Enabled = false;
            ToolStripMenuItem OpenPlan = new ToolStripMenuItem("Ввести параметры помещения");
            OpenPlan.Click += InputParameters_Click;
            OpenPlan.ShortcutKeys = Keys.Control | Keys.A;
            fileParametersData.DropDownItems.Add(OpenPlan);

            OpenScheme = new ToolStripMenuItem("Открыть план помещения");
            OpenScheme.Enabled = false;
            OpenScheme.Click += OpenSelectType;
            OpenScheme.ShortcutKeys = Keys.Control | Keys.E;
            fileParametersData.DropDownItems.Add(OpenScheme);

            OpenSelectEquipment = new ToolStripMenuItem("Выбрать сетевое оборудование");
            OpenSelectEquipment.Enabled = false;
            OpenSelectEquipment.Click += OpenSelectEquipment_Click;
            OpenSelectEquipment.ShortcutKeys = Keys.Control | Keys.D;
            fileParametersData.DropDownItems.Add(OpenSelectEquipment);
            menuStrip1.Items.Add(fileParametersData);

            //Пункт меню Проектные данные
            fileItemData = new ToolStripMenuItem("Проектные данные");
            fileItemData.Enabled = false;
            ToolStripMenuItem DataItem = new ToolStripMenuItem("Данные об оборудовании");
            DataItem.Click += DataItem_Click;
            fileItemData.DropDownItems.Add(DataItem);

            //Подпункт меню Проектные данные
            ToolStripMenuItem DataOffice = new ToolStripMenuItem("Данные о помещении");
            DataOffice.Click += DataOffice_Click;
            fileItemData.DropDownItems.Add(DataOffice);

            //Подпункт меню Проектные данные
            ToolStripMenuItem DataPoint = new ToolStripMenuItem("Данные о контрольных точках");
            DataPoint.Click += DataPoint_Click;
            fileItemData.DropDownItems.Add(DataPoint);
            menuStrip1.Items.Add(fileItemData);

            //Пункт меню Выполнить
            MakeProjectItem = new ToolStripMenuItem("Выполнить");
            MakeProjectItem.Enabled = false;
            ToolStripMenuItem AlgorithmParameters = new ToolStripMenuItem("Настройка параметров алгоритма");
            AlgorithmParameters.Click += AlgorithmParameters_Click;
            MakeProjectItem.DropDownItems.Add(AlgorithmParameters);

            ToolStripMenuItem StartAlgorithm = new ToolStripMenuItem("Запуск алгоритма размещения сетевого оборудования");
            StartAlgorithm.Click += StartAlgorithm_ClickAsync;
            MakeProjectItem.DropDownItems.Add(StartAlgorithm);

            ToolStripMenuItem CreateDoc = new ToolStripMenuItem("Подготовка проектной документации");
            CreateDoc.Click += CreateDoc_Click;
            MakeProjectItem.DropDownItems.Add(CreateDoc);
            menuStrip1.Items.Add(MakeProjectItem);

            //Пункт меню Справка
            ToolStripMenuItem Referens = new ToolStripMenuItem("Справка");
            ToolStripMenuItem Support = new ToolStripMenuItem("Помощь");
            Support.Click += Support_Clickl;
            Referens.DropDownItems.Add(Support);

            ToolStripMenuItem aboutProgram = new ToolStripMenuItem("О программе");
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

        //Метод отвечающий за кнопку отрыть оборудование
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

        //Метод отвечающий за открытие проекта 
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

        //Метод отвечающий за вывод информации об открытом проекте
        private Project? GetProjectName(string projectName)
        {
            using (var dbContext = new MyDbContext())
            {

                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                var pointList = new List<string>();

                listBox1.Items.Clear();

                //Вывод радиуса использованного оборудования с точками которыми он связан 
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
                            string listBoxItem = $"Точка: {bindPoint.PointId}, X: {pointInfo.Coordinate_X}, Y: {pointInfo.Coordinate_Y}, Радиус: {bindPoint.NetEquipments.Radius}";
                            listBox1.Items.Add(listBoxItem);
                        }

                    }
                }

                //Вывод количества точек доступа размещенных на плане
                var CountPoint = dbContext.CoordinatesAccessPoints.Count(p => p.ProjectId == currentProject.ID);
                if (CountPoint != 0)
                {
                    toolStripLabel9.Text = CountPoint.ToString();
                    fileItemData.Enabled = true;
                    OpenScheme.Enabled = true;
                    OpenSelectEquipment.Enabled = false;
                }

                //Вывод площади помещения проекта
                var CountArea = dbContext.PlanRooms.FirstOrDefault(p => p.ProjectId == currentProject.ID);
                if (CountArea != null)
                {
                    double width = CountArea.Width;
                    double height = CountArea.Height;
                    double Area = height * width;
                    toolStripLabel11.Text = $"{Area} м^2";
                    fileItemData.Enabled = true;
                    OpenScheme.Enabled = true;
                }
                return dbContext.Projects.FirstOrDefault(p => p.Name == projectName);

            }
        }

        //Метод отвечающий за создание проекта
        private void CreateProjeck_Click(object? sender, EventArgs e)
        {
            string newProjectName = Microsoft.VisualBasic.Interaction.InputBox("Введите название проекта:", "Создание проекта");

            databasePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"{newProjectName}.sqlite");
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlite($"Data Source={databasePath}")
                .Options;

            // Если название проекта пустое, возвращаем
            if (string.IsNullOrEmpty(newProjectName))
                return;

            // Проверка наличия проекта с таким же названием в базе данных
            var existingProject = MyDbContext.Projects.FirstOrDefault(p => p.Name == newProjectName);
            if (existingProject != null)
            {
                MessageBox.Show("Проект с таким названием уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MyDbContext.Projects.Add(project); // Добавление проекта в БД
            MyDbContext.SaveChanges(); 
            _currentProject = project; // Присвоение созданного проекта переменной _currentProject
        }

        //Метод отвечающий за создание проектной документации 
        private void CreateDoc_Click(object? sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Задаем путь и имя файла для сохранения
                SaveFileDialog saveDlg = new SaveFileDialog();
                string filename = "";

                saveDlg.Filter = "Text File (*.png)|*.png";
                saveDlg.DefaultExt = "*.png";
                saveDlg.FilterIndex = 1;
                saveDlg.Title = "Save the Project";

                DialogResult retval = saveDlg.ShowDialog();
                // Сохраняем изображение в файл
                if (retval == DialogResult.OK)
                    filename = saveDlg.FileName;
                else
                    return;

                RichTextBoxStreamType stream_type;
                if (saveDlg.FilterIndex == 2)
                    stream_type = RichTextBoxStreamType.PlainText;
                else
                    stream_type = RichTextBoxStreamType.RichText;

                MessageBox.Show("Файл сохранен");

            }
            else
            {
                // Обработка случая, когда в PictureBox нет изображения
                MessageBox.Show("No image to save.");
            }
        }

        //Метод который запускает алгоритм асинхронно 
        private async void StartAlgorithm_ClickAsync(object? sender, EventArgs e)
        {
            toolStripProgressBar2.Value = 0;
            // Отключаем некоторые возможности
            this.Invoke(new Action(() =>
            {
                StopGenAlgorithm.Enabled = true;
                UpdateEquipment.Enabled = false;
                RefreshPoint.Enabled = false;
                menuStrip1.Enabled = false;
            }));

            await Task.Run(() => SolvePlacement(userChoice));

            // Включаем весь функционал 
            this.Invoke(new Action(() =>
            {
                StopGenAlgorithm.Enabled = false;
                UpdateEquipment.Enabled = true;
                RefreshPoint.Enabled = true;
                menuStrip1.Enabled = true;
            }));
        }

        //Метод открывающий форму для ввода параметров алгоритма
        public void AlgorithmParameters_Click(object? sender, EventArgs e)
        {
            AlgorithmParameters AlgorithmParameters = new();
            AlgorithmParameters.Show();

        }

        //Функция вывода инф-ии о программе
        private void AboutProgram_Click(object? sender, EventArgs e)
        {
            DialogResult result = DialogResult = MessageBox.Show("Автоматизированная система размещения сетевого оборудования " +
                  "\n\nАвтор: Басыров Наиль Илдарович \nГруппа 4414 ",
                  "О программе", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //Функция вывода помощи
        private void Support_Clickl(object? sender, EventArgs e)
        {
            DialogResult result = DialogResult = MessageBox.Show("Для помощи обратитесь по почте: \nBasyrovNI@gmail.com ",
                 "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //Функция вывода данных о точках
        private void DataPoint_Click(object? sender, EventArgs e)
        {
            if (_currentProject == null && _currentProjectId == null)
            {
                DialogResult result = MessageBox.Show("Проект не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (listBox1.Items.Count == 0)
            {
                DialogResult result = MessageBox.Show("Точки не заданы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                DialogResult result = MessageBox.Show("Не удается определить ID проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Функция вывода данных о помещении 
        private void DataOffice_Click(object? sender, EventArgs e)
        {
            if (_currentProject == null && _currentProjectId == null)
            {
                DialogResult result = MessageBox.Show("Проект не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (string.IsNullOrWhiteSpace(toolStripLabel11.Text))
            {
                DialogResult result = MessageBox.Show("Параметры не заданы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                DialogResult result = MessageBox.Show("Не удается определить ID проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Функция вывода данных о выбранном оборудовании
        private void DataItem_Click(object? sender, EventArgs e)
        {

            InfoEquipments newForm = new InfoEquipments();
            newForm.Show();
        }

        //Реализация кнопки закрытия проекта
        private void Close_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {

            }
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Реализация кнопки сохранения проекта
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

            MessageBox.Show("Файл сохранен");


        }

        //Обработчик события: SavePoint_Click
        private void SavePoint_Click(object? sender, EventArgs e)
        {
            // Создание списка выбранных точек
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
            MessageBox.Show("Координаты точек сохранены в базе данных.");
        }

        //Добавление координат в БД
        private void AddCoordinatesToDatabase(List<System.Drawing.Point> points)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.BeginTransaction(); // Начало транзакции

                string projectName = toolStripLabel3.Text;

                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                if (currentProject == null)
                {
                    MessageBox.Show("Проект не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                dbContext.Database.CommitTransaction(); // Фиксация транзакци
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

        //Метод отвечающий за кнопку "обновить точки"
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

        //Метод отвечающий за выбранный тип размещения
        private void OpenSelectType(object? sender, EventArgs e)
        {
            SelectEquipmentType selectEquipmentType = new SelectEquipmentType(this);
            selectEquipmentType.OnUserMadeChoice += SelectEquipmentType_OnUserMadeChoice;
            selectEquipmentType.Show();
        }

        private void SelectEquipmentType_OnUserMadeChoice(OptionType selectedOption)
        {
            // Устанавливаем выбор пользователя
            userChoice = selectedOption;
        }

        //Метод отвачающий за открытие плана помещения
        public void OpenScheme_Click(object? sender, EventArgs e, OptionType selectedOption)
        {
            if (isImageOpened)
            {
                DialogResult result = MessageBox.Show("Текущее изображение будет закрыто! Продолжить?", "Предупреждение",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK) // ОК
                {
                    CloseImage();
                    pictureBox1.Invalidate();
                    listBox1.Items.Clear();

                    // Здесь добавляем код для открытия формы GetPoints
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

        //Метод отвечающий за контроль открытого изображения на форме
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

            isImageOpened = true; // Установка флага, что изображение открыто
        }

        //Для закрытия текущего изображения
        private void CloseImage()
        {
            if (isImageOpened)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                originalImage.Dispose();
                originalImage = null;
                isImageOpened = false; // Сброс флага

                // Сброс значений, используемых для отрисовки
                pictureBox1.Invalidate();
                accessPoints = null;
            }

        }

        //Метод отвечащий за отрисовку на pictureBox
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (pictureBox1.Image == null)
                return;

            if (bestSolution == null || accessPoints == null) // проверка для отрисовки
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

            Font font = new Font("Arial", 10); // Шрифт для номеров
            Brush textBrush = Brushes.White; // Цвет текста

            // Масштабирование координат точек на изображении
            double scaleX = (double)pictureBox1.Width / roomWidth;
            double scaleY = (double)pictureBox1.Height / roomHeight;
            double scaleCoefficient = 1.04; // Коэффициент масштабирования

            // Перебираем все гены в лучшей хромосоме
            if (bestSolution != null && accessPoints != null)
            {
                for (int i = 0; i < bestSolution.Genes.Length; i++)
                {
                    // Если ген равен 1, значит данная точка использовалась в хромосоме и её нужно отрисовать
                    if (bestSolution.Genes[i] == 1)
                    {
                        int coordinateX = accessPoints[i, 0]; // в единицах размеров помещения
                        int coordinateY = accessPoints[i, 1]; // в единицах размеров помещения

                        // Вычисление радиуса
                        int radius = accessPoints[i, 2]; // в единицах размеров помещения

                        // Вычисление координат круга в пикселях на изображении
                        int x = (int)(coordinateX * scaleX);
                        int y = (int)(coordinateY * scaleY);
                        int r = (int)(radius * (scaleX + scaleY) / 2 * scaleCoefficient);

                        // Выбор цвета круга
                        Color color = colors[i % colors.Length];
                        Brush brush = new SolidBrush(color);

                        // Отрисовка круга
                        g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r);

                        // Отрисовка номера точки
                        string pointNumber = (i + 1).ToString();
                        SizeF textSize = g.MeasureString(pointNumber, font);
                        g.DrawString(pointNumber, font, Brushes.Black, x - textSize.Width / 2, y - textSize.Height / 2);
                    }
                }
            }
        }

        //Класс для представления расстояния между двумя точками
        public class PointDistance
        {
            public System.Drawing.Point Point1 { get; }  // Первая точка
            public System.Drawing.Point Point2 { get; }  // Вторая точка
            public double Distance { get; }  // Расстояние между точками

            public PointDistance(System.Drawing.Point point1, System.Drawing.Point point2, double distance)
            {
                Point1 = point1;
                Point2 = point2;
                Distance = distance;
            }
        }

        //Добавление параметров помещения в БД
        private void InputParameters_Click(object? sender, EventArgs e)
        {
            string projectName = toolStripLabel3.Text;

            InputParameters newForm = new InputParameters();

            var project = MyDbContext.Projects.FirstOrDefault(p => p.Name == projectName);
            if (project == null)
            {
                MessageBox.Show("Проект не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    toolStripLabel11.Text = $"{Area} м^2";
                }
            };

            newForm.Show();
            OpenScheme.Enabled = true;
        }

        //Метод отвечающий за обрезку изображения по контуру
        private void CropImageByContour()
        {
            if (originalImage == null)
                return;

            // Выполнение обнаружения контура помещения
            List<PointF> contour = DetectFloorPlanContour();

            if (contour == null)
            {
                MessageBox.Show("Floor plan contour not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Определение ограничивающего прямоугольника вокруг контура
            RectangleF boundingBox = GetBoundingBox(contour);

            // Создание нового изображения для обрезки
            Bitmap croppedImage = new Bitmap((int)boundingBox.Width, (int)boundingBox.Height);

            // Использование Graphics для рисования контура на новом изображении
            using (Graphics graphics = Graphics.FromImage(croppedImage))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.FillPolygon(Brushes.Black, contour.ToArray());
            }

            // Копирование только пикселей внутри контура из оригинального изображения в обрезанное изображение
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

        //Получаем ограничивающий контур плямоугольник
        private RectangleF GetBoundingBox(List<PointF> contour)
        {
            float padding = -2f; // Значение отступа
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

            // Преобразование изображения в формат Grayscale
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayscaleImage = grayscaleFilter.Apply(originalImage);

            // Применение фильтра Canny Edge Detector
            CannyEdgeDetector edgeDetector = new CannyEdgeDetector();
            Bitmap edgesImage = edgeDetector.Apply(grayscaleImage);

            // Использование фильтра SimpleShapeChecker для поиска контура помещения
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            shapeChecker.MinAcceptableDistortion = 0.5f;
            shapeChecker.RelativeDistortionLimit = 0.03f;

            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(edgesImage);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // Поиск наибольшего контура помещения
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
                // Преобразование точек контура в PointF
                List<PointF> contourPoints = new List<PointF>();
                foreach (IntPoint point in floorPlanContour)
                {
                    contourPoints.Add(new PointF(point.X, point.Y));
                }

                // Освобождение ресурсов
                edgesImage.Dispose();
                grayscaleImage.Dispose();

                return contourPoints;
            }
            else
            {
                // Освобождение ресурсов
                edgesImage.Dispose();
                grayscaleImage.Dispose();

                return null;
            }
        }

        //Считаем многоугольную область
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

                // Освобождение ресурсов
                brushPath.Dispose();

                return area;
            }

        }


        //Генетический алгоритм 
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

        //Метод отвечащающий за реализацию алгоритма
        private void SolvePlacement(OptionType userChoice)
        {
            bool isManualPlacement = false; // Флаг, указывающий, производится ли ручное размещение
            bool isRepeatedAutomaticPlacement = false; // Флаг, указывающий, повторяется ли автоматическое размещение

            // Проверяем, заданы ли параметры алгоритма
            if (mutationRate == null || crossoverRate == null || numberGeneration == null || K == null)
            {
                MessageBox.Show("Сначала заполните параметры алгоритма!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AlgorithmParameters algorithmParameters = new AlgorithmParameters();
                algorithmParameters.ShowDialog();
                return;
            }

            int index = 0;

            // Работаем с базой данных
            using (var dbContext = new MyDbContext())
            {
                string projectName = toolStripLabel3.Text;
                // Получаем текущий проект
                var currentProject = dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
                if (currentProject == null)
                {
                    MessageBox.Show("Проект не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем комнату проекта
                var room = dbContext.PlanRooms.FirstOrDefault(r => r.ProjectId == currentProject.ID);
                if (room != null)
                {
                    roomWidth = room.Width;
                    roomHeight = room.Height;
                }

                // Получаем точки доступа и их радиусы
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

                // Установка размера популяции
                populationSize = points.Length > 0 ? points.Length : CalculatePopulationSize(roomWidth, roomHeight, coverageRadius);

                // Проверяем, если есть точки доступа, то размещение ручное
                if (userChoice == OptionType.Option2)
                {
                    isManualPlacement = true;

                }
                else if (userChoice == OptionType.Option1) // Автоматическое размещение
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
                else if (isRepeatedAutomaticPlacement) // Проверяем условия для повторного автоматического размещения
                {
                    // Удаление существующих точек доступа из базы данных
                    var existingPoints = dbContext.CoordinatesAccessPoints.Where(p => p.ProjectId == currentProject.ID);
                    dbContext.CoordinatesAccessPoints.RemoveRange(existingPoints);
                    dbContext.SaveChanges();

                    // Повторное автоматическое размещение
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

                // Преобразование списка точек в двумерный массив
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

            // Параллельный расчет значений пригодности для хромосом популяции
            ConcurrentBag<double> fitnessResults = new ConcurrentBag<double>();

            System.Threading.Tasks.Parallel.For(0, populationSize, i =>
            {
                double fitness = CalculateFitness(population[i]);
                fitnessResults.Add(fitness);
            });

            // Сохранение лучшего результата пригодности
            lastBestFitness[0] = CalculateFitness(population[0]);

            // Инициализация переменных для цикла алгоритма
            int maxGenerations = (int)numberGeneration;
            int currentGeneration = 0;

            this.Invoke(new Action(() =>
            {
                toolStripProgressBar2.Maximum = maxGenerations;
                toolStripProgressBar2.Value = 0;
            }));

            // Цикл генетического алгоритма
            while (currentGeneration < maxGenerations && !stopAlgorithm)
            {
                Crossover();
                Mutate();

                // Сортировка популяции по убыванию пригодности
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

                // Обновление прогресса выполнения
                this.Invoke(new Action(() => { toolStripProgressBar2.Value = currentGeneration; }));

                currentGeneration++;
            }

            // Проверка, если алгоритм был остановлен пользователем
            if (stopAlgorithm)
            {
                DialogResult result = DialogResult = MessageBox.Show("Алгоритм прерван",
                  "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            this.Invoke(new Action(() =>
            {
                // Обновление интерфейса после выполнения алгоритма
                toolStripProgressBar2.Value = toolStripProgressBar2.Maximum;

                int countOnes = population[0].Genes.Count(g => g == 1);
                DialogResult resul = DialogResult = MessageBox.Show($"\nКоличество используемого оборудования: {countOnes}, " +
                  $"\nЗначение функции пригодности: {CalculateFitness(population[0]).ToString("F2")}",
                  "Резулаты", MessageBoxButtons.OK, MessageBoxIcon.Question);
                string formattedFitness = CalculateFitness(population[0]).ToString("F2");
                toolStripLabel7.Text = formattedFitness + " м^2";
                bestSolution = population[0];
                pictureBox1.Invalidate();
                StopGenAlgorithm.Enabled = false;

                // Дополнительные проверки и сообщения для ручного размещения
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
                    DialogResult result = DialogResult = MessageBox.Show($"Для полного покрытия помещения потребуется ещё минимум:" +
                        $"\n{additionalAPsNeeded} дополнительных точек доступа.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }

                // Вывод координат точек доступа в листбокс 
                listBox1.Items.Clear();
                for (int i = 0; i < accessPoints.GetLength(0); i++)
                {
                    if (population[0].Genes[i] == 1)
                    {
                        int coordinateX = accessPoints[i, 0];
                        int coordinateY = accessPoints[i, 1];
                        int Radius = accessPoints[i, 2];
                        listBox1.Items.Add($"Точка {i + 1}: X = {coordinateX}, Y = {coordinateY}, Радиус: {Radius} ");
                        toolStripLabel9.Text = countOnes.ToString();
                    }
                }

            }));
        }

        //Метод для автоматического размещения, определяющий размер популяции
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

        //Метод для ручного размещения, расчитыающий сколько потребуется ещё точек доступа
        private int CalculateAdditionalAccessPointsNeeded(List<AccessPoint> currentAccessPoints, double coverageRadius, double roomWidth, double roomHeight)
        {
            double effectiveCoveredArea = 0;
            double overlappingArea = 0;

            // Рассчет площади, покрытой текущими точками доступа
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

            // Рассчет, сколько дополнительных точек доступа необходимо
            double singleAPCoverageArea = Math.PI * Math.Pow(coverageRadius, 2);
            return (int)Math.Ceiling(remainingArea / singleAPCoverageArea);
        }

        public class Chromosome
        {
            public int[] Genes { get; set; }
        }

        //Метод отвечающий за мутацию
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

        //Метод отвечающий за выбор пар родителей
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

        //Метод отвечающий за скрещивание
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

        //Расчет целевой функции
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

        //Расчет поктырой площади
        static double CalculateCoverageArea(int centerX, int centerY, double radius, double roomWidth, double roomHeight)
        {
            double r2 = radius * radius;

            // Вычисляем пересечение круга с границами комнаты
            double x1 = Math.Max(centerX - radius, 0);
            double x2 = Math.Min(centerX + radius, roomWidth);
            double y1 = Math.Max(centerY - radius, 0);
            double y2 = Math.Min(centerY + radius, roomHeight);

            int steps = 1000; // значение точности вычисления
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
        
        //Расчет площади перекрытия
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
        
        //Расчет дистанции между точками
        static double Distance(int[] point1, int[] point2)
        {
            int xDiff = point1[0] - point2[0];
            int yDiff = point1[1] - point2[1];
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        //Список точек для автоматичкого размещения
        private List<AccessPoint> AutomaticPlacement(int populationSize, double coverageRadius, double roomWidth, double roomHeight)
        {
            List<AccessPoint> accessPoints = new List<AccessPoint>();

            double step = coverageRadius * Math.Sqrt(2); // Шаг расположения точек, чтобы минимизировать перекрытие

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

        // Метод отвечающий за кнопку обновить оборудование
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

        // Метод отвечающий за остановку алгоритма
        private void StopGenAlgorithm_Click(object sender, EventArgs e)
        {
            stopAlgorithm = true;
        }
    }

}