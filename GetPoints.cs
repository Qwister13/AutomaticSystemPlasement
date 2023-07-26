using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Drawing.Drawing2D;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Blob = AForge.Imaging.Blob;

namespace Interface2
{
    public partial class GetPoints : Form
    {
        public delegate void PointsEventHandler(List<System.Drawing.Point> points);
        public event PointsEventHandler PointsTransferred;
        private readonly Project _currentProject;
        private MyDbContext MyDbContext;
        private Bitmap originalImage;
        public event Action<Bitmap> ImageOpened;
        List<System.Drawing.Point> myPoints = new List<System.Drawing.Point>();
        List<System.Drawing.Point> selectedPoints = new List<System.Drawing.Point>();
        private static double WidthRoom;
        private static double HeightRoom;
        private OptionType selectedOption;
        private Main main; // Ссылка на главную форму

        public GetPoints(Main main, OptionType selectedOption)
        {
            InitializeComponent();
            this.selectedOption = selectedOption;

            ToolStripMenuItem OpenNewFile = new ToolStripMenuItem("Открыть новый файл");
            OpenNewFile.Click += OpenFile;
            menuStrip1.Items.Add(OpenNewFile);

            ToolStripMenuItem SaveNewFile = new ToolStripMenuItem("Сохранить файл");
            SaveNewFile.Click += SaveFile;
            menuStrip1.Items.Add(SaveNewFile);
            DoubleBuffered = true;
            this.main = main;

            if (selectedOption == OptionType.Option1)
            {
                SavePointsDataBase.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                PlanApproveClick.Enabled = true;
                SaveNewFile.Enabled = false;
                pictureBox1.Click -= pictureBox1_Click;
                
            }
            else
            {
                SavePointsDataBase.Enabled = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                PlanApproveClick.Enabled = false;
                SaveNewFile.Enabled = true;
            }
            
        }

        private void SaveFile(object? sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Нет сохранненых точек.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            saveDlg.Filter = "Формат схемы (*.jpg)|*.jpg|Формат схемы (*.png)|*.png";
            saveDlg.DefaultExt = "*.png";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                foreach (var point in myPoints)
                {
                    g.FillEllipse(Brushes.Blue, new Rectangle(point, new Size(7, 7)));
                }
            }

            try
            {
                pictureBox1.Image.Save(filename);
                MessageBox.Show("Файл сохранен");

            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл");
            }
        }

        private void OpenFile(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                Filter = "План помещения |*.jpg;*.jpeg;*.png;*.bmp",
                DefaultExt = "*.jpg |*.jpg ",
                FilterIndex = 1,
                Title = "Открытие файла плана помещения"
            };


            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = originalImage;
                    this.pictureBox1.Size = originalImage.Size;
                    pictureBox1.Image = originalImage;
                    pictureBox1.Invalidate();
                    DialogResult result = DialogResult = MessageBox.Show("Файл открыт",
                    "Открыт", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    CropImageByContour();
                    if (pictureBox1.Image != null)
                    {
                        ImageOpened?.Invoke(originalImage);
                    }
                }
                catch (Exception ex)
                {
                    DialogResult result = DialogResult = MessageBox.Show("Файл поврежден \nВыберите другой файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }
            }
            else
            {
                Close();
            }


        }

        private void GetPoints_Load(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "План помещения |*.jpg;*.jpeg;*.png;*.bmp",
                DefaultExt = "*.jpg |*.jpg ",
                FilterIndex = 1,
                Title = "Открытие файла плана помещения"
            };

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = originalImage;
                    pictureBox1.Invalidate();
                    DialogResult result = DialogResult = MessageBox.Show("Файл открыт",
                    "Открыт", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    CropImageByContour();

                    if (pictureBox1.Image != null)
                    {
                        ImageOpened?.Invoke(originalImage);
                    }
                }
                catch
                {
                    DialogResult result = DialogResult = MessageBox.Show("Файл поврежден \nВыберите другой файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

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

        private static double CalculatePolygonArea(List<IntPoint> polygon)
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

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            System.Drawing.Point relativePoint = pictureBox1.PointToClient(MousePosition);
            System.Drawing.Point point = new System.Drawing.Point((int)(relativePoint.X * (originalImage.Width / (double)pictureBox1.Width)), (int)(relativePoint.Y * (originalImage.Height / (double)pictureBox1.Height)));

            if (myPoints.Any(p => p.X == point.X && p.Y == point.Y))
            {
                // Точка уже существует, не добавляем ее
                return;
            }

            myPoints.Add(point);
            double roomWidth = WidthRoom;
            double roomHeight = HeightRoom;
            System.Drawing.Point pointInRoom = new System.Drawing.Point((int)(point.X * (roomWidth / originalImage.Width)), (int)(point.Y * (roomHeight / originalImage.Height)));

            listBox1.Items.Add("X:" + pointInRoom.X + " Y: " + pointInRoom.Y);
            (sender as Control).Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            double roomWidth = WidthRoom;
            double roomHeight = HeightRoom;
            int x = (int)(e.X * (roomWidth / pictureBox1.Width));
            int y = (int)(e.Y * (roomHeight / pictureBox1.Height));

            if (listBox1.Items.Contains($"X: {x} Y: {y}"))
            {
                listBox1.Items.Remove($"X: {x} Y: {y}");
                myPoints.RemoveAll(p => p.X == x && p.Y == y);
            }
            else
            {
                listBox1.Items.Add($"X: {x} Y: {y}");
                myPoints.Add(new System.Drawing.Point(x, y));
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.SetClip(new Rectangle(0, 0, originalImage.Width, originalImage.Height));

            foreach (var point in myPoints)
            {
                // переводим координаты точек изображения в координаты pictureBox
                int x = (int)(point.X * (float)pictureBox1.Width / originalImage.Width);
                int y = (int)(point.Y * (float)pictureBox1.Height / originalImage.Height);

                if (selectedPoints.Contains(point))
                    g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(x, y, 6, 6));
                else
                    g.FillEllipse(new SolidBrush(Color.Blue), new Rectangle(x, y, 5, 5));
            }
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            myPoints.Clear();
            listBox1.Items.Clear();
            pictureBox1.Invalidate();
        }

        private void DeleteSelect_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                System.Drawing.Point selectedPoint = myPoints[listBox1.SelectedIndex];
                myPoints.RemoveAll(point => point.X == selectedPoint.X && point.Y == selectedPoint.Y);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                selectedPoints.Clear();
                pictureBox1.Invalidate();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPoints.Clear();
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex < myPoints.Count)
            {
                selectedPoints.Add(myPoints[listBox1.SelectedIndex]);
                pictureBox1.Invalidate();
            }
        }

        //Заполнение списка точек, которые будет использованы в методе GetPointsFromForm()
        private List<System.Drawing.Point> GetPointsFromForm()
        {
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();

            // Получение точек из списка listBox1
            foreach (var item in listBox1.Items)
            {
                string[] coordinates = item.ToString().Split(' ');
                int X = int.Parse(coordinates[0].Substring(2)); // Извлекаем значение X из строки
                int Y = int.Parse(coordinates[2]); // Извлекаем значение Y из строки

                System.Drawing.Point point = new System.Drawing.Point(X, Y);
                points.Add(point);
            }

            return points;
        }

        //Метод сохранение точек доступа и их передача в другую форму
        private void SavePoints_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) // Проверяем количество элементов в ListBox
            {
                DialogResult result = MessageBox.Show("Сначала укажите точки!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var points = GetPointsFromForm();
            PointsTransferred?.Invoke(GetPointsFromForm());
            this.Close();
        }

        public static void SetRoomDimensions(double width, double height)
        {
            WidthRoom = width;
            HeightRoom = height;
        }

        public void PlanApproveClick_Click(object sender = null, EventArgs e = null)
        {
            this.Close();
            EquipmentAuto equipmentAuto = new EquipmentAuto(this);
            equipmentAuto.Show();
        }

        public void UpdateValueInMainForm(object value)
        {
            main.UpdateValue(value);
        }
    }
}
