using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using DevComponents.DotNetBar.Controls;
using prjFerreteraConstru_K.Modelo.DAO;
using prjFerreteraConstru_K.Modelo.VO;
using prjFerreteraConstru_K.Vista;
using System.Data;


namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CPerfil
    {
        frmPerfil frm = new frmPerfil();
        Cls_EmpleadosDAO mtd = new Cls_EmpleadosDAO();
        Cls_EmpleadosVO dts = new Modelo.VO.Cls_EmpleadosVO();
        Cls_Validaciones val = new Cls_Validaciones();
        Cls_Anim anim = new Cls_Anim();
        DataTable tblResul = new DataTable();
        DataRow fila;
        int ideml=0,idtipo=0;
        frmPrincipal fmenu;
        public void frm_load(string _id,frmPrincipal menu)
        {
            fmenu = menu;
            ideml = Convert.ToInt32(_id);
            cargaDatos(ideml);
            Cls_Diseno_Config.efecto_abre(frm);
            frm.imgFoto.Click += imgFoto_Click;
            frm.btnSalir.Click += btnSalir_Click;
            frm.btnConfirmar.Click += btnConfirmar_Click;
           
            frm.Opacity = 50;
            frm.ShowDialog();
        }
        string Direccion = "";
        void imgFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog(); BuscarImagen.Filter = "JPG|*.jpg";
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                Direccion = BuscarImagen.FileName;
                frm.imgFoto.ImageLocation = Direccion;
                
            }   
        }
        public void cargaDatos(int id)
        {
            try
            {
                dts._idempl = id;

                tblResul = mtd.mtd_Consulta(dts);
                if (tblResul.Rows.Count > 0)
                {
                    fila = tblResul.Rows[0];
                    frm.txtAm.Text = fila["am"].ToString();
                    frm.txtAp.Text = fila["ap"].ToString();
                    frm.txtCorreo.Text = fila["correo"].ToString();
                    frm.txtDomicilio.Text = fila["domicilio"].ToString();
                    frm.txtNombre.Text = fila["nombre"].ToString();
                    frm.txtPwd.Text = fila["pwd"].ToString();
                    frm.txtTelefono.Text = fila["tel"].ToString();
                    frm.txtUser.Text = fila["user"].ToString();
                    frm.imgFoto.ImageLocation = fila["foto"].ToString();
                    idtipo = Convert.ToInt32(fila["tipo"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (val.mtdVAlidaCajasTextbox(new TextBoxX[] { frm.txtNombre, frm.txtAp, frm.txtAm, frm.txtDomicilio, frm.txtTelefono, frm.txtCorreo, frm.txtUser, frm.txtPwd }))
            {
                if (val.IsValidEmail(frm.txtCorreo.Text))
                {
                    if (val.mtdPreguntar(2))
                    {
                        enviar();
                        dts._opcion = "Editar";
                        dts._idempl = ideml;
                        mtdResultado();
                        
                    }
                }
                else
                {
                    clsMsg.mtdMsg(frm, "Mal el formato de correo", 10);
                    Dll_JMS.clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("Mal el formato de correo");
                }


            }
        }

        public void mtdResultado()
        {
            tblResul = mtd.mtd_procesos(dts);
            if (tblResul.Rows.Count > 0)
            {
                fila = tblResul.Rows[0];
                clsMsg.mtdMsg(frm, fila["@Msg"].ToString(), 10);
                if (fila["@Msg"].ToString() == "Datos Modificados")
                {
                    fmenu.imgPerfil.ImageLocation = ruta;
                }
                Dll_JMS.clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS(fila["@Msg"].ToString());
                cargaDatos(ideml);
                
            }
            else
            {
                clsMsg.mtdMsg(frm, "Error de conexion", 10);
            }

        }

        string ruta = "";
        public void enviar()
        {
            ruta = frm.imgFoto.ImageLocation.ToString();
            ruta = ruta.Replace(@"\", @"\\");
            dts._nombre = frm.txtNombre.Text;
            dts._am = frm.txtAm.Text;
            dts._ap = frm.txtAp.Text;
            dts._correo = frm.txtCorreo.Text;
            dts._domicilio = frm.txtDomicilio.Text;
            dts._foto = ruta;
            dts._pwd = frm.txtPwd.Text;
            dts._telefono = frm.txtTelefono.Text;
            dts._user = frm.txtUser.Text;
            dts._tipo = idtipo;
        }
        void btnSalir_Click(object sender, EventArgs e)
        {
            anim.mtdAnimacionDeslizaArribaOut(frm, 5);
        }
    }
}
