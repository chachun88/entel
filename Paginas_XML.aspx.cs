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
        try
        {
            if (Request.QueryString["comuna"] != null)
            {
                comuna = Request.QueryString["comuna"];
            }
        }
        catch (NullReferenceException nullExc)
        {

        }
        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();

        OracleCommand command = connection.CreateCommand();

        StringBuilder str = new StringBuilder();
        command.CommandText = "SELECT COUNT(*) FROM lugarentel where AG2PARENTID =" + comuna;

        OracleDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            str.Append("<npaginas>\n");
            String cant = reader.GetOracleNumber(0).ToString();
            double cantidad = Double.Parse(cant);
            cantidad = Math.Ceiling(cantidad / 75);
            str.Append(cantidad);
            str.Append("</npaginas>");
        }
        reader.Close();
        connection.Close();
        foto.Text = str.ToString();
    }
}
