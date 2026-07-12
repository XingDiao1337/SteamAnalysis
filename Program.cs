using System;
using System.IO;
using System.Windows.Forms;

namespace SteamAnalysisAvalonia
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var logDir = AppDomain.CurrentDomain.BaseDirectory;
            Application.ThreadException += (s, e) =>
            {
                File.WriteAllText(Path.Combine(logDir, "crash_thread.log"), e.Exception.ToString());
            };
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                File.WriteAllText(Path.Combine(logDir, "crash_unhandled.log"), e.ExceptionObject.ToString());
            };

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(logDir, "crash_main.log"), ex.ToString());
            }
        }
    }
}
