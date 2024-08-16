using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using prjFerreteraConstru_K.Model.DAO;
using prjFerreteraConstru_K.Modelo.Conexion;
using prjFerreteraConstru_K.Model.VO;

namespace prjFerreteraConstru_K.Model.DAO
{
    class Cls_MarcaDAO
    {
        public DataTable mtd_SelectTable()
        {
            return cls_conexion.Instancia().consultas("select * from vw_Marcas");
        }

        public DataTable mtd_Process(Cls_MarcaVO dts)
        {
            return cls_conexion.Instancia().consultas("CALL sp_Marcas('" + dts._opcion + "'," + dts._id + ",'" + dts._name + "');");
        }
    }
}
