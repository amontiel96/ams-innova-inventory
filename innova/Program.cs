using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Controlador;

namespace prjFerreteraConstru_K
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmPrincipal());
           //Cls_CPrincipal frm = new Controlador.Cls_CPrincipal();
            Cls_CSplash frm = new Cls_CSplash();
            frm.frm_load();
        }
    }
}
