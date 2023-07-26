namespace Interface2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip1 = new MenuStrip();
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel6 = new ToolStripLabel();
            toolStripLabel8 = new ToolStripLabel();
            toolStripLabel9 = new ToolStripLabel();
            toolStripLabel10 = new ToolStripLabel();
            toolStripLabel11 = new ToolStripLabel();
            toolStripLabel4 = new ToolStripLabel();
            toolStripLabel7 = new ToolStripLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            toolStrip2 = new ToolStrip();
            StopGenAlgorithm = new ToolStripButton();
            listBox1 = new ListBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            RefreshPoint = new Button();
            toolStripProgressBar2 = new ProgressBar();
            label1 = new Label();
            UpdateEquipment = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Location = new Point(1, 1);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(810, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(1, 63);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(810, 477);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Tag = "";
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.Dock = DockStyle.Fill;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2, toolStripLabel3, toolStripLabel5, toolStripLabel6, toolStripLabel8, toolStripLabel9, toolStripLabel10, toolStripLabel11, toolStripLabel4, toolStripLabel7 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(1, 541);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(810, 30);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.AutoSize = false;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(109, 25);
            toolStripLabel1.Text = "Название проекта:";
            toolStripLabel1.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(0, 27);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(10, 27);
            toolStripLabel3.Text = " ";
            toolStripLabel3.TextImageRelation = TextImageRelation.Overlay;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(0, 27);
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(0, 27);
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.AutoSize = false;
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(155, 25);
            toolStripLabel8.Text = "Количество точек доступа:";
            // 
            // toolStripLabel9
            // 
            toolStripLabel9.Name = "toolStripLabel9";
            toolStripLabel9.Size = new Size(10, 27);
            toolStripLabel9.Text = " ";
            // 
            // toolStripLabel10
            // 
            toolStripLabel10.AutoSize = false;
            toolStripLabel10.Name = "toolStripLabel10";
            toolStripLabel10.Size = new Size(131, 25);
            toolStripLabel10.Text = "Площадь помещения:";
            // 
            // toolStripLabel11
            // 
            toolStripLabel11.Name = "toolStripLabel11";
            toolStripLabel11.Size = new Size(10, 27);
            toolStripLabel11.Text = " ";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(164, 27);
            toolStripLabel4.Text = "Значение целевой функции:";
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(10, 27);
            toolStripLabel7.Text = " ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 3);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(toolStrip2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(812, 572);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            toolStrip2.AutoSize = false;
            toolStrip2.BackColor = Color.Transparent;
            toolStrip2.Dock = DockStyle.Fill;
            toolStrip2.Items.AddRange(new ToolStripItem[] { StopGenAlgorithm });
            toolStrip2.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip2.Location = new Point(1, 32);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(810, 30);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // StopGenAlgorithm
            // 
            StopGenAlgorithm.AutoSize = false;
            StopGenAlgorithm.DisplayStyle = ToolStripItemDisplayStyle.Image;
            StopGenAlgorithm.Image = (Image)resources.GetObject("StopGenAlgorithm.Image");
            StopGenAlgorithm.ImageTransparentColor = Color.Magenta;
            StopGenAlgorithm.Name = "StopGenAlgorithm";
            StopGenAlgorithm.Size = new Size(30, 29);
            StopGenAlgorithm.Text = "Прервать выполнение алгоритма";
            StopGenAlgorithm.Click += StopGenAlgorithm_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Control;
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(4, 44);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.None;
            listBox1.Size = new Size(206, 406);
            listBox1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(RefreshPoint, 0, 3);
            tableLayoutPanel2.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel2.Controls.Add(toolStripProgressBar2, 0, 4);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(UpdateEquipment, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(821, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 73F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 7.53064775F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 7.53064775F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.Size = new Size(214, 572);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // RefreshPoint
            // 
            RefreshPoint.AutoSize = true;
            RefreshPoint.BackColor = Color.Transparent;
            RefreshPoint.Dock = DockStyle.Fill;
            RefreshPoint.Location = new Point(4, 500);
            RefreshPoint.Name = "RefreshPoint";
            RefreshPoint.Size = new Size(206, 36);
            RefreshPoint.TabIndex = 4;
            RefreshPoint.Text = "Обновить точки";
            RefreshPoint.UseVisualStyleBackColor = false;
            // 
            // toolStripProgressBar2
            // 
            toolStripProgressBar2.Dock = DockStyle.Fill;
            toolStripProgressBar2.Location = new Point(4, 543);
            toolStripProgressBar2.Name = "toolStripProgressBar2";
            toolStripProgressBar2.Size = new Size(206, 25);
            toolStripProgressBar2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(206, 39);
            label1.TabIndex = 6;
            label1.Text = "Точки доступа с \r\nрадиусом покрытия:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UpdateEquipment
            // 
            UpdateEquipment.BackColor = Color.Transparent;
            UpdateEquipment.Dock = DockStyle.Fill;
            UpdateEquipment.Location = new Point(4, 457);
            UpdateEquipment.Name = "UpdateEquipment";
            UpdateEquipment.Size = new Size(206, 36);
            UpdateEquipment.TabIndex = 7;
            UpdateEquipment.Text = "Обновить оборудование";
            UpdateEquipment.UseVisualStyleBackColor = false;
            UpdateEquipment.Click += UpdateEquipment_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.9F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.1F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1038, 578);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 578);
            Controls.Add(tableLayoutPanel3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1054, 617);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Автоматизированная система размещения сетевого оборудования";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel toolStripLabel5;
        private ToolStripLabel toolStripLabel6;
        private ToolStripLabel toolStripLabel8;
        private ToolStripLabel toolStripLabel9;
        public ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel10;
        public ToolStripLabel toolStripLabel11;
        private TableLayoutPanel tableLayoutPanel1;
        public ListBox listBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button RefreshPoint;
        private ToolStrip toolStrip2;
        private ToolStripButton StopGenAlgorithm;
        private ToolStripLabel toolStripLabel4;
        private ToolStripLabel toolStripLabel7;
        private TableLayoutPanel tableLayoutPanel3;
        private ProgressBar toolStripProgressBar2;
        private Label label1;
        private Button UpdateEquipment;
    }
}