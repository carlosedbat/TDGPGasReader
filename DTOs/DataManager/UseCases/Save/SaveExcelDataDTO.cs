namespace TDGPGasReader.DTOs.DataManager.UseCases.Save
{
    public class SaveExcelDataDTO
    {
        public string MeasurementType { get; set; }

        public DateTime Timestamp { get; set; }

        public double SensorTemperature { get; set; }

        public double PressureMBar { get; set; }

        public double SupplyVoltage { get; set; }

        public double Atm { get; set; }

        public double N2Concentration { get; set; }

        public double NitrogenMass { get; set; }

        public double TdgPercentual { get; set; }
    }
}
