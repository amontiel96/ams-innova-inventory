using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Tools_ArthurMS.AMS_DataBase;
using prjFerreteraConstru_K.Modelo.VO;
using prjFerreteraConstru_K.Modelo.Conexion;



namespace prjFerreteraConstru_K.Modelo.DAO
{
    class Cls_EmpleadosDAO
    {
        public DataTable mtd_llenaEmpleados(Cls_EmpleadosVO dts)
        {
            return cls_conexion.Instancia().consultas("CALL sp_SelEmpleados(" + dts._idempl + ");");
        }

        public DataTable mtd_procesos(Cls_EmpleadosVO dts)
        {
            return cls_conexion.Instancia().consultas("CALL sp_procesosEmpleados('" + dts._opcion + "','" + dts._nombre + "','" + dts._ap + "','" + dts._am + "','" + dts._domicilio + "','" + dts._telefono + "','" + dts._correo + "'," + dts._idempl + ",'" + dts._user + "','" + dts._pwd + "','" + dts._foto + "'," + dts._tipo + ");");
        }
        public DataTable mtd_Consulta(Cls_EmpleadosVO dts)
        {
            return cls_conexion.Instancia().consultas("CALL sp_SelPerfil(" + dts._idempl + ");");
        }
        public DataTable mtd_llenaCombo()
        {
            return cls_conexion.Instancia().consultas("SELECT * FROM tbl_tipo_user");
        }
    }
}
