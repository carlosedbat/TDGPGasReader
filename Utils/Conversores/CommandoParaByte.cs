namespace TDGPGasReader.Utils.Conversores
{
    using System.Collections.Generic;
    using System.Text; // Para usar Encoding.ASCII

    public class ComandoParaByte
    {
        private Dictionary<string, byte[]> comandoMap;

        public ComandoParaByte()
        {
            comandoMap = new Dictionary<string, byte[]>();
            // Adiciona números de 0 a 125 mapeados para seus valores ASCII completos
            for (int i = 0; i <= 1028; i++)
            {
                comandoMap.Add(i.ToString(), Encoding.ASCII.GetBytes(i.ToString()));
            }

            // Mapeamento adicional para caracteres específicos
            comandoMap.Add("y", new byte[] { (byte)'y' });
            comandoMap.Add("b", new byte[] { (byte)'b' });
            comandoMap.Add("n", new byte[] { (byte)'n' });
            comandoMap.Add("r", new byte[] { (byte)'r' });
            comandoMap.Add("s", new byte[] { (byte)'s' });
            comandoMap.Add("t", new byte[] { (byte)'t' });
            comandoMap.Add(".", new byte[] { (byte)'.' });
            comandoMap.Add("ESC", new byte[] { 0x1B });  // ASCII para ESC
        }

        public byte[] GetComandoByte(string command)
        {
            if (comandoMap.TryGetValue(command, out byte[] value))
            {
                return value;
            }
            else
            {
                throw new KeyNotFoundException("Comando não mapeado.");
            }
        }
    }

}
