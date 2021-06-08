using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{
    public class ClsConexionDinamica
    {
        private int IdEmpresa = 0;
        public SqlConnection SqlConexion { get; set; }

        public ClsConexionDinamica(SqlConnection Con, int IdEmp)
        {
            if (Con == null || (Con != null && Con.State == System.Data.ConnectionState.Closed))
            {
                IdEmpresa = IdEmp;
                SqlConexion = Con;
                GetConnectionString();
            }
            else
                SqlConexion = Con;
        }
        public SqlConnection ReconectarSql()
        {
            SqlConexion = null;
            GetConnectionString();
            return SqlConexion;
        }
        public void GetConnectionString()
        {
            var varConec = ConfigurationManager.ConnectionStrings["ConexionCajas01"];
            if (varConec != null)
            {
                string BdName = BuscarBaseDatosEmpresa();

                if (BdName != "")
                {
                    string CadenaConexion = ArmarCadena(BdName, varConec.ToString());
                    CrearConexion(CadenaConexion);
                }
            }
        }
        private string ArmarCadena(string BaseDatos, string CadenaCon)
        {
            string Servidor = "";
            string Usuario = "";
            string strConexionSAC = "";
            string Pass = "";
            //metodo para armar la cadena de conexion apartir del nombre de la base de datos de la empresa en cuestion
            string strConPosBI = CadenaCon;
            strConPosBI = strConPosBI.Replace("Data Source=", "");
            strConPosBI = strConPosBI.Replace("Initial Catalog=", "");
            strConPosBI = strConPosBI.Replace("User ID=", "");
            strConPosBI = strConPosBI.Replace("Password=", "");

            string[] strArray = strConPosBI.Split(';');
            if (strArray.Length > 0)
            {
                Servidor = strArray[0];
                Usuario = strArray[2];
                Pass = strArray[3];

                strConexionSAC = @"Data Source=[Servidor];Initial Catalog=[BaseDatos];Persist Security Info=True;User ID=[Usuario];Password=[Password]";

                strConexionSAC = strConexionSAC.Replace("[Servidor]", Servidor);
                strConexionSAC = strConexionSAC.Replace("[BaseDatos]", BaseDatos);
                strConexionSAC = strConexionSAC.Replace("[Usuario]", Usuario);
                strConexionSAC = strConexionSAC.Replace("[Password]", Pass);
            }
            return strConexionSAC;
        }

        private string BuscarBaseDatosEmpresa()
        {
            string BaseDeDatos = "";
            //Crear consulta para cargar del adimn el nombre de la bd que se v a allamar
            if (IdEmpresa != 0)
            {
                var varConec = ConfigurationManager.ConnectionStrings["ConexionCajas01"];
                if (varConec != null)
                {
                    SqlConnection ConAdmin = new SqlConnection(varConec.ToString());
                    using (ConAdmin)
                    {
                        ConAdmin.Open();
                        ClsModResultado ObjModResultado = null;
                        // ClbModLocalizacionPT.ClsModCatEmpresa ObjEmpresa = new ClsDatCatEmpresa().CargarXID(ConAdmin, new ClbModLocalizacionPT.ClsModCatEmpresa() { IdEmpresa = IdEmpresa }, out ObjModResultado);
                        if (string.IsNullOrEmpty(ObjModResultado.MsgError))
                            BaseDeDatos = null; //ObjEmpresa.BaseDatos;
                    }
                }
            }
            return BaseDeDatos;
        }
        private void CrearConexion(string Conexion)
        {
            try
            {
                if (SqlConexion == null)
                {
                    SqlConexion = new SqlConnection(Conexion);
                }
            }
            catch (Exception)
            {
                SqlConexion = new SqlConnection();
            }
        }

    }
}
