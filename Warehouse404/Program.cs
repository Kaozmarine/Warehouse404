using Warehouse404.View;

namespace Warehouse404
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var mainForm = new MainForm();
            mainForm.Configure();
            
            Application.Run(mainForm);
        }
    }
}