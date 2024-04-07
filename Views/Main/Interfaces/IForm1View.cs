﻿using TDGPGasReader.Presenter.MainForm.Interfaces;

namespace TDGPGasReader.Views.Main.Interfaces
{
    public interface IForm1View
    {
        void ShowErrorMessage(string message);

        void ShowAlertMessage(string message);

        void SetPresenter(IMainFormPresenter presenter);

        void AddDataInTerminal(string stringedDataToTerminal);

        void PopulateSerialPortComboBox(string[] portsAvaiable);

        void SetTemperature(double temperature);

        void SetTDGPercentual(double tdgPercentual);

        void SetNitrogenMass(double nitrogenMass);

        void SetN2Concentration(double n2Concentration);

        void SetATM(double atm);

        string ShowSaveFileDialog();
    }
}
