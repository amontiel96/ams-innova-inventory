using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tools_ArthurMS.AMS_DataBase;
using prjFerreteraConstru_K.Modelo.VO;
using System.Data;
using prjFerreteraConstru_K.Modelo.Conexion;

using Tools_ArthurMS.AMS_OrderArray;


namespace prjFerreteraConstru_K.Modelo.DAO
{
    class Cls_LoginDAO
    {
        /*verifica que exista el usuario*/
        public DataTable verifica(Cls_LoginVO dts)
        {
            return cls_conexion.Instancia().consultas("CALL sp_selLogin('" + dts.getUser() + "','" + dts.getPwd() + "');");
        }

    }
}
