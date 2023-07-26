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
    public partial class SelectEquipmentType : Form
    {

        public delegate void UserChoiceDelegate(OptionType choice);
        public event UserChoiceDelegate OnUserMadeChoice;
        public OptionType SelectedOption { get; private set; } // Объявление переменной SelectedOption
        private Main main;
        public SelectEquipmentType(Main main)
        {
            InitializeComponent();
            this.main = main;
            SelectedOption = OptionType.None; // Устанавливаем начальное значение SelectedOption
            checkBox1.CheckedChanged += СheckBox1_CheckedChanged; // Добавление обработчиков событий
            checkBox2.CheckedChanged += СheckBox2_CheckedChanged;
        }

        private void СheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SelectedOption = OptionType.Option1; // Устанавливаем значение SelectedOption для Option1
                checkBox2.Checked = false;
            }
        }

        private void СheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                SelectedOption = OptionType.Option2; // Устанавливаем значение SelectedOption для Option2
                checkBox1.Checked = false;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

            if (SelectedOption == OptionType.None) // Проверяем значение SelectedOption
            {
                // Если ни один из checkbox-ов не выбран
                DialogResult result = MessageBox.Show("Выберите вариант размещения!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прекратить выполнение метода
            }

            // Вызываем событие, информируя основной класс о выборе пользователя
            OnUserMadeChoice?.Invoke(SelectedOption);
            // Передаем информацию о выбранном варианте в OpenScheme_Click
            this.Close();
            main.OpenScheme_Click(sender, e, SelectedOption);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum OptionType
    {
        None, // Значение по умолчанию
        Option1,
        Option2
    }
}
