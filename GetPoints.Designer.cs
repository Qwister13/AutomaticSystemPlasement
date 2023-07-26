namespace Interface2
{
    partial class GetPoints
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetPoints));
            toolStrip2 = new ToolStrip();
            SavePointsDataBase = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            listBox1 = new ListBox();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            PlanApproveClick = new ToolStripButton();
            toolStrip2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = SystemColors.Control;
            toolStrip2.Dock = DockStyle.Fill;
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new ToolStripItem[] { SavePointsDataBase, toolStripButton1, toolStripButton2, PlanApproveClick });
            toolStrip2.LayoutStyle = ToolStripLayoutStyle.Flow;
            toolStrip2.Location = new Point(1, 29);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(804, 27);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // SavePointsDataBase
            // 
            SavePointsDataBase.AutoSize = false;
            SavePointsDataBase.BackColor = SystemColors.Control;
            SavePointsDataBase.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SavePointsDataBase.Image = (Image)resources.GetObject("SavePointsDataBase.Image");
            SavePointsDataBase.ImageTransparentColor = Color.Magenta;
            SavePointsDataBase.Name = "SavePointsDataBase";
            SavePointsDataBase.Size = new Size(140, 26);
            SavePointsDataBase.Text = "Сохранить координаты";
            SavePointsDataBase.Click += SavePoints_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.AutoSize = false;
            toolStripButton1.BackColor = SystemColors.Control;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(84, 26);
            toolStripButton1.Text = "Очистить всё";
            toolStripButton1.Click += DeleteAll_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.AutoSize = false;
            toolStripButton2.BackColor = SystemColors.Control;
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(120, 26);
            toolStripButton2.Text = "Удалить выбранное";
            toolStripButton2.Click += DeleteSelect_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1027, 535);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.0660248F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.9339771F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1027, 535);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(815, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 4.431599F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 95.5684F));
            tableLayoutPanel1.Size = new Size(209, 529);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // listBox1
            // 
            listBox1.AccessibleName = "";
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(4, 28);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(201, 497);
            listBox1.TabIndex = 2;
            listBox1.TabStop = false;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(201, 23);
            label1.TabIndex = 3;
            label1.Text = "Координаты точек доступа:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(pictureBox1, 0, 2);
            tableLayoutPanel3.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel3.Controls.Add(toolStrip2, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(806, 529);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(1, 57);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(804, 471);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Tag = "";
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Location = new Point(1, 1);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(202, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // PlanApproveClick
            // 
            PlanApproveClick.AutoSize = false;
            PlanApproveClick.DisplayStyle = ToolStripItemDisplayStyle.Text;
            PlanApproveClick.Image = (Image)resources.GetObject("PlanApproveClick.Image");
            PlanApproveClick.ImageTransparentColor = Color.Magenta;
            PlanApproveClick.Name = "PlanApproveClick";
            PlanApproveClick.Size = new Size(100, 26);
            PlanApproveClick.Text = "Утвердить план";
            PlanApproveClick.Click += PlanApproveClick_Click;
            // 
            // GetPoints
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 535);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            MinimumSize = new Size(1043, 574);
            Name = "GetPoints";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Установка точек подключения";
            Load += GetPoints_Load;
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private Panel panel1;
        private ToolStripButton SavePointsDataBase;
        private MenuStrip menuStrip1;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private ToolStripButton PlanApproveClick;
    }
}