using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Vista;


namespace prjFerreteraConstru_K.Controlador
{
    class clsMsg
    {
        private static frmMsg msMensaje;
        private static Cls_Anim clsAnim = new Cls_Anim();
        public static void mtdMsg(System.Windows.Forms.Form frm, string texto, int l)
        {
            if (msMensaje != null)
            {
                msMensaje.Contador = 3000;
                msMensaje.Close();
                msMensaje = new frmMsg(frm, texto, l);
                clsAnim.mtdAnimacionFadeInM(msMensaje, null);
                msMensaje.Show();
            }
            else
            {
                msMensaje = new frmMsg(frm, texto, l);
                clsAnim.mtdAnimacionFadeInM(msMensaje, null);
                msMensaje.Show();
            }
        }
    }
}
