namespace Interface2
{
    public class PointStorage
    {
        private List<Point> points = new List<Point>();

        public List<Point> Points { get; set; }

        public PointStorage()
        {
            Points = new List<Point>();
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void RemovePoint(Point point)
        {
            points.Remove(point);
        }

        public List<Point> GetPoints()
        {
            return points;
        }

        public void Clear()
        {
            points.Clear();
        }

        public void SaveToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var point in points)
                {
                    writer.WriteLine($"{point.X},{point.Y}");
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File '{fileName}' not found.");
            }

            points.Clear();
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length != 2)
                    {
                        throw new InvalidOperationException($"Invalid line format: {line}");
                    }

                    if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                    {
                        throw new InvalidOperationException($"Invalid line format: {line}");
                    }

                    points.Add(new Point(x, y));
                }
            }
        }
    }
}