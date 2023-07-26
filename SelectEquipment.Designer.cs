namespace Interface2
{
    partial class SelectEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectEquipment));
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            codeeloButton1 = new CodeeloUI.Controls.CodeeloButton();
            listBox1 = new ListBox();
            codeeloButton2 = new CodeeloUI.Controls.CodeeloButton();
            codeeloButton4 = new CodeeloUI.Controls.CodeeloButton();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            listBox3 = new ListBox();
            label1 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            listBox2 = new ListBox();
            label2 = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            label3 = new Label();
            listBox4 = new ListBox();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.92507F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0749245F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(964, 601);
            tableLayoutPanel2.TabIndex = 1;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(codeeloButton1, 0, 3);
            tableLayoutPanel3.Controls.Add(listBox1, 0, 0);
            tableLayoutPanel3.Controls.Add(codeeloButton2, 0, 2);
            tableLayoutPanel3.Controls.Add(codeeloButton4, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel3.Size = new Size(716, 595);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // codeeloButton1
            // 
            codeeloButton1.AccessibleRole = null;
            codeeloButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            codeeloButton1.BackColor = Color.Transparent;
            codeeloButton1.BorderColor_1 = Color.Transparent;
            codeeloButton1.BorderColor_2 = Color.Transparent;
            codeeloButton1.BorderRadius = 15;
            codeeloButton1.BorderSize = 3;
            codeeloButton1.CausesValidation = false;
            codeeloButton1.ColorFill_1 = Color.FromArgb(139, 144, 176);
            codeeloButton1.ColorFill_2 = Color.FromArgb(159, 185, 189);
            codeeloButton1.DialogResult = false;
            codeeloButton1.Dock = DockStyle.Fill;
            codeeloButton1.FlatAppearance.BorderSize = 0;
            codeeloButton1.FlatStyle = FlatStyle.Flat;
            codeeloButton1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            codeeloButton1.ForeColor = Color.WhiteSmoke;
            codeeloButton1.GradientBorderDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton1.Location = new Point(4, 549);
            codeeloButton1.Name = "codeeloButton1";
            codeeloButton1.OnClick_BorderColor_1 = Color.Transparent;
            codeeloButton1.OnClick_BorderColor_2 = Color.Transparent;
            codeeloButton1.OnClick_FillColor_1 = Color.FromArgb(179, 184, 216);
            codeeloButton1.OnClick_FillColor_2 = Color.FromArgb(199, 225, 229);
            codeeloButton1.OnOver_BorderColor_1 = Color.Transparent;
            codeeloButton1.OnOver_BorderColor_2 = Color.Transparent;
            codeeloButton1.OnOver_FillColor_1 = Color.FromArgb(159, 164, 196);
            codeeloButton1.OnOver_FillColor_2 = Color.FromArgb(179, 205, 209);
            codeeloButton1.Size = new Size(708, 42);
            codeeloButton1.TabIndex = 7;
            codeeloButton1.TabStop = false;
            codeeloButton1.Text = "Сохранить связи";
            codeeloButton1.TextAlign = CodeeloUI.Enums.TextPosition.Center;
            codeeloButton1.UseMnemonic = false;
            codeeloButton1.UseVisualStyleBackColor = false;
            codeeloButton1.Click += SaveBind_Clik;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Control;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(4, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(708, 442);
            listBox1.TabIndex = 2;
            // 
            // codeeloButton2
            // 
            codeeloButton2.AccessibleRole = null;
            codeeloButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            codeeloButton2.BackColor = Color.Transparent;
            codeeloButton2.BorderColor_1 = Color.Transparent;
            codeeloButton2.BorderColor_2 = Color.Transparent;
            codeeloButton2.BorderRadius = 20;
            codeeloButton2.BorderSize = 3;
            codeeloButton2.CausesValidation = false;
            codeeloButton2.ColorFill_1 = Color.FromArgb(139, 144, 176);
            codeeloButton2.ColorFill_2 = Color.FromArgb(159, 185, 189);
            codeeloButton2.DialogResult = false;
            codeeloButton2.Dock = DockStyle.Fill;
            codeeloButton2.FlatAppearance.BorderSize = 0;
            codeeloButton2.FlatStyle = FlatStyle.Flat;
            codeeloButton2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            codeeloButton2.ForeColor = Color.WhiteSmoke;
            codeeloButton2.GradientBorderDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton2.Location = new Point(4, 501);
            codeeloButton2.Name = "codeeloButton2";
            codeeloButton2.OnClick_BorderColor_1 = Color.Transparent;
            codeeloButton2.OnClick_BorderColor_2 = Color.Transparent;
            codeeloButton2.OnClick_FillColor_1 = Color.FromArgb(179, 184, 216);
            codeeloButton2.OnClick_FillColor_2 = Color.FromArgb(199, 225, 229);
            codeeloButton2.OnOver_BorderColor_1 = Color.Transparent;
            codeeloButton2.OnOver_BorderColor_2 = Color.Transparent;
            codeeloButton2.OnOver_FillColor_1 = Color.FromArgb(159, 164, 196);
            codeeloButton2.OnOver_FillColor_2 = Color.FromArgb(179, 205, 209);
            codeeloButton2.Size = new Size(708, 41);
            codeeloButton2.TabIndex = 8;
            codeeloButton2.TabStop = false;
            codeeloButton2.Text = "Удалить связь";
            codeeloButton2.TextAlign = CodeeloUI.Enums.TextPosition.Center;
            codeeloButton2.UseMnemonic = false;
            codeeloButton2.UseVisualStyleBackColor = false;
            codeeloButton2.Click += DeleteBind_Click;
            // 
            // codeeloButton4
            // 
            codeeloButton4.AccessibleRole = null;
            codeeloButton4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            codeeloButton4.BackColor = Color.Transparent;
            codeeloButton4.BorderColor_1 = Color.Transparent;
            codeeloButton4.BorderColor_2 = Color.Transparent;
            codeeloButton4.BorderRadius = 15;
            codeeloButton4.BorderSize = 3;
            codeeloButton4.CausesValidation = false;
            codeeloButton4.ColorFill_1 = Color.FromArgb(139, 144, 176);
            codeeloButton4.ColorFill_2 = Color.FromArgb(159, 185, 189);
            codeeloButton4.DialogResult = false;
            codeeloButton4.Dock = DockStyle.Fill;
            codeeloButton4.FlatAppearance.BorderSize = 0;
            codeeloButton4.FlatStyle = FlatStyle.Flat;
            codeeloButton4.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            codeeloButton4.ForeColor = Color.WhiteSmoke;
            codeeloButton4.GradientBorderDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton4.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton4.Location = new Point(4, 453);
            codeeloButton4.Name = "codeeloButton4";
            codeeloButton4.OnClick_BorderColor_1 = Color.Transparent;
            codeeloButton4.OnClick_BorderColor_2 = Color.Transparent;
            codeeloButton4.OnClick_FillColor_1 = Color.FromArgb(179, 184, 216);
            codeeloButton4.OnClick_FillColor_2 = Color.FromArgb(199, 225, 229);
            codeeloButton4.OnOver_BorderColor_1 = Color.Transparent;
            codeeloButton4.OnOver_BorderColor_2 = Color.Transparent;
            codeeloButton4.OnOver_FillColor_1 = Color.FromArgb(159, 164, 196);
            codeeloButton4.OnOver_FillColor_2 = Color.FromArgb(179, 205, 209);
            codeeloButton4.Size = new Size(708, 41);
            codeeloButton4.TabIndex = 10;
            codeeloButton4.TabStop = false;
            codeeloButton4.Text = "Связать оборудование с точкой";
            codeeloButton4.TextAlign = CodeeloUI.Enums.TextPosition.Center;
            codeeloButton4.UseMnemonic = false;
            codeeloButton4.UseVisualStyleBackColor = false;
            codeeloButton4.Click += SelectBind_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(725, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.Size = new Size(236, 595);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(listBox3, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(4, 201);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.Size = new Size(228, 191);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // listBox3
            // 
            listBox3.BackColor = SystemColors.Control;
            listBox3.Dock = DockStyle.Fill;
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(3, 31);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(222, 157);
            listBox3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(222, 28);
            label1.TabIndex = 1;
            label1.Text = "Связи:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(listBox2, 0, 1);
            tableLayoutPanel5.Controls.Add(label2, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(4, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel5.Size = new Size(228, 190);
            tableLayoutPanel5.TabIndex = 7;
            // 
            // listBox2
            // 
            listBox2.BackColor = SystemColors.Control;
            listBox2.Dock = DockStyle.Fill;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(3, 31);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(222, 156);
            listBox2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(222, 28);
            label2.TabIndex = 1;
            label2.Text = "Используемые точки и их координаты:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(label3, 0, 0);
            tableLayoutPanel6.Controls.Add(listBox4, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(4, 399);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel6.Size = new Size(228, 192);
            tableLayoutPanel6.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(222, 28);
            label3.TabIndex = 0;
            label3.Text = "Радиус покрытия точек:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBox4
            // 
            listBox4.BackColor = SystemColors.Control;
            listBox4.Dock = DockStyle.Fill;
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 15;
            listBox4.Location = new Point(3, 31);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(222, 158);
            listBox4.TabIndex = 1;
            // 
            // SelectEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 601);
            Controls.Add(tableLayoutPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(980, 640);
            MinimumSize = new Size(980, 640);
            Name = "SelectEquipment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор оборудования";
            Load += SelectEquipment_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private CodeeloUI.Controls.CodeeloButton codeeloButton1;
        private ListBox listBox1;
        private CodeeloUI.Controls.CodeeloButton codeeloButton2;
        private CodeeloUI.Controls.CodeeloButton codeeloButton4;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox listBox3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel5;
        private ListBox listBox2;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label3;
        private ListBox listBox4;
    }
}