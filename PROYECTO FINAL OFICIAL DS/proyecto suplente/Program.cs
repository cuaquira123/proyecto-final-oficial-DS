using proyecto_suplente.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_suplente
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*frmlogin frmlogin1 = new frmlogin();
            frmlogin1.ShowDialog();*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmlogin());

        }
    }
}
