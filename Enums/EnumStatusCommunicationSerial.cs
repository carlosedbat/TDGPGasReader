namespace TDGPGasReader.Enums
{
    public enum EnumStatusCommunicationSerial
    {
        WaitingHeader=0,
        HeaderReceived,
        OptionsReceived,
        SensorOn,
        SensorOff,
        DataWithNaN,
    }
}
