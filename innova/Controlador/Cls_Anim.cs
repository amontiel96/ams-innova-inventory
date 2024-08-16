using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Vista;

namespace prjFerreteraConstru_K.Controlador
{
    class Cls_Anim
    {
        //Animaciones Form
        frmPrincipal frm = new frmPrincipal();
        Form Frm_;
        Timer Tmr_inicio;
        Action accion;
        //Fade in
        public void mtdAnimacionFadeIn(Form Frm_tmp)
        {
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            Tmr_inicio.Tick += new EventHandler(EvtAFI);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 0;
            Tmr_inicio.Enabled = true;
            //accion = Metodo;
            
        }
        void EvtAFI(object o, EventArgs e)
        {
            if (Frm_.Opacity < .95)
            {
                Frm_.Opacity = Frm_.Opacity + 0.02;
            }
            else
            {
                Tmr_inicio.Enabled = false;
                if (accion != null)
                {
                    accion.Invoke();
                }
            }
        }

        //fade out
        public void mtdAnimacionFadeOut(Form Frm_tmp)
        {
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            Tmr_inicio.Tick += new EventHandler(EvtAFO);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 1;
            Tmr_inicio.Enabled = true;
            //accion = Metodo;
        }
        void EvtAFO(object o, EventArgs e)
        {
            if (Frm_.Opacity > 0)
            {
                Frm_.Opacity = Frm_.Opacity - 0.02;
            }
            else
            {
                Frm_.Close();
            }
        }

        int fin_ = 0;
        public void mtdAnimacionDeslizaAbajoIn(Form Frm_tmp,int fin)
        {
            fin_ = fin;
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            Tmr_inicio.Tick += new EventHandler(EvtAFDAI);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 0;
            Tmr_inicio.Enabled = true;
            //accion = Metodo;
        }
        void EvtAFDAI(object o, EventArgs e)
        {
            if (Frm_.Location.Y < fin_)
            {
                Frm_.Location = new System.Drawing.Point(Frm_.Location.X, Frm_.Location.Y + 10);
                Frm_.Opacity = Frm_.Opacity + 0.02;
            }
            else
            {
                if (Tmr_inicio.Enabled)
                {
                    Tmr_inicio.Enabled = false;
                    Frm_.Enabled = true;
                    if (accion != null)
                    {
                        accion.Invoke();
                    }
                }
            }
        }

        public void mtdAnimacionDeslizaArribaOut(Form Frm_tmp, int fin)
        {
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            fin_ = fin;
            Frm_.Enabled = false;
            Tmr_inicio.Tick += new EventHandler(EvtAFDAO);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 1;
            Tmr_inicio.Enabled = true;
           // accion = Metodo;
        }
        void EvtAFDAO(object o, EventArgs e)
        {
            if (Frm_.Location.Y > fin_)
            {
                Frm_.Location = new System.Drawing.Point(Frm_.Location.X, Frm_.Location.Y - 10);
                Frm_.Opacity = Frm_.Opacity - 0.05;
            }
            else
                Frm_.Close();
        }


        //mensajes

        public void mtdAnimacionDeslizaArribaOutM(Form Frm_tmp,Action Metodo, int fin)
        {
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            fin_ = fin;
            Frm_.Enabled = false;
            Tmr_inicio.Tick += new EventHandler(EvtAFDAOM);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 1;
            Tmr_inicio.Enabled = true;
            accion = Metodo;
        }
        void EvtAFDAOM(object o, EventArgs e)
        {
            if (Frm_.Location.Y > fin_)
            {
                Frm_.Location = new System.Drawing.Point(Frm_.Location.X, Frm_.Location.Y - 10);
                Frm_.Opacity = Frm_.Opacity - 0.05;
            }
            else
                Frm_.Close();
        }


        public void mtdAnimacionDeslizaAbajoInM(Form Frm_tmp,Action Metodo, int fin)
        {
            fin_ = fin;
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            Tmr_inicio.Tick += new EventHandler(EvtAFDAIM);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 0;
            Tmr_inicio.Enabled = true;
            accion = Metodo;
        }
        void EvtAFDAIM(object o, EventArgs e)
        {
            if (Frm_.Location.Y < fin_)
            {
                Frm_.Location = new System.Drawing.Point(Frm_.Location.X, Frm_.Location.Y + 10);
                Frm_.Opacity = Frm_.Opacity + 0.02;
            }
            else
            {
                if (Tmr_inicio.Enabled)
                {
                    Tmr_inicio.Enabled = false;
                    Frm_.Enabled = true;
                    if (accion != null)
                    {
                        accion.Invoke();
                    }
                }
            }
        }


        public void mtdAnimacionFadeOutM(Form Frm_tmp, Action Metodo)
        {
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            Tmr_inicio.Tick += new EventHandler(EvtAFOM);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 1;
            Tmr_inicio.Enabled = true;
            accion = Metodo;
        }
        void EvtAFOM(object o, EventArgs e)
        {
            if (Frm_.Opacity > 0)
            {
                Frm_.Opacity = Frm_.Opacity - 0.02;
                
            }
            else
            {
                Frm_.Close();
            }
        }

        public void mtdAnimacionFadeInM(Form Frm_tmp, Action Metodo)
        {
            Tmr_inicio = new Timer();
            Frm_ = new Form();
            Frm_ = Frm_tmp;
            Tmr_inicio.Tick += new EventHandler(EvtAFIM);
            Tmr_inicio.Interval = 10;
            Frm_.Opacity = 0;
            Tmr_inicio.Enabled = true;
            accion = Metodo;
        }
        void EvtAFIM(object o, EventArgs e)
        {
            if (Frm_.Opacity < .99)
            {
                Frm_.Opacity = Frm_.Opacity + 0.02;
            }
            else
            {
                Tmr_inicio.Enabled = false;
                if (accion != null)
                {
                    accion.Invoke();
                }
            }
        }

    }
}
