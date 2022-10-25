using FuncionesCLR;
using Microsoft.SqlServer.Server;
using System.Data;

public partial class Comunes
{

    [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
    public static string LeerFichero(string rutaFichero, int idUsuario)
    {
        System.IO.StreamReader sr = new System.IO.StreamReader(rutaFichero, System.Text.Encoding.Default);
        string textoFichero = sr.ReadToEnd();

        DataTable dt = AccesoDatos.GetTmpDataTable($"select Apellidos+' '+Nombre as Usuario from dbo.Usuarios where IdUsuario={idUsuario}");
        if (dt.Rows.Count == 1)
        {
            textoFichero = textoFichero.Replace("#USUARIO_NOMBRE#", dt.Rows[0]["Usuario"].ToString());
        }
        return textoFichero;
    }

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void testSP()
    {
        SqlContext.Pipe.Send("Resultado del procedimiento almacenado");
    }


}
