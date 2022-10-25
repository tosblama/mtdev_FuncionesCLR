using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionesCLR
{
    internal class AccesoDatos
    {
        // Cadena de conexión a la BBDD SQL
        public static readonly string cadenaConexion = "Context Connection=true";

        /// <summary>
        /// Ejecuta una consulta SQL en la base de datos, y devuelve los resultados obtenidos en un objeto DataTable.
        /// A diferencia de GetDataTable, este método es vulnerable a la inyección de dependencias, por lo que se recomienda usar sólo para procesos temporales internos.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns>Devuelve un DataTable con los resultados de la ejecución de la consulta.</returns>
        public static DataTable GetTmpDataTable(string SQL)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlDataAdapter comando = new SqlDataAdapter(SQL, conexion);
                DataSet ds = new DataSet();
                comando.Fill(ds);
                conexion.Close();
                comando.Dispose(); conexion.Dispose();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
