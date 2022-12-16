namespace WallpaperSlideshow
{
    public partial class Form1 : Form
    {
        Slideshow _slideshow = new();
        NotifyIcon _trayIcon = new();
        public Form1()
        {
            InitializeComponent();
            _trayIcon.Text = "Wallpaper Slideshow";
            _trayIcon.Visible = true;
            // https://stackoverflow.com/a/1870823
            var iconHandle = Properties.Resources.framed_picture_icon.GetHicon();
            _trayIcon.Icon = Icon.FromHandle(iconHandle);
            _trayIcon.ContextMenuStrip = new();
            _trayIcon.ContextMenuStrip.Items.Add("Next wallpaper", null, (_, _) => nextWallpaper());
            _trayIcon.ContextMenuStrip.Items.Add("Pause", null, (_, _) => pause());
            _trayIcon.ContextMenuStrip.Items.Add("Resume", null, (_, _) => resume());
            _trayIcon.ContextMenuStrip.Items.Add("Pause/Resume", null, (_, _) => toggle());
            _trayIcon.ContextMenuStrip.Items.Add("Settings", null, (_, _) => Show());
            _trayIcon.MouseClick += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Show();
                }
            };
            _trayIcon.ContextMenuStrip.Items.Add("Quit", null, (_, _) =>
            {
                _slideshow.Paused = true;
                _trayIcon.Visible = false;
                Application.Exit();
            });
            _trayIcon.ContextMenuStrip.Items[1].Enabled = false;

            txtPath.Text = _slideshow.Path;
            numSleepSeconds.Value = _slideshow.SleepSeconds;

            _slideshow.StartThread();
        }

        private void toggle()
        {
            if (_slideshow.Paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

        private void resume()
        {
            _trayIcon.ContextMenuStrip.Items[1].Enabled = true;
            _trayIcon.ContextMenuStrip.Items[2].Enabled = false;
            _slideshow.Paused = false;
        }

        private void pause()
        {
            _trayIcon.ContextMenuStrip.Items[1].Enabled = false;
            _trayIcon.ContextMenuStrip.Items[2].Enabled = true;
            _slideshow.Paused = true;
        }

        private void nextWallpaper()
        {
            _slideshow.NextWallpaper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK
                && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                _slideshow.Path = folderBrowserDialog.SelectedPath;
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void numSleepSeconds_ValueChanged(object sender, EventArgs e)
        {
            _slideshow.SleepSeconds = (int)numSleepSeconds.Value;
        }
    }
}