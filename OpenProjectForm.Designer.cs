﻿namespace Interface2
{
    partial class OpenProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenProjectForm));
            panel = new Panel();
            SuspendLayout();
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(364, 301);
            panel.TabIndex = 0;
            // 
            // OpenProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 301);
            Controls.Add(panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(380, 340);
            MinimumSize = new Size(380, 340);
            Name = "OpenProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Открытие проекта";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
    }
}