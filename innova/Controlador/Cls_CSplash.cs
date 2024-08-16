using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Vista;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CSplash
    {
        frmSplash frm = new frmSplash();

        int tiempo = 0;

        public void frm_load()
        {
            frm.tmrSplash.Start();
            frm.Opacity = 0;
            frm.tmrSplash.Tick += tmrSplash_Tick;
            Application.EnableVisualStyles();
            frm.ShowDialog();
        }

        void tmrSplash_Tick(object sender, EventArgs e)
        {
            tiempo++;
            frm.Opacity += 0.005;
            if (tiempo == 300)
            {
                frm.tmrSplash.Stop();
                frm.Hide();
                Cls_CLogin objMenu = new Cls_CLogin();
                objMenu.frm_load();
                
            }
        }
    }
}
