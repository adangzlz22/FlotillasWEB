using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{
    public class ClsModConexion
    {
        public SqlConnection SqlConexionAdmin { get; set; }
        public SqlConnection SqlConexionLocalizacionPT { get; set; }


        public ClsModConexion(SqlConnection Con, int IdEmpresa)
        {
            SqlConexionAdmin = Con;
            CrearConexion(GetConnectionSACAdmin());

            SqlConexionLocalizacionPT = new ClsConexionDinamica(null, IdEmpresa).SqlConexion;
        }
        public ClsModConexion(SqlConnection Con)
        {
            SqlConexionAdmin = Con;
            CrearConexion(GetConnectionSACAdmin());
        }
        public SqlConnection ReconectarSql()
        {
            SqlConexionAdmin = null;
            CrearConexion(GetConnectionSACAdmin());
            return SqlConexionAdmin;
        }
        /// <summary>
        /// Obtiene la cadena de conexión para SACAdmin
        /// </summary>
        /// <returns>Cadena de conexión a la base de datos</returns>
        public string GetConnectionSACAdmin()
        {
            var varConec = ConfigurationManager.ConnectionStrings["HarodoorDB"];

            if (varConec != null)
            {
                return varConec.ToString();
            }

            return string.Empty;
        }
        private void CrearConexion(string Conexion)
        {
            try
            {
                if (SqlConexionAdmin == null)
                {
                    SqlConexionAdmin = new SqlConnection(Conexion);
                }
            }
            catch (Exception)
            {
                SqlConexionAdmin = new SqlConnection();
            }
        }
    }
}
