namespace WallpaperSlideshow
{
    partial class Form1
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numSleepSeconds = new System.Windows.Forms.NumericUpDown();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(279, 23);
            this.txtPath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numSleepSeconds
            // 
            this.numSleepSeconds.Location = new System.Drawing.Point(12, 41);
            this.numSleepSeconds.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numSleepSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSleepSeconds.Name = "numSleepSeconds";
            this.numSleepSeconds.Size = new System.Drawing.Size(279, 23);
            this.numSleepSeconds.TabIndex = 2;
            this.numSleepSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSleepSeconds.ValueChanged += new System.EventHandler(this.numSleepSeconds_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 81);
            this.Controls.Add(this.numSleepSeconds);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Name = "Form1";
            this.Text = "Wallpaper Slideshow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numSleepSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtPath;
        private Button button1;
        private NumericUpDown numSleepSeconds;
        private FolderBrowserDialog folderBrowserDialog;
    }
}