using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

public partial class Equipos : System.Web.UI.Page
{
    String IdLugar = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        String root = "";
        try
        {
            if (Request.QueryString["root"] != null)
            {
                root = Request.QueryString["root"];
            }
            if (Request.QueryString["IdLugar"] != null)
            {
                IdLugar = Request.QueryString["IdLugar"];
            }
        }
        catch (NullReferenceException nullExc)
        {

        }

        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();

        OracleCommand command = connection.CreateCommand();

        StringBuilder str = new StringBuilder();
        command.CommandText = "select a.id_elemento, a.id_hijo, a.id_padre, level, te.descripcion "
                            + "from arbol a, tipoelemento te where a.id_lugar = "
                            + IdLugar
                            + " and a.id_elemento = te.codigo "
                            + "connect by prior a.id_hijo = a.id_padre "
                            + "start with a.id_padre = 1";

        OracleDataReader reader = command.ExecuteReader();
        OracleCommand comm = connection.CreateCommand();
        str.Append("[");

        int i = 0;
        while (reader.Read())
        {
            i++;
        }
        int j = 0;
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            str.Append("{");
            str.Append("\"text\":");
            str.Append("\"" + reader.GetOracleValue(4).ToString() + "\",");
            str.Append("\"id\":");
            str.Append("\"" + reader.GetOracleValue(1).ToString() + "\"");
            comm.CommandText = "select count(*) from arbol where id_padre = " + reader.GetOracleValue(1).ToString();
            Int32 count = 0;
            count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {

                str.Append(",\"hasChildren\":\"true\"");
            }
            if (j < i - 1)
            {
                str.Append("},");
            }
            else
            {
                str.Append("}");
            }
            j++;
        }
        str.Append("]");
        reader.Close();
        connection.Close();
        arbol.Text = str.ToString();
    }
}

