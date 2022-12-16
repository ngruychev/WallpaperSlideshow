namespace WallpaperSlideshow
{
    internal static class Program
    {
        private const bool SINGLE_INSTANCE = true;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // https://stackoverflow.com/a/6392264
            if (SINGLE_INSTANCE)
            {
                Mutex? mutex = new(false, "WallpaperSlideshow");
                try
                {
                    if (mutex.WaitOne(0, false))
                    {
                        ApplicationConfiguration.Initialize();
                        Application.Run(new Form1());
                    }
                }
                finally
                {
                    if (mutex != null)
                    {
                        mutex.Close();
                        mutex = null;
                    }
                }
            }
        }
    }
}