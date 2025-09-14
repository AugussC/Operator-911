using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operador_911
{///nunca usar un numererador para un coso de auditoria ejemplo una factura, 
    //se hace otra tabla donde se guarda el ultimo valor
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            Database.HacerBackupSemanal();
        }
    }
}
