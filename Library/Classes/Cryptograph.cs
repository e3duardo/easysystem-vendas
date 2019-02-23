using System.Management;

namespace Library.Classes
{
   public class Cryptograph
    {
        public Cryptograph ()
        {
        }

        static public int CheckAndCountMAC()
        {
            using (ManagementClass mc = new ManagementClass("WIN32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc = mc.GetInstances();
                int countMACs = 0;
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        switch (mo["MacAddress"].ToString())
                        {
                            case "00:1B:FC:2B:60:84"://ideia-frente??
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "48:5B:39:BB:27:6E"://ideia-arte??
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:0C:29:83:E4:62"://maquinavirtual1
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:0C:29:D2:B2:87"://maquinavirtual2(vinicius)
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:1D:60:54:A1:45"://eduardo-pc
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:24:8C:A4:7E:4E"://santos-pc
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:18:E7:19:59:80"://Arte Livre 1
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:30:67:33:DC:90"://Arte Livre 2
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "00:24:1D:F1:A9:26"://Arte Livre 2
                                countMACs++;
                                mo.Dispose();
                                break;
                            case "90:E6:BA:BF:3C:96"://servidor
                                countMACs++;
                                mo.Dispose();
                                break;
                        }
                    }
                }
                return countMACs;
            }
        }
    }
}
