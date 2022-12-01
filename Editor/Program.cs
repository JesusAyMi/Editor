namespace Editor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            fmPresentacion ventanapresentacion = new fmPresentacion();
            ventanapresentacion.ShowDialog();
            Application.Run(new fmEditor());

            ApplicationConfiguration.Initialize();
            Application.Run(new fmEditor());
        }
    }
}