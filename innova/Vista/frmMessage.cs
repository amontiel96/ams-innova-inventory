using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFerreteraConstru_K.Controlador;
using Dll_JMS;

namespace prjFerreteraConstru_K.Vista
{
    public partial class frmMessage : Form
    {
        public bool bol_;
        private Cls_Anim clsAnim;
        private string StrMensaje;

        public frmMessage(string msg)
        {
            InitializeComponent();
            StrMensaje = msg;
            clsAnim = new Cls_Anim();
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {

            bol_ = true;
            clsAnim.mtdAnimacionDeslizaArribaOutM(this, null, 30);
            //clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("good bye");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("Accion cancelada");
            bol_ = false;
            this.Opacity = .50;
            clsAnim.mtdAnimacionDeslizaArribaOutM(this, null, 30);
           
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
           // clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("¿deseas salir del sistema?");
            lblMensaje.Text = StrMensaje;

            this.Location = new Point(SystemInformation.PrimaryMonitorSize.Width / 2 - this.Width / 2, 20);
            clsAnim.mtdAnimacionDeslizaAbajoInM(this, termino, SystemInformation.PrimaryMonitorSize.Height / 3);
            //clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("desea salir del sistema");
        }
        void termino()
        {
            this.Opacity = 1;
        }

        private void lblMensaje_MouseDown(object sender, MouseEventArgs e)
        {
            Cls_Validaciones.mtdMoverForm(this.Handle);
        }
    }
}
