namespace Interface2
{
    partial class InputParameters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputParameters));
            panel1 = new Panel();
            label6 = new Label();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 192);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(231, 105);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 10;
            label6.Text = "Кв метров";
            // 
            // button2
            // 
            button2.Location = new Point(153, 143);
            button2.Name = "button2";
            button2.Size = new Size(135, 38);
            button2.TabIndex = 9;
            button2.Text = "Сохранить значение площади";
            button2.UseVisualStyleBackColor = true;
            button2.MouseClick += button2_MouseClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 143);
            button1.Name = "button1";
            button1.Size = new Size(135, 38);
            button1.TabIndex = 8;
            button1.Text = "Посчитать площадь";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button1_MouseClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(210, 24);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 7;
            label5.Text = "Метров";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(210, 63);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 6;
            label4.Text = "Метров";
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(146, 97);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(79, 23);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(141, 55);
            textBox2.MaxLength = 4;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(63, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Location = new Point(141, 16);
            textBox1.MaxLength = 4;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(63, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 100);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 2;
            label3.Text = "Площадь помещения";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 58);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "Длина помещения";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Ширина помещения";
            // 
            // InputParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 192);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(316, 231);
            MinimumSize = new Size(316, 231);
            Name = "InputParameters";
            Text = "Ввод параметров";
            Load += InputParameters_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}