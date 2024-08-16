using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFerreteraConstru_K.Vista
{
    public partial class frmMsg : Form
    {

        string msg_;
        private Form Frm_;
        private Timer Tmr_tmp = new Timer();
        public int Contador = 0;
        private int Lgu = 0;
        public frmMsg(Form Frm_tmp, string msg, int lugar)
        {
            Frm_ = new Form();
            Tmr_tmp = new Timer();
            InitializeComponent();
            msg_ = msg;
            Frm_ = Frm_tmp;        
            Lgu = lugar;
        }

        private void frmMsg_Load(object sender, EventArgs e)
        {
            this.Lbl_msg.Text = msg_;
            this.Click += new EventHandler(EvtCerrar);
            this.Lbl_msg.Click += new EventHandler(EvtCerrar);
            
            Contador = 0;
            if (Lgu == 0)
                this.Location = new System.Drawing.Point(Frm_.Location.X + Frm_.Width - this.Width - 7, Frm_.Location.Y);
            else
                this.Location = new System.Drawing.Point(Frm_.Location.X + Frm_.Width - this.Width - 1, Frm_.Location.Y + this.Height - 2);
            this.Tmr_tmp.Interval = 100;
            this.Tmr_tmp.Tick += new EventHandler(EvtTicTak);
            this.Tmr_tmp.Enabled = true;
        }
        void EvtCerrar(object o, EventArgs e)
        {
            Contador = 3000;
        }
        void EvtTicTak(object o, EventArgs e)
        {
            if (Contador == 3000)
            {
                this.Close();
            }
            Contador += 100;
        }
    }
}
