using WK.Libraries.HotkeyListenerNS;

namespace WallpaperSlideshow
{
    public partial class Form1 : Form
    {
        private Slideshow _slideshow = new();
        private NotifyIcon _trayIcon = new();
        private HotkeyListener _hotkeyListener = new();
        private HotkeySelector _hotkeySelector = new();
        private Hotkey _nextHotkey = new(Keys.Control | Keys.Alt, Keys.N);
        public Form1()
        {
            InitializeComponent();
            var iconHandle = Properties.Resources.framed_picture_icon.GetHicon();
            this.Icon = Icon.FromHandle(iconHandle);

            _trayIcon.Text = "Wallpaper Slideshow";
            _trayIcon.Visible = true;
            // https://stackoverflow.com/a/1870823
            _trayIcon.Icon = Icon.FromHandle(iconHandle);
            #region iconContextMenu
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
            #endregion

            txtPath.Text = _slideshow.Path;
            numSleepSeconds.Value = _slideshow.SleepSeconds;

            _nextHotkey = HotkeyListener.Convert(LocalStorage.GetItem<string>("nextHotkey") ?? "Control, Alt + N");
            _hotkeyListener.HotkeyUpdated += (_, e) =>
            {
                if (e.UpdatedHotkey == _nextHotkey)
                {
                    LocalStorage.SetItem("nextHotkey", HotkeyListener.Convert(_nextHotkey));
                }
            };
            _hotkeyListener.SuspendOn(this);
            _hotkeyListener.Add(_nextHotkey);
            _hotkeySelector.Enable(txtNextShortcut, _nextHotkey);
            _hotkeyListener.HotkeyPressed += (_, e) =>
            {
                if (e.Hotkey == _nextHotkey)
                {
                    _slideshow.NextWallpaper();
                }
            };

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

        private void btnSelectPath_Click(object sender, EventArgs e)
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

        private void btnUpdateNextShortcut_Click(object sender, EventArgs e)
        {
            _hotkeyListener.Update(ref _nextHotkey, HotkeyListener.Convert(txtNextShortcut.Text));
            btnUpdateNextShortcut.Enabled = false;
            btnResetNextShortcut.Enabled = false;
        }

        private void txtNextShortcut_TextChanged(object sender, EventArgs e)
        {
            btnUpdateNextShortcut.Enabled = txtNextShortcut.Text != HotkeyListener.Convert(_nextHotkey);
            btnResetNextShortcut.Enabled = btnUpdateNextShortcut.Enabled;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !txtNextShortcut.Focused)
            {
                Hide();
            }
        }

        private void btnResetNextShortcut_Click(object sender, EventArgs e)
        {
            txtNextShortcut.Text = HotkeyListener.Convert(_nextHotkey);
            btnUpdateNextShortcut.Enabled = txtNextShortcut.Text != HotkeyListener.Convert(_nextHotkey);
            btnResetNextShortcut.Enabled = btnUpdateNextShortcut.Enabled;
        }
    }
}