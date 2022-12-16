namespace WallpaperSlideshow
{
    internal class Slideshow
    {
        private Thread _thread;
        private bool _paused = false;

        public string LastImage
        {
            get => LocalStorage.GetItem<string>("lastImagePath") ?? "";
            private set => LocalStorage.SetItem("lastImagePath", value);
        }

        public string Path
        {
            get => LocalStorage.GetItem<string>("path") ?? "";
            set => LocalStorage.SetItem("path", value);
        }

        public int SleepSeconds
        {
            get
            {
                int secs = LocalStorage.GetItem<int>("sleepSeconds");
                if (secs == 0)
                {
                    secs = 10;
                }
                return secs;
            }
            set => LocalStorage.SetItem("sleepSeconds", value);
        }

        public bool Paused { get => _paused; set => _paused = value; }


        public Slideshow()
        {
            _thread = new(runThread);
            // because
            // https://stackoverflow.com/a/2689000
            _thread.IsBackground = true;
        }

        public void StartThread()
        {
            _thread.Start();
        }

        public void JoinThread()
        {
            _thread.Join();
        }

        public void NextWallpaper()
        {
            string lastImage = LastImage;
            string[] candidates = Directory.GetFiles(Path)
                .Where(name => name != lastImage)
                .Where(name =>
                    name.ToLower().EndsWith(".png")
                    || name.ToLower().EndsWith(".jpg")
                    || name.ToLower().EndsWith(".jpeg")
                ).ToArray();
            Random random = new();
            string name = candidates[random.Next(candidates.Length)];
            LastImage = name;
            Wallpaper.SetWallpaper(name);
        }

        private void runThread()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(SleepSeconds * 1000);
                    if (!_paused)
                    {
                        NextWallpaper();
                    }
                }
                catch (ThreadInterruptedException)
                {
                    // nothing
                }
                catch
                {
                    // nothing again
                }
            }
        }
    }
}
