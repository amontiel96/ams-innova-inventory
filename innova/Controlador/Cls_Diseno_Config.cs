using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.VisualBasic.PowerPacks;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_Diseno_Config
    {
        #region nmueve forms
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static void Mtdo_mueve_form(IntPtr frm)
        {
            ReleaseCapture();
            SendMessage(frm, 0X112, 0Xf012, 0);
        }
        #endregion
        #region ubicacion borde_rec
        public static void ubica_rec_borde(RectangleShape rec, Form frm)
        {
            rec.Location = new Point(0, 0);
            rec.Width = frm.Width;
            rec.Height = frm.Height + 1;
        }

        #endregion

        #region habre_hacia el centro
        public static void cierra_(Form acerrar, string entrada_salida)
        {
            if (entrada_salida != "salida")
            {
                int heig = 0;

                while (acerrar.Height <= 768)
                {
                    int boundWidth = Screen.PrimaryScreen.Bounds.Width;
                    int boundHeight = Screen.PrimaryScreen.Bounds.Height;
                    int x = boundWidth - acerrar.Width;
                    int y = boundHeight - acerrar.Height;
                    if (acerrar.Opacity >= 1)
                    {
                    }
                    else
                    {
                        acerrar.Opacity = acerrar.Opacity + 0.009;
                    }
                    heig = acerrar.Height + 10;
                    if (heig == 772)
                    {
                        for (int i = 0; i <= 1000; i++)
                        {

                            if (acerrar.Opacity >= 1)
                            {
                                break;
                            }
                            else
                            {
                                acerrar.Opacity = acerrar.Opacity + 0.1;
                            }
                        }
                        heig = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
                    }

                    acerrar.Location = new Point(x / 2, y / 2);
                    acerrar.Height = heig;
                }

            }
            else
            {
                int heig = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
                while (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height <= heig)
                {
                    int boundWidth = Screen.PrimaryScreen.Bounds.Width;
                    int boundHeight = Screen.PrimaryScreen.Bounds.Height;
                    int x = boundWidth - acerrar.Width;
                    int y = boundHeight - acerrar.Height;
                    if (acerrar.Opacity <= 1)
                    {
                        acerrar.Opacity = acerrar.Opacity - 0.009;
                        
                    }
                    else
                    {
                    }
                    heig = acerrar.Height - 10;
                    if (heig <= 0)
                    {
                        heig = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;

                        Application.Exit();
                        break;
                    }
                    acerrar.Location = new Point(x / 2, y / 2);
                    acerrar.Height = heig;
                }

            }

        }
        #endregion

        #region mensajes emergentes
        public static void mtd_tipmsj(Cls_Diseno_Config.mtd_tipo_msj_emergente opc_msj, string msj)
        {
            int tipo;
            if (opc_msj == Cls_Diseno_Config.mtd_tipo_msj_emergente.peligro_naranja)
                tipo = 1;
            else if (opc_msj == Cls_Diseno_Config.mtd_tipo_msj_emergente.amarillo_alerta)
                tipo = 2;
            else if (opc_msj == Cls_Diseno_Config.mtd_tipo_msj_emergente.verde_binvenida)
                tipo = 3;
            else
                tipo = 4;
            msj_emrgnt(tipo, msj);
        }

        public enum mtd_tipo_msj_emergente : int
        {
            peligro_naranja = 1,
            amarillo_alerta = 2,
            azul_corectamente = 3,
            verde_binvenida = 4
        }

        public static void msj_emrgnt(int tipo, string msj)
        {
            //1=peligro-naranja
            //2=amarill-alerta
            //3-azul-corectamente
            //4=verde-binvenida
            //Frm_msjs mensaj = new Frm_msjs();
            //if (tipo == 1)
            //{
            //    mensaj.pictureBox1.Image = Properties.Resources.Peligro_msj_emergente;
            //    mensaj.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //    mensaj.pnl_titulo.BackColor = Color.FromArgb(247, 99, 12);
            //    mensaj.rect_borde.BorderColor = Color.FromArgb(247, 99, 12);
            //}
            //else
            //    if (tipo == 2)
            //    {
            //        mensaj.pictureBox1.Image = Properties.Resources.alerta_msj;
            //        mensaj.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //        mensaj.pnl_titulo.BackColor = Color.FromArgb(252, 225, 0);
            //        mensaj.rect_borde.BorderColor = Color.FromArgb(252, 225, 0);
            //        mensaj.lbl_titulo.ForeColor = Color.FromArgb(0, 0, 0, 0);
            //    }
            //    else
            //        if (tipo == 3)
            //        {
            //            mensaj.pictureBox1.Image = Properties.Resources.Atencion_msj;
            //            mensaj.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //            mensaj.pnl_titulo.BackColor = Color.FromArgb(0, 122, 204);
            //            mensaj.rect_borde.BorderColor = Color.FromArgb(0, 122, 204);
            //        }
            //        else
            //            if (tipo == 4)
            //            {
            //                mensaj.pictureBox1.Image = Properties.Resources.refresh;
            //                mensaj.pnl_titulo.BackColor = Color.FromArgb(202, 81, 0);
            //                mensaj.rect_borde.BorderColor = Color.FromArgb(202, 81, 0);
            //            }
            //mensaj.lbl_msj.Text = msj;
            //Cls_ProcesosMsjEmergente msje = new Cls_ProcesosMsjEmergente(mensaj);
            //mensaj.Show();
        }
        #endregion

        #region checa_tipo_msj
        public static string mtd_msj_verfica_tipo(string msj)
        {
            string res = "";
            char[] acaracteres = msj.ToCharArray();
            res = ("" + acaracteres[0]);
            return res;
        }

        #endregion

        #region checa_msj
        public static string mtd_msj_verfica(string msj)
        {
            string res = "";
            char[] acaracteres = msj.ToCharArray();
            int larg = acaracteres.Length - 1;
            for (int x = 1; acaracteres.Length >= x; x++)
            {
                if (larg == x)
                {
                    break;
                }
                else
                {
                    res = res + "" + acaracteres[x];
                }

            }
            return res;
        }

        #endregion

        #region formulario-principa-panel

        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);
        [Flags]


        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000,

        }


        public static void efecto_abre(Form frm)
        {
            AnimateWindow(frm.Handle, 450, AnimateWindowFlags.AW_HOR_NEGATIVE);
        }
        public static void efecto_cierra(Form frm)
        {
            AnimateWindow(frm.Handle, 450, AnimateWindowFlags.AW_HOR_POSITIVE | AnimateWindowFlags.AW_HIDE);
            frm.Close();
        }
        public static void efecto_cierra_app(Form frm)
        {
            //AnimateWindow(frm.Handle, 450, AnimateWindowFlags.AW_CENTER | AnimateWindowFlags.AW_HIDE);
            AnimateWindow(frm.Handle, 500, AnimateWindowFlags.AW_VER_POSITIVE | AnimateWindowFlags.AW_HIDE);
            Application.Exit();
        }

        public static void efecto_abre_img(PictureBox ptrbx)
        {
            AnimateWindow(ptrbx.Handle, 700, AnimateWindowFlags.AW_CENTER | AnimateWindowFlags.AW_HIDE);
        }
        public static void efecto_cierra_pnl(Panel pnl)
        {
            AnimateWindow(pnl.Handle, 450, AnimateWindowFlags.AW_HOR_POSITIVE | AnimateWindowFlags.AW_HIDE);
            //pnl.Hide();
            //pnl.Visible = false;
            //pnl.Width = 0;
            //pnl.Height = 0;
        }
        public static void efecto_Abre_pnl(Panel pnl)
        {

            AnimateWindow(pnl.Handle, 450, AnimateWindowFlags.AW_HOR_NEGATIVE | AnimateWindowFlags.AW_ACTIVATE);
            //pnl.Height = 280;
            //pnl.Width = 758;
            //pnl.Visible = true;
            //pnl.Show();

        }
        public static void efecto_cierra_temp(Form frm)
        {
            AnimateWindow(frm.Handle, 450, AnimateWindowFlags.AW_HOR_POSITIVE | AnimateWindowFlags.AW_HIDE);
            frm.Hide();
        }
        public static void efecto_abre_temp(Form frm)
        {
            AnimateWindow(frm.Handle, 450, AnimateWindowFlags.AW_HOR_NEGATIVE);
            frm.Show();
        }
        #endregion

        #region login-bloqueo

        public static bool cierra_tem1 { get; set; }
        //public static cls_prop_gral gral_datNotific { get; set; }
        public static void bloqa_log_notif(int tipo, string msj)
        {

            //Frm_Bloqueo bloq = new Frm_Bloqueo();


            ////1-login
            ////2-bloqueo
            ////3-notificacion-salir
            ////4-notificacion-eliminar
            ////5-notificacion-

            //switch (tipo)
            //{
            //    case 1:
            //        {

            //            //bloq.lbl_titulo_Login.Text = "Login";
            //            //bloq.pnl_notificacion.Visible = false;
            //            //bloq.pnl_notificacion.Visible = false;
            //            //bloq.pnl_titulo_cerrar.Visible = false;
            //            //bloq.rect_borde.Visible = false;
            //            //bloq.Show();
            //            //               Vista.Frm_Bloqueo vista = new Vista.Frm_Bloqueo();
            //            //controlador
            //            //                 Controlador.Cls_ProcesosLoginBloqueo inicio = new Controlador.Cls_ProcesosLoginBloqueo(vista);

            //            Vista.Frm_splash vista = new Vista.Frm_splash();
            //            //controlador
            //            Controlador.Cls_ProcesosSplash inicio = new Controlador.Cls_ProcesosSplash(vista);



            //            break;
            //        }
            //    case 2:
            //        {

            //            bloq.lbl_titulo_Login.Text = "Bloqueo";
            //            bloq.pnl_notificacion.Visible = false;
            //            bloq.pnl_notificacion.Visible = false;
            //            //bloq.pnl_titulo_cerrar.Visible = false;
            //            bloq.rect_borde.Visible = false;
            //            //bloq.lbl_titul_notificacion.Visible = false;
            //            //bloq.gral_datos = gral_datNotific;
            //            bloq.ShowDialog();
            //            break;
            //        }
            //    case 3:
            //        {
            //            cierra_tem1 = false;
            //            bloq.pnl_login.Visible = false;
            //            bloq.pnl_notificacion.Visible = true;
            //            if (msj == "")
            //            {
            //                bloq.lbl_msj_notif.Text = "esta seguro de cerrar el programa";
            //            }
            //            else
            //            {
            //                bloq.lbl_msj_notif.Text = msj;
            //            }
            //            bloq.pictureBox1.Image = Properties.Resources.Atencion_msj;
            //            bloq.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //            bloq.ShowDialog();
            //            //frm_Menu menu = new frm_Menu();

            //            //if (bloq.cierra_tem)
            //            // {
            //            //   bloq.FindForm();
            //            // cierra_tem1 = bloq.cierra_tem;

            //            //}
            //            break;
            //        }
            //    case 4:
            //        {

            //            bloq.pnl_login.Visible = false;
            //            bloq.pnl_notificacion.Visible = true;
            //            bloq.lbl_msj_notif.Text = "Esta seguro de eliminar " + msj;
            //            bloq.pictureBox1.Image = Properties.Resources.Peligro_msj_emergente;
            //            bloq.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //            bloq.ShowDialog();
            //            //if (bloq.cierra_tem)
            //            //{
            //            //    bloq.FindForm();
            //            //    cierra_tem1 = bloq.cierra_tem;

            //            //}
            //            break;
            //        }
            //    case 5:
            //        {
            //            cierra_tem1 = false;
            //            bloq.pnl_login.Visible = false;
            //            bloq.pnl_notificacion.Visible = true;
            //            bloq.lbl_msj_notif.Text = "esta seguro de cerrar sesion";
            //            bloq.pictureBox1.Image = Properties.Resources.Atencion;
            //            bloq.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //            bloq.ShowDialog();

            //            //frm_Menu menu = new frm_Menu();

            //            //if (bloq.cierra_tem)
            //            //{
            //            //    menu.Close();
            //            //    menu.Hide();
            //            //    bloq.FindForm();
            //            //    cierra_tem1 = bloq.cierra_tem;
            //            //    bloqa_log_notif(1, "Login");

            //            //}
            //            break;

            //        }
            //}



        }


        #endregion

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public static void ubicacion_form(Form frm)
        {
            frm.Location = new Point(250, 90);
        }

        public static void ubicacion_form_grande(Form frm)
        {
            frm.Location = new Point(75, 85);
        }

        public static string mtd_fecha()
        {

            string strg_a, strg_m, strg_d, strg_h, strg_mm, strg_s, fecha_com;
            strg_a = DateTime.Now.Year.ToString();
            strg_m = DateTime.Now.Month.ToString();
            strg_d = DateTime.Now.Day.ToString();
            strg_h = DateTime.Now.Hour.ToString();
            strg_mm = DateTime.Now.Minute.ToString();
            strg_s = DateTime.Now.Second.ToString();
            if (strg_m.Length == 1)
            {
                strg_m = 0 + strg_m;
            }
            if (strg_d.Length == 1)
            {
                strg_d = 0 + strg_d;
            }
            return fecha_com = strg_a + "-" + strg_m + "-" + strg_d;// + " " + strg_h + ":" + strg_mm + ":" + strg_s;
        }
    }
}
