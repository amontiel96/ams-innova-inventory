using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Vista;
using prjFerreteraConstru_K.Modelo.DAO;
using prjFerreteraConstru_K.Modelo.VO;
using System.Data;
using EcoRecycler.Skin;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CLogin
    {
        frmLogin frm = new frmLogin();
        Cls_LoginDAO objDAO = new Cls_LoginDAO();
        Cls_LoginVO objVO = new Cls_LoginVO();
        Cls_Diseno_Config dise = new Cls_Diseno_Config();
        Cls_Anim ani = new Cls_Anim();
        Cls_Validaciones val = new Cls_Validaciones();



        int tiempo = 0;
        DataTable tblVerifica = new DataTable();
        DataRow fila;
        public void frm_load()
        {
           
            ani.mtdAnimacionFadeInM(frm, null);
            frm.btnAceptar.Click += btnAceptar_Click;
            frm.tmrVerifica.Tick += tmrVerifica_Tick;
           
            Application.EnableVisualStyles();
            frm.ShowDialog();
        }

        void tmrEfecto_Tick(object sender, EventArgs e)
        {
            //efecto++;
            //frm.Opacity += 0.005;
            //if (efecto == 300)
            //{
            //    frm.tmrEfecto.Stop();

            //}
        }

        void tmrVerifica_Tick(object sender, EventArgs e)
        {
            
            tiempo++;
            if (tiempo == 110)
            {
                frm.tmrVerifica.Stop();

               
                tblVerifica = objDAO.verifica(objVO);

                if (tblVerifica.Rows.Count > 0)
                {
                    fila = tblVerifica.Rows[0];
                    
                    frm.Hide();
                    Cls_CPrincipal objMenu = new Cls_CPrincipal();
                    objMenu.mtdDatos(fila["intIdDatosPK"].ToString(), fila["Nombre"].ToString(), fila["vchTipo"].ToString(),fila["foto"].ToString());
                    objMenu.frm_load();
                }
                else
                {
                    frm.imgProgres.Visible = false;
                    frm.btnAceptar.Visible = true;
                    clsMsg.mtdMsg(frm, "Datos erroneos", 10);
                    
                }

            }
        }

        void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                
                tiempo = 0;
                mtd_EnviarParams();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

      
        public void mtd_EnviarParams()
        {
           if(val.mtdVAlidaCajas(new TextBox[]{frm.txtUser,frm.txtPwd}))
           {
               objVO.setUser(frm.txtUser.Text);
               objVO.setPwd(frm.txtPwd.Text);
               frm.btnAceptar.Visible = false;
               frm.imgProgres.Visible = true;
               frm.tmrVerifica.Start();
           }
            
        }
    }
}
