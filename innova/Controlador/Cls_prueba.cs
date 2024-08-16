using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjFerreteraConstru_K.Vista;
using System.Windows.Forms;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_prueba
    {
        
        Cls_Anim ani = new Cls_Anim();
        ctrlinicio frm;
        public Control frm_load(ctrlinicio _frm)
        {
            frm = _frm;
            frm = new ctrlinicio();
           
            return frm;
        }

        void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        void tmrEfecto_Tick(object sender, EventArgs e)
        {
            
        }

    }
}
