using Microsoft.Extensions.DependencyInjection;
using TDGPGasReader.Presenter.MainForm.Interfaces;
using TDGPGasReader.Services;
using TDGPGasReader.Views.Main.Interfaces;

namespace TDGPGasReader
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
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            // Assegure-se de que esta linha esteja acessível após adicionar a referência correta
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Cria o Presenter sem a View
                var myPresenter = serviceProvider.GetRequiredService<IMainFormPresenter>();

                // Cria a View
                var mainForm = serviceProvider.GetRequiredService<IForm1View>();

                // Define a View no Presenter
                myPresenter.SetView(mainForm);

                mainForm.SetPresenter(myPresenter);

                Application.Run((Form)mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            ServiceConfiguration.ConfigureServices(services);
        }
    }
}