using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools_ArthurMS.AMS_DataBase;
using System.Windows.Forms;
using prjFerreteraConstru_K.Vista;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CProveedores
    {
        frmPerfil frm = new frmPerfil();
        Cls_Anim anim = new Cls_Anim();
        public void frm_load()
        {
            
            
            Cls_Diseno_Config.efecto_abre(frm);

            frm.btnSalir.Click += btnSalir_Click;
          
            frm.Opacity = 50;
            frm.ShowDialog();
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {
            clsMsg.mtdMsg(frm, "Seleccione cliente a modificar", 10);
        }

        void btnSalir_Click(object sender, EventArgs e)
        {
            anim.mtdAnimacionDeslizaArribaOut(frm, 5);
        }
    }
}
