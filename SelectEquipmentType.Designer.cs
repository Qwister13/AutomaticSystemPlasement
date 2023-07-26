namespace Interface2
{
    partial class SelectEquipmentType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectEquipmentType));
            panel1 = new Panel();
            ExitButton = new Button();
            ApplyButton = new Button();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ExitButton);
            panel1.Controls.Add(ApplyButton);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(279, 199);
            panel1.TabIndex = 0;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(144, 154);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(91, 33);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // ApplyButton
            // 
            ApplyButton.Location = new Point(33, 154);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(91, 33);
            ApplyButton.TabIndex = 2;
            ApplyButton.Text = "Применить";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(42, 100);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(142, 34);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Ручное размещение \r\nточек доступа";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += СheckBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(42, 51);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(193, 34);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Автоматическое размещение \r\nточек доступа";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += СheckBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 39);
            label1.TabIndex = 4;
            label1.Text = "Выберите вариант размещения:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectEquipmentType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 199);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(295, 238);
            MinimumSize = new Size(295, 238);
            Name = "SelectEquipmentType";
            Text = "Выбор типа размещения ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button ExitButton;
        private Button ApplyButton;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label1;
    }
}