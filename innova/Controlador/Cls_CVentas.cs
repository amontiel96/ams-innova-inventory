using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Vista;
using Tools_ArthurMS.AMS_DataBase;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CVentas
    {
        Cls_Anim ani = new Cls_Anim();
        ctrlVentas frm;
        frmPrincipal frme = new frmPrincipal();
        public Control frm_load(ctrlVentas _frm)
        {
            frm = _frm;
            frm = new ctrlVentas();
            frm.btnGuardar.Click += btnGuardar_Click;
            frm.btnNuevo.Click += btnNuevo_Click;
            return frm;
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {
            clsMsg.mtdMsg(frme, "Seleccione cliente a modificar", 20);
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            frm.tblVentas.DataSource = AMS_DB_Functions.Instancia().consultas("select * from tblventas");
        }
    }
}
