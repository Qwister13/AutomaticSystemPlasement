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
    public partial class AlgorithmParameters : Form
    {

        string Iteration;
        string Mutation;
        string Selection;
        string k;
        public double CrossoverRate { get; private set; }
        public double MutationRate { get; private set; }
        public int NumberGeneration { get; private set; }
        public int K { get; private set; }

        public AlgorithmParameters()
        {

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                return;
            Iteration = textBox1.Text;

            int parsedValue;

            if (int.TryParse(Iteration, out parsedValue))
            {
                NumberGeneration = parsedValue;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
                return;
            Mutation = textBox2.Text;

            double parsedValue;

            if (double.TryParse(Mutation, out parsedValue))
            {
                MutationRate = parsedValue;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
                return;
            Selection = textBox3.Text;

            double parsedValue;

            if (double.TryParse(Selection, out parsedValue))
            {
                CrossoverRate = parsedValue;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
                return;
            k = textBox4.Text;

            int parsedValue;

            if (int.TryParse(k, out parsedValue))
            {
                K = parsedValue;
            }
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            double mutation;
            double crossover;
            int generations;
            int k;

            if (double.TryParse(textBox2.Text, out mutation) &&
                double.TryParse(textBox3.Text, out crossover) &&
                int.TryParse(textBox1.Text, out generations) &&
                int.TryParse(textBox4.Text, out k))
            {
                Main.mutationRate = mutation;
                Main.crossoverRate = crossover;
                Main.numberGeneration = generations;
                Main.K = k;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult = MessageBox.Show("1)Введите количество поколений" +
                "\n2)Введите желаемый процент мутации для особей" +
                "\n3)Введите желаемый процент скрещивания для особей" +
                "\n4)Сохраните параметры ",
                    "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Close();
        }

    }
}
