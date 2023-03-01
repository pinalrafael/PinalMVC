using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PinalMVC.Classes
{
    public class Util
    {
        public static bool BaixarBiblioteca(string DownloadDir, string Nome)
        {
            try
            {

                using (var client = new WebClient())
                {
                    client.DownloadFile("http://dwcpsystems.tecnologia.ws/PinalMVC.zip", DownloadDir + "\\" + Nome + ".zip");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
