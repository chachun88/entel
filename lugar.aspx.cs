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

public partial class lugar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String lugar="";

        try
        {
            if (Request.QueryString["lugar"] != null)
            {
                lugar = Request.QueryString["lugar"];
                IdLugar.Text = lugar;
                IdLugarV.Text = lugar;
                IdLugarDwf.Text = lugar;
                IdLugarR.Text = lugar;
                IdLugarInfo.Text = lugar;
                IdLugarInfo_.Text = lugar;
            }
        }
        catch (NullReferenceException nullExc)
        {

        }

        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();
        OracleCommand command = connection.CreateCommand();

        try
        {
            command.CommandText = "SELECT lug.nombre, "
                                +"lug.TIPOVIA || ' ' || lug.NOMBREVIA || '  #' || lug.NUMEROVIA as direccion, "
                                +"lug.REFDIRATENCION , "
                                +"lug.alias as siglaredes, "
                                +"lug.codalias || ' / ' || lug.IDMDFLUGAR as alias, "
                                +"(SELECT codedescription FROM CODETABLE WHERE codetablename = 'CTTipInf' AND TRIM (codevalue) IN lug.tipoinfra) AS infra, "
                                +"(SELECT codedescription FROM CODETABLE WHERE codetablename = 'CTTipRad' AND TRIM (codevalue) IN lug.tiporadioestacion) AS rde "
                                +"FROM  LUGARENTEL lug "
                                +"WHERE lug.AG2OBJECTID ="
                                + lugar;

            OracleDataReader reader = command.ExecuteReader();
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                Titulo.Text = reader.GetOracleValue(0).ToString();
                Nombre.Text = reader.GetOracleValue(0).ToString();
                Direccion.Text = reader.GetOracleValue(1).ToString();
                Referencia.Text = reader.GetOracleValue(2).ToString();
                SiglaRedes.Text = reader.GetOracleValue(3).ToString();
                Alias.Text = reader.GetOracleValue(4).ToString();
                Infraestructura.Text = reader.GetOracleValue(5).ToString();
                RadioEstacion.Text = reader.GetOracleValue(6).ToString();
                i++;
            }
            
            command.CommandText = "SELECT URL, NOMBRE FROM DWF WHERE IDLUGAR="
                                + lugar
                                + " ORDER BY ID ASC";

            reader = command.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                String enlace = reader.GetOracleString(0).ToString().Replace("../","");
                primerdwf.Text = "http://freewheel.labs.autodesk.com/dwf.aspx?path=http://poderyclima.no-ip.info/entel/" + enlace;
                sb.Append("<option value=\"http://freewheel.labs.autodesk.com/dwf.aspx?path=http://poderyclima.no-ip.info/entel/" + enlace + "\">"+ reader.GetOracleValue(1).ToString() +"</option>");
                i++;
            }
            opciones.Text = sb.ToString();
            reader.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
    }
}

