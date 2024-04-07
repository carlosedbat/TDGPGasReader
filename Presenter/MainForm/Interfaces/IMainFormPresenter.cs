using System.ComponentModel;
using TDGPGasReader.Views.Main.Interfaces;

namespace TDGPGasReader.Presenter.MainForm.Interfaces
{
    public interface IMainFormPresenter
    {
        void SetView(IForm1View view);

        bool CheckSerialPortIsOpen();

        void OpenSerialCommunication(string serialPortCommunication);

        void CloseSerialCommunication();

        void ConfigureSerialCommunication(IContainer components);

        void StartAquisition();

        void StopAquisition();
    }
}
