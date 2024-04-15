namespace TDGPGasReader.Services
{
    using Microsoft.Extensions.DependencyInjection;
    using TDGPGasReader.Model.DataManager;
    using TDGPGasReader.Model.DataManager.Interfaces;
    using TDGPGasReader.Model.Excel;
    using TDGPGasReader.Model.Excel.interfaces;
    using TDGPGasReader.Model.GasCalculator;
    using TDGPGasReader.Model.GasCalculator.Interfaces;
    using TDGPGasReader.Model.HenryLawConstants;
    using TDGPGasReader.Model.HenryLawConstants.Interfaces;
    using TDGPGasReader.Model.HenryLawConstants.UseCases.SaturacoesDosGases;
    using TDGPGasReader.Model.Serial;
    using TDGPGasReader.Model.Serial.Interfaces;
    using TDGPGasReader.Presenter.DataManager;
    using TDGPGasReader.Presenter.DataManager.Interfaces;
    using TDGPGasReader.Presenter.MainForm;
    using TDGPGasReader.Presenter.MainForm.Interfaces;
    using TDGPGasReader.Views.Main.Interfaces;
    public class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureForms(services);
            ConfigurePresenters(services);
            ConfigureModels(services);
        }

        private static void ConfigureForms(IServiceCollection services)
        {
            services.AddTransient<Form1>();
            services.AddTransient<IForm1View, Form1>();
        }

        private static void ConfigurePresenters(IServiceCollection services)
        {
            services.AddSingleton<IDataManagerPresenter, DataManagerPresenter>();
            services.AddSingleton<IMainFormPresenter, MainFormPresenter>();
        }

        private static void ConfigureModels(IServiceCollection services)
        {
            services.AddSingleton<IExcelManagerModel, ExcelManagerModel>();
            services.AddSingleton<ISerialManagerModel, SerialManagerModel>();
            services.AddSingleton<IDataManagerModel, DataManagerModel>();
            services.AddSingleton<IGasCalculatorModel, GasCalculatorModel>();
            services.AddSingleton<IHenryLawConstantsModel, HenryLawConstantsModel>();
            services.AddSingleton<IGasSaturationModule, GasSaturationModule>();
        }
    }
}
