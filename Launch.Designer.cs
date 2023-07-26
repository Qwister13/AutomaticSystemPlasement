namespace Interface2
{
    partial class Launch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launch));
            codeeloCircularProgressBar1 = new CodeeloUI.Controls.CodeeloCircularProgressBar();
            codeeloButton1 = new CodeeloUI.Controls.CodeeloButton();
            codeeloButton2 = new CodeeloUI.Controls.CodeeloButton();
            codeeloPictureBox1 = new CodeeloUI.Controls.CodeeloPictureBox();
            ((System.ComponentModel.ISupportInitialize)codeeloPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // codeeloCircularProgressBar1
            // 
            codeeloCircularProgressBar1.BackColor = Color.Transparent;
            codeeloCircularProgressBar1.BarFirstColor = Color.DeepSkyBlue;
            codeeloCircularProgressBar1.BarSecondColor = Color.DodgerBlue;
            codeeloCircularProgressBar1.BarShapeEnd = System.Drawing.Drawing2D.LineCap.Round;
            codeeloCircularProgressBar1.BarShapeStart = System.Drawing.Drawing2D.LineCap.Round;
            codeeloCircularProgressBar1.BarWidth = 14F;
            codeeloCircularProgressBar1.DisplayedTextType = CodeeloUI.Controls.CodeeloCircularProgressBar.TextMode.Percentage;
            codeeloCircularProgressBar1.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            codeeloCircularProgressBar1.ForeColor = Color.Silver;
            codeeloCircularProgressBar1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloCircularProgressBar1.LineColor = Color.Silver;
            codeeloCircularProgressBar1.LineWidth = 1;
            codeeloCircularProgressBar1.Location = new Point(95, 222);
            codeeloCircularProgressBar1.MaxValue = 100;
            codeeloCircularProgressBar1.MinimumSize = new Size(180, 180);
            codeeloCircularProgressBar1.Name = "codeeloCircularProgressBar1";
            codeeloCircularProgressBar1.Size = new Size(180, 180);
            codeeloCircularProgressBar1.TabIndex = 0;
            codeeloCircularProgressBar1.Text = "1%";
            codeeloCircularProgressBar1.Value = 1;
            // 
            // codeeloButton1
            // 
            codeeloButton1.AccessibleRole = null;
            codeeloButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            codeeloButton1.BackColor = Color.Transparent;
            codeeloButton1.BorderColor_1 = Color.DodgerBlue;
            codeeloButton1.BorderColor_2 = Color.SpringGreen;
            codeeloButton1.BorderRadius = 20;
            codeeloButton1.BorderSize = 3;
            codeeloButton1.CausesValidation = false;
            codeeloButton1.ColorFill_1 = Color.FromArgb(20, 30, 40);
            codeeloButton1.ColorFill_2 = Color.DodgerBlue;
            codeeloButton1.DialogResult = false;
            codeeloButton1.FlatAppearance.BorderSize = 0;
            codeeloButton1.FlatStyle = FlatStyle.Flat;
            codeeloButton1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            codeeloButton1.ForeColor = Color.WhiteSmoke;
            codeeloButton1.GradientBorderDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton1.Location = new Point(12, 428);
            codeeloButton1.Name = "codeeloButton1";
            codeeloButton1.OnClick_BorderColor_1 = Color.ForestGreen;
            codeeloButton1.OnClick_BorderColor_2 = Color.Green;
            codeeloButton1.OnClick_FillColor_1 = Color.SpringGreen;
            codeeloButton1.OnClick_FillColor_2 = Color.SpringGreen;
            codeeloButton1.OnOver_BorderColor_1 = Color.Chartreuse;
            codeeloButton1.OnOver_BorderColor_2 = Color.Green;
            codeeloButton1.OnOver_FillColor_1 = Color.SpringGreen;
            codeeloButton1.OnOver_FillColor_2 = Color.SpringGreen;
            codeeloButton1.Size = new Size(170, 60);
            codeeloButton1.TabIndex = 1;
            codeeloButton1.TabStop = false;
            codeeloButton1.Text = "Запуск";
            codeeloButton1.TextAlign = CodeeloUI.Enums.TextPosition.Center;
            codeeloButton1.UseMnemonic = false;
            codeeloButton1.UseVisualStyleBackColor = false;
            codeeloButton1.Click += codeeloButton1_Click;
            // 
            // codeeloButton2
            // 
            codeeloButton2.AccessibleRole = null;
            codeeloButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            codeeloButton2.BackColor = Color.Transparent;
            codeeloButton2.BorderColor_1 = Color.DodgerBlue;
            codeeloButton2.BorderColor_2 = Color.SpringGreen;
            codeeloButton2.BorderRadius = 20;
            codeeloButton2.BorderSize = 3;
            codeeloButton2.CausesValidation = false;
            codeeloButton2.ColorFill_1 = Color.FromArgb(20, 30, 40);
            codeeloButton2.ColorFill_2 = Color.DodgerBlue;
            codeeloButton2.DialogResult = false;
            codeeloButton2.FlatAppearance.BorderSize = 0;
            codeeloButton2.FlatStyle = FlatStyle.Flat;
            codeeloButton2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            codeeloButton2.ForeColor = Color.WhiteSmoke;
            codeeloButton2.GradientBorderDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloButton2.Location = new Point(198, 428);
            codeeloButton2.Name = "codeeloButton2";
            codeeloButton2.OnClick_BorderColor_1 = Color.LightCoral;
            codeeloButton2.OnClick_BorderColor_2 = Color.Maroon;
            codeeloButton2.OnClick_FillColor_1 = Color.Red;
            codeeloButton2.OnClick_FillColor_2 = Color.Maroon;
            codeeloButton2.OnOver_BorderColor_1 = Color.LightCoral;
            codeeloButton2.OnOver_BorderColor_2 = Color.DarkRed;
            codeeloButton2.OnOver_FillColor_1 = Color.LightCoral;
            codeeloButton2.OnOver_FillColor_2 = Color.Red;
            codeeloButton2.Size = new Size(170, 60);
            codeeloButton2.TabIndex = 2;
            codeeloButton2.TabStop = false;
            codeeloButton2.Text = "Выход";
            codeeloButton2.TextAlign = CodeeloUI.Enums.TextPosition.Center;
            codeeloButton2.UseMnemonic = false;
            codeeloButton2.UseVisualStyleBackColor = false;
            codeeloButton2.Click += codeeloButton2_Click;
            // 
            // codeeloPictureBox1
            // 
            codeeloPictureBox1.BackColor = Color.Transparent;
            codeeloPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            codeeloPictureBox1.BorderColorFirst = Color.RoyalBlue;
            codeeloPictureBox1.BorderColorSecond = Color.HotPink;
            codeeloPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            codeeloPictureBox1.BorderSize = 0;
            codeeloPictureBox1.DrawBorder = true;
            codeeloPictureBox1.DrawBorderInside = false;
            codeeloPictureBox1.DrawCircle = false;
            codeeloPictureBox1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            codeeloPictureBox1.Image = Properties.Resources.quote_2023_02_26_8bee79900e2763c74a2c3705fc4c693e;
            codeeloPictureBox1.Location = new Point(0, -1);
            codeeloPictureBox1.Margin = new Padding(0);
            codeeloPictureBox1.Name = "codeeloPictureBox1";
            codeeloPictureBox1.Size = new Size(380, 189);
            codeeloPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            codeeloPictureBox1.TabIndex = 3;
            codeeloPictureBox1.TabStop = false;
            codeeloPictureBox1.UseGradient = false;
            // 
            // Launch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(380, 500);
            Controls.Add(codeeloPictureBox1);
            Controls.Add(codeeloButton2);
            Controls.Add(codeeloButton1);
            Controls.Add(codeeloCircularProgressBar1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(380, 500);
            MinimumSize = new Size(380, 500);
            Name = "Launch";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Launch";
            Activated += Launch_Activated;
            Load += Launch_Load;
            SizeChanged += Launch_SizeChanged;
            Paint += Launch_Paint;
            MouseDown += Launch_MouseDown;
            ((System.ComponentModel.ISupportInitialize)codeeloPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CodeeloUI.Controls.CodeeloCircularProgressBar codeeloCircularProgressBar1;
        private CodeeloUI.Controls.CodeeloButton codeeloButton1;
        public CodeeloUI.Controls.CodeeloButton codeeloButton2;
        private CodeeloUI.Controls.CodeeloPictureBox codeeloPictureBox1;
    }
}