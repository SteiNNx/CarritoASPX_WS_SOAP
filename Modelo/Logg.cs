using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace Modelo
{
    public class Logg
    {
        public static void Mensaje(string msg)
        {


            msg = DateTime.Now + " | " + msg;
            File.AppendAllText(@"d:\log.txt", msg + Environment.NewLine);
        }
    }
}
