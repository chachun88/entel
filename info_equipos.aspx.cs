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

public partial class info_equipos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String IdLugar = "";
        try
        {
            if (Request.QueryString["IdLugar"] != null)
            {
                IdLugar = Request.QueryString["IdLugar"];
                //Lugar.Value = IdLugar;
            }
        }
        catch (NullReferenceException nullExc)
        {

        }
        OracleConnection conexion = new OracleConnection("Data Source=localhost;User Id=usuario;Password=password;");
        conexion.Open();
        OracleCommand comm = conexion.CreateCommand();
        comm.CommandText = "select nombre from lugarentel where ag2objectid = " + IdLugar;
        OracleDataReader rd = comm.ExecuteReader();
        while (rd.Read())
        {
            ttl_pagina.Text = rd.GetOracleValue(0).ToString();
        }
        rd.Close();
        comm.CommandText = "select a.id_elemento, a.id_hijo, a.id_padre, level, lpad(concat(level,'.-'), (level - 1) * 2) || te.descripcion  as padded_name "
                         + "from arbol a, tipoelemento te where a.id_lugar = "
                         + IdLugar
                         + " and a.id_elemento = te.codigo "
                         + "connect by prior a.id_hijo = a.id_padre "
                         + "start with a.id_padre = 1";

        rd = comm.ExecuteReader();
        StringBuilder str = new StringBuilder();
        int i = 0;
        int nivel = 1;
        while (rd.Read())
        {
            if (rd.GetOracleValue(2).ToString() == "1")
                i++;
        }
        rd = comm.ExecuteReader();
        while (rd.Read())
        {
            int cant = 0;
            String nombre = "";
            Int32 idElemento = 0;
            idElemento = Convert.ToInt32(rd.GetOracleValue(0).ToString());
            if (idElemento >= 101 && idElemento <= 114)
            {
                comm.CommandText = "select nombre from feenergia where id=" + rd.GetOracleValue(1).ToString();
                OracleDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    nombre = reader.GetOracleValue(0).ToString();
                }
                reader.Close();
            }
            if (idElemento >= 201 && idElemento <= 206)
            {
                comm.CommandText = "select nombre from feclima where id=" + rd.GetOracleValue(1).ToString();
                OracleDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    nombre = reader.GetOracleValue(0).ToString();
                }
                reader.Close();
            }


            if (Convert.ToInt32(rd.GetOracleValue(3).ToString()) == 1)
            {
                if (nivel != Convert.ToInt32(rd.GetOracleValue(3).ToString()))
                    str.Append("</table>");
                str.Append("<table cellspacing=\"0\" cellpadding=\"2\" border=\"0\" class=\"tbl_eqp\">");
                str.Append("<tr>");
                str.Append("<th>");
                str.Append(rd.GetOracleValue(4).ToString().Replace("0.-", string.Empty) + "\t" + nombre);
                str.Append("</th>");
                str.Append("</tr>");
                nivel = Convert.ToInt32(rd.GetOracleValue(3).ToString());

            }
            else
            {
                str.Append("<tr>");
                str.Append("<td>");
                str.Append(rd.GetOracleValue(4).ToString().Replace("0.-", string.Empty) + "\t" + nombre);
                str.Append("</td>");
                str.Append("</tr>");
                nivel = Convert.ToInt32(rd.GetOracleValue(3).ToString());
            }
            
        }
        rd.Close();
        tbl_info.Text = str.ToString();
    }
}
