using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjFerreteraConstru_K.Vista;
using System.Windows.Forms;
using Dll_JMS;


namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CPrincipal
    {
       

        frmPrincipal frm = new frmPrincipal();
        Cls_Anim clsAnim = new Cls_Anim();
        Cls_Validaciones val = new Cls_Validaciones();
        ctrlinicio inic = new ctrlinicio();
        Cls_prueba pr = new Cls_prueba();
        Cls_CVentas objVentas = new Cls_CVentas();
        public void frm_load()
        {
            
            frm.tmrHora.Tick += tmrHora_Tick;
            frm.tmrHora.Start();
            
            clsAnim.mtdAnimacionFadeInM(frm, null);
           
            val.mtdCambiaCtrl(frm, frm.pnl_menu.Size, frm.pnl_titulo.Size, pr.frm_load(new ctrlinicio()), frm.pnl_waint);
           
       
            frm.mnuProveedores.Click += mnuProveedores_Click;
            frm.tmrAnimacion.Tick += tmrAnimacion_Tick;
            
            frm.btnInicio.Click += btnInicio_Click;
            frm.btnVentas.Click += btnVentas_Click;
            frm.mnuEmpleados.Click += mnuEmpleados_Click;
            frm.btnPerfil.Click += btnPerfil_Click;
            frm.btnSalir.Click += btnSalir_Click;
            Application.EnableVisualStyles();
            frm.ShowDialog();
        }

        void btnSalir_Click(object sender, EventArgs e)
        {
            frmMessage mgs = new frmMessage("¿DESEAS SALIR DEL SISTEMA?");
            mgs.ShowDialog();
            if (mgs.bol_)
            {
                clsAnim.mtdAnimacionFadeOutM(frm, null);
            }
        }

        void btnPerfil_Click(object sender, EventArgs e)
        {
            Cls_CPerfil objPerfil = new Cls_CPerfil();
            objPerfil.frm_load(frm.lblClave.Text,frm);
        }

        void mnuEmpleados_Click(object sender, EventArgs e)
        {
            Cls_CEmpleados obje = new Cls_CEmpleados();
            val.mtdCambiaCtrl(frm, frm.pnl_menu.Size, frm.pnl_titulo.Size, obje.frm_load(new ctrlEmpleados(),Convert.ToInt32(frm.lblClave.Text)), frm.pnl_waint);
        }

        void btnVentas_Click(object sender, EventArgs e)
        {
            val.mtdCambiaCtrl(frm, frm.pnl_menu.Size, frm.pnl_titulo.Size, objVentas.frm_load(new ctrlVentas()), frm.pnl_waint);
        }

        void btnInicio_Click(object sender, EventArgs e)
        {
            val.mtdCambiaCtrl(frm, frm.pnl_menu.Size, frm.pnl_titulo.Size, pr.frm_load(new ctrlinicio()), frm.pnl_waint);
        }

        void mnuInicio_Click(object sender, EventArgs e)
        {
            val.mtdCambiaCtrl(frm, frm.pnl_menu.Size, frm.pnl_titulo.Size, pr.frm_load(new ctrlinicio()), frm.pnl_waint);
        }

        void mnuProveedores_Click(object sender, EventArgs e)
        {
            Cls_CProveedores f = new Cls_CProveedores();
            f.frm_load();
        }

        void mnuVentas_Click(object sender, EventArgs e)
        {
            val.mtdCambiaCtrl(frm, frm.pnl_menu.Size, frm.pnl_titulo.Size, objVentas.frm_load(new ctrlVentas()), frm.pnl_waint);
        }


        void mnuSalir_Click(object sender, EventArgs e)
        {
            
            frmMessage mgs = new frmMessage("¿DESEAS SALIR DEL SISTEMA?");
            mgs.ShowDialog();
            if (mgs.bol_)
            {
                clsAnim.mtdAnimacionFadeOutM(frm, null);
            }
        }

        void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            int heig = 0;

            while (frm.Height <= 704)
            {
                int boundWidth = Screen.PrimaryScreen.Bounds.Width;
                int boundHeight = Screen.PrimaryScreen.Bounds.Height;
                int x = boundWidth - frm.Width;
                int y = boundHeight - frm.Height;

                if (frm.Opacity >= 1)
                {
                }
                else
                {
                    frm.Opacity = frm.Opacity + 0.009;
                }
                heig = frm.Height + 8;

                if (heig == 712)
                {
                    //heig = frm_menu.Height - 10;
                    for (int i = 0; i <= 1000; i++)
                    {

                        if (frm.Opacity >= 1)
                        {
                            break;
                        }
                        else
                        {
                            frm.Opacity = frm.Opacity + 0.1;
                        }
                    }
                    heig = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
                }

                frm.Location = new System.Drawing.Point(x / 2, y / 2);
                frm.Height = heig;

            }
        }


        public void mtdDatos(string strClave,string strUser,string strPuesto,string rFoto)
        {
            frm.lblClave.Text = strClave;
            frm.lblNombree.Text = strUser;
            frm.lblPuesto.Text = strPuesto;
            frm.imgPerfil.ImageLocation = rFoto;
        }

        void tmrHora_Tick(object sender, EventArgs e)
        {
            frm.lblHora.Text = DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") +":"+ DateTime.Now.Second.ToString("D2");
        }
    }
}
