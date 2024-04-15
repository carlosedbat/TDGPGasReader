using TDGPGasReader.Enums;

namespace TDGPGasReader.Model.GasCalculator.Interfaces
{
    public interface IGasCalculatorModel
    {
        double CalculateATM(double pressure);

        //double CalculateN2Concentration(double atm);

        //double CalculateNitrogenMass(double n2Concentration);

        //double CalculateTDGPercentual(double nitrogenMass);

        double CalculateTdgConcentration(double pressure, double temperature);

        double CalculateTDGMass(double pressureMbar, double temperature);

        double CalculateTDGPercentage(double pressureMbar, double temperature);
    }
}
