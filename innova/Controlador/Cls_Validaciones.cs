using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing;
using EcoRecycler.Skin;
using DevComponents.DotNetBar.Controls;
using prjFerreteraConstru_K.Vista;
using System.Text.RegularExpressions;
using System.Globalization;


namespace prjFerreteraConstru_K.Controlador
{
    class Cls_Validaciones
    {
        frmPrincipal frm = new frmPrincipal();
        //Mover Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]//importar metodos del dll
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]//importar metodos del dll
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public static void mtdMoverForm(IntPtr frm)
        {
            ReleaseCapture();
            SendMessage(frm, 0x112, 0xf012, 0);
        }

        public static string ConvierteMes(int mes)
        {
            string Mes = "";
            switch (mes)
            {
                case 1:
                    Mes = "Enero";
                    break;
                case 2:
                    Mes = "Febrero";
                    break;
                case 3:
                    Mes = "Marzo";
                    break;
                case 4:
                    Mes = "Abril";
                    break;
                case 5:
                    Mes = "Mayo";
                    break;
                case 6:
                    Mes = "Junio";
                    break;
                case 7:
                    Mes = "Julio";
                    break;
                case 8:
                    Mes = "Agosto";
                    break;
                case 9:
                    Mes = "Septiembre";
                    break;
                case 10:
                    Mes = "Octubre";
                    break;
                case 11:
                    Mes = "Noviembre";
                    break;
                case 12:
                    Mes = "Diciembre";
                    break;
            }
            return Mes;
        }
        public static string getSignature(string filename, string algorithm)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(algorithm);
            FileStream fs = System.IO.File.OpenRead(filename);
            Byte[] Data = hashAlgorithm.ComputeHash(fs);
            fs.Close();
            return BitConverter.ToString(Data).Replace("-", "");
        }

        //metodo que solo permite insertar numeros 
        public void mtd_solo_numeros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
            { }
            else
            {
                e.KeyChar = (char)Keys.None;
            }
        }

        //inserta solo letras
        public void mtd_solo_letras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //solo letras insertas letras o numeros, no inserta simbolos
        public void mtd_solo_letras_numeros(KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            { e.KeyChar = (char)Keys.None; }
            else
            {

            }
        }
        //inserta solo nimeros con un solo punto decimal este puede servir para las cantidades
        public void mtd_numero_con_decimal(string texto, KeyPressEventArgs e)
        {

            if (char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back || e.KeyChar == '.')
            {
                if (texto.Contains(".") && e.KeyChar == '.')
                {
                    e.KeyChar = (char)Keys.None;
                }
            }
            else
            {
                e.KeyChar = (char)Keys.None;
            }
        }

        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private Control Ctrl_;
        private Control Ctrl_tmp;
        private Size menu;
        private Size titulo;
        private bool bandera = true;
        private bool ejecutando = false;
        private Form Form_;
        private Timer Tmr_tmp;
        private Control accion;

        string texto;
        public bool mtdPreguntar(int op)
        {
            bool regresaRespuesta = false;
            
           if(op==1)//guardar
           {
               texto = "¿DESEAS GUARDAR ESTE REGISTRO?";
           }else if(op==2)
           {
               texto = "¿DESEAS MODIFICAR LOS DATOS DE ESTE REGISTRO";
           }else if(op==3)
           {
               texto = "¿DESEAS ELIMINAR ESTE REGISTRO?";
           }else if(op==4)
           {
               texto = "¿DESEAS CANCELAR ESTE PROCESO?";
           }
            frmMessage mgs = new frmMessage(texto);
            mgs.ShowDialog();
            if (mgs.bol_)
            {
                regresaRespuesta = true;
            }
            return regresaRespuesta;
        }

        void EvtAnim(object o, EventArgs e)
        {
            if (bandera)
            {
                if (Ctrl_.Location.Y > titulo.Height + 10)
                {
                    Ctrl_.Location = new Point(Ctrl_.Location.X, Ctrl_.Location.Y - 20);
                }
                else
                {
                    Tmr_tmp.Stop();
                    Tmr_tmp.Enabled = false;
                    ejecutando = false;
                }
            }
            else
            {
                if (Ctrl_.Location.Y > -400)
                {
                    Ctrl_.Location = new Point(Ctrl_.Location.X, Ctrl_.Location.Y - 20);
                }
                else
                {
                    Form_.Controls.Remove(Ctrl_);

                    Ctrl_ = new Control();
                    Ctrl_ = Ctrl_tmp;
                    bandera = true;

                    Ctrl_.ClientSize = new System.Drawing.Size(Form_.Width - (menu.Width + 20), Form_.Height - (titulo.Height + 10));
                    Ctrl_.Location = new Point(menu.Width + 10, 400);
                    Form_.Controls.Add(Ctrl_);
                    accion.Hide();
                }
            }
        }

        public void mtdCambiaCtrl(Form Frm_, Size CtrlMenu, Size CtrlTitulo, Control ctrlAgregar, Control barra)
        {
            if (!ejecutando)
            {
                Tmr_tmp = new Timer();
                ejecutando = true;
                Form_ = Frm_;
                menu = CtrlMenu;
                titulo = CtrlTitulo;
                Tmr_tmp.Interval = 10;
                accion = barra;
                barra.Visible = true;

                if (Ctrl_ == null)
                {
                    Ctrl_ = new Control();
                    Ctrl_ = ctrlAgregar;
                    Ctrl_.ClientSize = new System.Drawing.Size(Frm_.Width - (CtrlMenu.Width + 20), Frm_.Height - (CtrlTitulo.Height + 10));
                    Ctrl_.Location = new Point(CtrlMenu.Width + 10, 400);
                    Frm_.Controls.Add(Ctrl_);
                    Tmr_tmp.Tick += new EventHandler(EvtAnim);
                    accion.Hide();
                }
                else
                {
                    if (!(Ctrl_.Name == ctrlAgregar.Name))
                    {
                        Ctrl_tmp = ctrlAgregar;
                        bandera = false;
                        Ctrl_.Height = Ctrl_.Height / 2;
                        Tmr_tmp.Tick += new EventHandler(EvtAnim);

                    }
                    else
                    {
                        ejecutando = false;
                        Tmr_tmp.Dispose();
                        accion.Hide();
                    }
                }
                Tmr_tmp.Enabled = true;
                Tmr_tmp.Start();
            }
        }

    
        bool bien = false;
        public bool mtdVAlidaCajas(TxtBox[] ctrl,Form frm)
        {
            bien = true;
           string mensaje;
            for (int i = 0; i < ctrl.Length; i++)
            {
                ctrl[i].TextChngTxtBox();
                ctrl[i].forecolor(System.Drawing.Color.FromArgb(72, 72, 72));
                if (ctrl[i].Text == "")
                {
                    ctrl[i].Focus();
                    mensaje = ctrl[i].AccessibleDescription;
                    clsMsg.mtdMsg(frm,mensaje, 10);
                    bien = false;
                    break;
                }
            }
            return bien;
            
        }

        public bool mtdVAlidaCajas(TextBox[] ctrl)
        {
            bien = true;
            string mensaje;
            for (int i = 0; i < ctrl.Length; i++)
            {

                if (ctrl[i].Text == "")
                {
                    ctrl[i].Focus();
                    mensaje = ctrl[i].AccessibleDescription;
                    clsMsg.mtdMsg(frm, mensaje, 10);
                    bien = false;
                    break;
                }
            }
            return bien;

        }


        public bool mtdVAlidaCajasTextbox(TextBoxX[] ctrl)
        {
            bien = true;
            string mensaje;
            for (int i = 0; i < ctrl.Length; i++)
            {
                if (ctrl[i].Text == "")
                {
                    ctrl[i].Focus();
                    
                    mensaje = ctrl[i].AccessibleDescription;
                    Dll_JMS.clsMultimedia.instancia_Multimedia().MtdLeerTextSpeed_JMS(mensaje);
                    clsMsg.mtdMsg(frm, mensaje, 10);

                    bien = false;
                    break;
                }
                
            }
            return bien;

        }



        //public static void CrearPdf(string NombreArchivo, string NombreImagen, float escala)
        //{
        //    Document document = new Document();
        //    using (var stream = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
        //    {
        //        PdfWriter.GetInstance(document, stream);
        //        document.Open();
        //        using (var imageStream = new FileStream(NombreImagen, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        {
        //            var image = iTextSharp.text.Image.GetInstance(imageStream);
        //            image.ScalePercent(escala);
        //            document.Add(image);
        //        }
        //        document.Close();
        //    }
        //    System.Diagnostics.Process.Start(NombreArchivo);
        //}

        public byte[] Imagen_A_ByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image ByteArray_A_Imagen(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
