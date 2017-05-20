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
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String comuna = "";
        String pag = "";
        Int32 pagina = new Int32();

        try
        {
            if (Request.QueryString["comuna"] != null)
            {
                comuna = Request.QueryString["comuna"];
            }
            if (Request.QueryString["pag"] != null)
            {
                pag = Request.QueryString["pag"];
            }
        }
        catch (NullReferenceException nullExc)
        {

        }
        int valorinicial = Int32.Parse(pag);
        int valorlimite = valorinicial * 70;
        valorinicial = (valorinicial - 1)*70;
        pag = pagina.ToString();
        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();

        OracleCommand command = connection.CreateCommand();

        StringBuilder str = new StringBuilder();
        command.CommandText = "SELECT * FROM ( "
                            +"SELECT ROWNUM as orden,NOMBRE,AG2OBJECTID AS ID FROM lugarentel WHERE AG2PARENTID = "
                            +comuna 
                            +") "
                            +"WHERE orden BETWEEN "+ valorinicial +"AND "+ valorlimite;
            


        OracleDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            str.Append("<lugar>\n");
            str.Append("<nombre><![CDATA[");
            if (reader.GetOracleValue(1).ToString().Length > 22)
            {
                str.Append(reader.GetOracleValue(1).ToString().Substring(0, 22) + "...");
            }
            else
            {
                str.Append(reader.GetOracleValue(1).ToString());
            }
            str.Append("]]></nombre>");
            str.Append("<url>");
            str.Append(reader.GetOracleValue(2).ToString());
            str.Append("</url>");
            str.Append("</lugar>");
        }
        reader.Close();
        connection.Close();
        foto.Text = str.ToString();
    }
}
