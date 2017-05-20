using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;
using System.IO;

public partial class eliminarFotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String idfoto = "";
        String idlugar = "";
        String url = "";
        String urlavatar = "";
        try
        {
            if (Request.QueryString["idfoto"] != null && Request.QueryString["idlugar"] != null)
            {
                idfoto = Request.QueryString["idfoto"];
                idlugar = Request.QueryString["idlugar"];
                url = Request.QueryString["url"];
                urlavatar = Request.QueryString["urlavatar"];
            }
        }
        catch (NullReferenceException nullExc)
        {

        }
        
        url = url.Replace(@"/", @"\\");
        String ruta = Server.MapPath(Request.PathInfo) + "\\";
        urlavatar = urlavatar.Replace(@"/", @"\\");
        url = ruta + url;
        urlavatar = ruta + urlavatar;
        

        File.Delete(url);
        File.Delete(urlavatar);
        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();
        OracleCommand command = connection.CreateCommand();



        try
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM FOTOS WHERE ID= "+idfoto;
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            connection.Close();
            Response.Redirect("Fotos.aspx?IdLugar="+idlugar);
        }
    }
}
