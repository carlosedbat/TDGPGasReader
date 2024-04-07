using TDGPGasReader.Model.Excel.interfaces;
using TDGPGasReader.Presenter.DataManager.Interfaces;

namespace TDGPGasReader.Presenter.DataManager
{
    public class DataManagerPresenter : IDataManagerPresenter
    {
        private IExcelManagerModel _excelManagerModel;

        public DataManagerPresenter(IExcelManagerModel excelManagerModel)
        {
            this._excelManagerModel = excelManagerModel;
        }
    }
}
