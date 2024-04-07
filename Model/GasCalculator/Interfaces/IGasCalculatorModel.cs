namespace TDGPGasReader.Model.GasCalculator.Interfaces
{
    public interface IGasCalculatorModel
    {
        double CalculateATM(double pressure);

        double CalculateN2Concentration(double atm);

        double CalculateNitrogenMass(double n2Concentration);

        double CalculateTDGPercentual(double nitrogenMass);
    }
}
