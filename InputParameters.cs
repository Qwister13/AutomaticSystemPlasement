using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface2
{
    public partial class InputParameters : Form
    {
        public delegate void RoomDimensionsEventHandler(double width, double height);
        public event RoomDimensionsEventHandler RoomDimensionsEntered;

        private MyDbContext MyDbContext;

        string s;
        public double Width;
        public double Height;
        public double sum;
        public double Sum { get; set; }

        public InputParameters()
        {
            InitializeComponent();
            MyDbContext = new MyDbContext();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                return;
            s = textBox1.Text;
            Width = Convert.ToDouble(s);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
                return;
            s = textBox2.Text;
            Height = Convert.ToDouble(s);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double value1) && double.TryParse(textBox2.Text, out double value2))
            {
                // Умножаем значения и выводим результат в текстовое поле
                sum = value1 * value2;
                textBox3.Text = sum.ToString();
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                DialogResult result = DialogResult = MessageBox.Show("Отсутсвует значение",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                Width = double.Parse(textBox1.Text);
                Height = double.Parse(textBox2.Text);
                RoomDimensionsEntered?.Invoke(Width, Height);
                sum = Width * Height;
                this.Close();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Закройте контекст базы данных при закрытии формы
            MyDbContext.Dispose();
        }

        private void InputParameters_Load(object sender, EventArgs e)
        {

        }
    }
}
