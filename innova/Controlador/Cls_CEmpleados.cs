using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using prjFerreteraConstru_K.Vista;
using Tools_ArthurMS.AMS_DataBase;
using prjFerreteraConstru_K.Modelo.DAO;
using prjFerreteraConstru_K.Modelo.VO;
using DevComponents.DotNetBar.Controls;
using System.Data;
using System.IO;


namespace prjFerreteraConstru_K.Controlador
{
    class Cls_CEmpleados
    {
        Cls_Validaciones val = new Cls_Validaciones();
        Cls_Anim ani = new Cls_Anim();
        ctrlEmpleados frm;
        frmPrincipal frme = new frmPrincipal();
        Cls_EmpleadosDAO objEmplDAO = new Cls_EmpleadosDAO();
        Cls_EmpleadosVO dts = new Modelo.VO.Cls_EmpleadosVO();

        DataTable tblResul = new DataTable();
        DataRow fila;
        int idempl = 0,idloguedado=0;



        public Control frm_load(ctrlEmpleados _frm,int idlogueo)
        {
            frm = _frm;
            idloguedado = idlogueo;
            frm = new ctrlEmpleados();
            frm.tblEmpleados.CellClick += tblEmpleados_CellClick;
            frm.btnGuardar.Click += btnGuardar_Click;
            frm.btnEditar.Click += btnEditar_Click;
            frm.btnEliminar.Click += btnEliminar_Click;
            frm.btnFoto.Click += btnFoto_Click;
            frm.btnNuevo.Click += btnNuevo_Click;
            frm.btnCancelar.Click += btnCancelar_Click;
            frm.txtAm.KeyPress += txtAm_KeyPress;
            frm.txtAp.KeyPress += txtAp_KeyPress;
            frm.txtDomicilio.KeyPress += txtDomicilio_KeyPress;
            frm.txtNombre.KeyPress += txtNombre_KeyPress;
            frm.txtPwd.KeyPress += txtPwd_KeyPress; 
            frm.txtTelefono.KeyPress += txtTelefono_KeyPress;
            frm.txtUser.KeyPress += txtUser_KeyPress;
            Obtener_ImagenDefault();

            cargaCombo();
            cargaTabla(idloguedado);
            return frm;
        }

        void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_letras_numeros(e);
        }

        void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_numeros(e);
        }

        void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_letras_numeros(e);
        }

        void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_letras(e);
        }

        void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_letras_numeros(e);
        }

        void txtAp_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_letras(e);
        }

        void txtAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.mtd_solo_letras(e);
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            if (val.mtdPreguntar(4))
            {
                limpiar();
                valCajas(2);
                Botones(3);
            }
            
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {
            Botones(1);
            valCajas(1);
        }
        string Direccion="";
        void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog(); BuscarImagen.Filter = "JPG|*.jpg";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                 Direccion = BuscarImagen.FileName; 
                 frm.imgFoto.ImageLocation = Direccion;
                //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 
                //this.pictureBox1.ImageLocation = textBox1.Text;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }     
        }

        public void mtdResultado()
        {
            tblResul = objEmplDAO.mtd_procesos(dts);
            if (tblResul.Rows.Count > 0)
            {
                fila = tblResul.Rows[0];
                clsMsg.mtdMsg(frme, fila["@Msg"].ToString(), 10);
                cargaTabla(idloguedado);
                limpiar();
                valCajas(2);
                Botones(3);
                Dll_JMS.clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS(fila["@Msg"].ToString());
            }
            else
            {
                clsMsg.mtdMsg(frme, "Error de conexion", 10);
            }
           
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            if (val.mtdVAlidaCajasTextbox(new TextBoxX[] { frm.txtNombre, frm.txtAp, frm.txtAm, frm.txtDomicilio, frm.txtTelefono, frm.txtCorreo, frm.txtUser, frm.txtPwd }))
            {
                if (val.mtdPreguntar(3))
                {
                    dts._opcion = "Eliminar";
                    dts._idempl = idempl;
                    mtdResultado();
                }
            }
             
        }

       

        void btnEditar_Click(object sender, EventArgs e)
        {
            if (val.mtdVAlidaCajasTextbox(new TextBoxX[] { frm.txtNombre, frm.txtAp, frm.txtAm, frm.txtDomicilio, frm.txtTelefono, frm.txtCorreo, frm.txtUser, frm.txtPwd }))
            {
                if (val.IsValidEmail(frm.txtCorreo.Text))
                {
                    if (val.mtdPreguntar(2))
                    {
                        enviar();
                        dts._opcion = "Editar";
                        dts._idempl = idempl;
                        mtdResultado();
                    }
                }
                else
                {
                    clsMsg.mtdMsg(frme, "Mal el formato de correo", 10);
                    Dll_JMS.clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("Mal el formato de correo");
                }
                
                
            }
        }
        
        void btnGuardar_Click(object sender, EventArgs e)
        {
           
            if(val.mtdVAlidaCajasTextbox(new TextBoxX[]{frm.txtNombre,frm.txtAp,frm.txtAm,frm.txtDomicilio,frm.txtTelefono,frm.txtCorreo,frm.txtUser,frm.txtPwd}))
            {
                if (val.IsValidEmail(frm.txtCorreo.Text))
                {
                    if (val.mtdPreguntar(1))
                    {
                        enviar();
                        dts._opcion = "Insertar";
                        mtdResultado();
                    }
                }
                else
                {
                    clsMsg.mtdMsg(frme, "Mal el formato de correo", 10);
                    Dll_JMS.clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS("Mal el formato de correo");
                }
                
                
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
            dts._tipo = Convert.ToInt32(frm.cmbTipo.SelectedValue.ToString());
            dts._user = frm.txtUser.Text;
        }
        string imgDefalt = @"C:\Users\ANONYMUS\Downloads\ferretera\foto_default.jpg";
        public void Obtener_ImagenDefault()
        {
            try
            {
                frm.imgFoto.ImageLocation = imgDefalt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        
        void tblEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                limpiar();
                idempl = Convert.ToInt32(frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[0].Value.ToString());
                frm.txtNombre.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[1].Value.ToString();
                frm.txtAp.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[2].Value.ToString();
                frm.txtAm.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[3].Value.ToString();
                frm.txtDomicilio.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[4].Value.ToString();
                frm.txtTelefono.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[5].Value.ToString();
                frm.txtCorreo.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[6].Value.ToString();
                frm.txtUser.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[7].Value.ToString();
                frm.txtPwd.Text = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[8].Value.ToString();
                string rutaRecibe = frm.tblEmpleados.Rows[frm.tblEmpleados.CurrentRow.Index].Cells[11].Value.ToString();
                //MessageBox.Show(rutaRecibe);
                frm.imgFoto.ImageLocation = rutaRecibe;
                Botones(2);
                valCajas(1);
            }
            catch
            {

            }
            
        }

        public void cargaCombo()
        {
            try
            {
                frm.cmbTipo.DataSource = objEmplDAO.mtd_llenaCombo();
                frm.cmbTipo.DisplayMember = "vchTipo";
                frm.cmbTipo.ValueMember = "intIdTipoUserPK";
            }
            catch
            {

            }
          
        }

        public void cargaTabla(int _id)
        {
            try
            {
                dts._idempl = idloguedado;
                frm.tblEmpleados.DataSource = objEmplDAO.mtd_llenaEmpleados(dts);
                frm.tblEmpleados.Columns[9].Visible = false;
                frm.tblEmpleados.Columns[11].Visible = false;
            }
            catch
            {
                clsMsg.mtdMsg(frme, "No se ha podido establecer conexion con el servidor",10);
            }

            
        }

        public void Botones(int op)
        {
            switch (op)
            {
                case 1://clic nuevo
                    frm.btnNuevo.Enabled = false;
                    frm.btnCancelar.Enabled = true;
                    frm.btnEditar.Enabled = false;
                    frm.btnEliminar.Enabled = false;
                    frm.btnFoto.Enabled = true;
                    frm.btnGuardar.Enabled = true;
                    break;
                case 2://editar o eliminar
                    frm.btnNuevo.Enabled = false;
                    frm.btnCancelar.Enabled = true;
                    frm.btnEditar.Enabled = true;
                    frm.btnEliminar.Enabled = true;
                    frm.btnFoto.Enabled = true;
                    frm.btnGuardar.Enabled = false;
                    break;
                case 3://cancelar
                    frm.btnNuevo.Enabled = true;
                    frm.btnCancelar.Enabled = false;
                    frm.btnEditar.Enabled = false;
                    frm.btnEliminar.Enabled = false;
                    frm.btnFoto.Enabled = false;
                    frm.btnGuardar.Enabled = false;
                    Obtener_ImagenDefault();
                    break;
            }
        }
        public void valCajas(int op)
        {
            switch (op)
            {
                case 1:
                    frm.txtAm.Enabled = true;
                    frm.txtAp.Enabled = true;
                    frm.txtCorreo.Enabled = true;
                    frm.txtDomicilio.Enabled = true;
                    frm.txtNombre.Enabled = true;
                    frm.txtPwd.Enabled = true;
                    frm.txtTelefono.Enabled = true;
                    frm.txtUser.Enabled = true;
                    frm.txtNombre.Focus();
                    break;
                case 2:
                    frm.txtAm.Enabled = false;
                    frm.txtAp.Enabled = false;
                    frm.txtCorreo.Enabled = false;
                    frm.txtDomicilio.Enabled = false;
                    frm.txtNombre.Enabled = false;
                    frm.txtPwd.Enabled = false;
                    frm.txtTelefono.Enabled = false;
                    frm.txtUser.Enabled = false;
                    break;
            }
           
        }

        public void limpiar()
        {
            frm.txtAm.Clear();
            frm.txtAp.Clear();
            frm.txtCorreo.Clear();
            frm.txtDomicilio.Clear();
            frm.txtNombre.Clear();
            frm.txtPwd.Clear();
            frm.txtTelefono.Clear();
            frm.txtUser.Clear();
        }
    }
}
