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
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.numSleepSeconds = new System.Windows.Forms.NumericUpDown();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtNextShortcut = new System.Windows.Forms.TextBox();
            this.btnUpdateNextShortcut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResetNextShortcut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(161, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(279, 23);
            this.txtPath.TabIndex = 0;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(446, 11);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "Select";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // numSleepSeconds
            // 
            this.numSleepSeconds.Location = new System.Drawing.Point(161, 41);
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
            // txtNextShortcut
            // 
            this.txtNextShortcut.Location = new System.Drawing.Point(161, 70);
            this.txtNextShortcut.Name = "txtNextShortcut";
            this.txtNextShortcut.ReadOnly = true;
            this.txtNextShortcut.Size = new System.Drawing.Size(279, 23);
            this.txtNextShortcut.TabIndex = 3;
            this.txtNextShortcut.TextChanged += new System.EventHandler(this.txtNextShortcut_TextChanged);
            // 
            // btnUpdateNextShortcut
            // 
            this.btnUpdateNextShortcut.Enabled = false;
            this.btnUpdateNextShortcut.Location = new System.Drawing.Point(446, 70);
            this.btnUpdateNextShortcut.Name = "btnUpdateNextShortcut";
            this.btnUpdateNextShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateNextShortcut.TabIndex = 4;
            this.btnUpdateNextShortcut.Text = "Update";
            this.btnUpdateNextShortcut.UseVisualStyleBackColor = true;
            this.btnUpdateNextShortcut.Click += new System.EventHandler(this.btnUpdateNextShortcut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wallpaper folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Interval:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Next Wallpaper Shortcut:";
            // 
            // btnResetNextShortcut
            // 
            this.btnResetNextShortcut.Enabled = false;
            this.btnResetNextShortcut.Location = new System.Drawing.Point(527, 69);
            this.btnResetNextShortcut.Name = "btnResetNextShortcut";
            this.btnResetNextShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnResetNextShortcut.TabIndex = 8;
            this.btnResetNextShortcut.Text = "Reset";
            this.btnResetNextShortcut.UseVisualStyleBackColor = true;
            this.btnResetNextShortcut.Click += new System.EventHandler(this.btnResetNextShortcut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 110);
            this.Controls.Add(this.btnResetNextShortcut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateNextShortcut);
            this.Controls.Add(this.txtNextShortcut);
            this.Controls.Add(this.numSleepSeconds);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Wallpaper Slideshow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numSleepSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtPath;
        private Button btnSelectPath;
        private NumericUpDown numSleepSeconds;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox txtNextShortcut;
        private Button btnUpdateNextShortcut;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnResetNextShortcut;
    }
}