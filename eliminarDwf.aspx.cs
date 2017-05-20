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
        String dwf = "";
        String url = "";
        String idlugar = "";
        try
        {
            if (Request.QueryString["dwf"] != null && Request.QueryString["dwfurl"] != null)
            {
                dwf = Request.QueryString["dwf"];
                url = Request.QueryString["dwfurl"];
                idlugar = Request.QueryString["idlugar"];
            }
        }
        catch (NullReferenceException nullExc)
        {

        }
        
        url = url.Replace(@"..", string.Empty);
        url = Server.MapPath(@"~\entel\" + url);
        

        File.Delete(url);
        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();
        OracleCommand command = connection.CreateCommand();



        try
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM DWF WHERE ID= "+dwf;
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            connection.Close();
            //Response.Redirect("Dwf.aspx?IdLugar=" + idlugar);
            Page.RegisterStartupScript("script", "<script>top.document.location = top.document.location;</script>");
        }
    }
}
