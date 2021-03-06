﻿using System;
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

public partial class regiones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String region = "";
        try
        {
            if (Request.QueryString["region"] != null)
            {
                region = Request.QueryString["region"];
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
            command.CommandText = "select distinct reg.nombre, "
                                + "com.Nombre, "
                                + "lug.nombre, "
                                + "LUG.SIGLAREDES, "
                                + "LUG.LATITUDG, "
                                + "LUG.LATITUDM, "
                                + "LUG.LATITUDS, "
                                + "LUG.LONGITUDG, "
                                + "LUG.LONGITUDM, "
                                + "LUG.LONGITUDS, "
                                + "LUG.TIPOVIA || ' ' || LUG.NOMBREVIA || '  #' || LUG.NUMEROVIA, "
                                + "LUG.REFDIRATENCION, "
                                + "LUG.AG2OBJECTID "
                                + "from  LUGARENTEL lug, COMUNA com , REGION reg "
                                + "WHERE reg.AG2OBJECTID = "
                                + region
                                + " AND reg.AG2OBJECTID = com.AG2PARENTID"
                                + " AND com.AG2OBJECTID = lug.AG2PARENTID ";

            OracleDataReader reader = command.ExecuteReader();
            int i = 0;
            StringBuilder htmlTbl = new StringBuilder();
            htmlTbl.Append("<TABLE BorderColor='#6699cc' BorderStyle='Solid' Border=1 CellSpacing=0 CellPadding=2 FONT style='font-family: Arial; font-size: 11px;'>");
            htmlTbl.Append("<TABLE class=tabla_busqueda Border=1 CellSpacing=0 CellPadding=2> ");
            htmlTbl.Append("<TR Align='left'>");
            htmlTbl.Append("<TH>Región</TH>");
            htmlTbl.Append("<TH>Comuna</TH>");
            htmlTbl.Append("<TH>Lugar</TH>");
            htmlTbl.Append("<TH>Sigla Redes</TH>");
            htmlTbl.Append("<TH>Google Earth</TH>");
            htmlTbl.Append("<TH>Lat Sur</TH>");
            htmlTbl.Append("<TH>Long Oeste</TH>");
            htmlTbl.Append("<TH>Dirección</TH>");
            htmlTbl.Append("<TH>Referencia</TH>");
            htmlTbl.Append("<TR>");
            while (reader.Read())
            {
                htmlTbl.Append("<TR> ");
                htmlTbl.Append("<TD>" + reader.GetOracleString(0).ToString() + "</TD>");
                htmlTbl.Append("<TD>" + reader.GetOracleString(1).ToString() + "</TD>");
                htmlTbl.Append("<TD><a href='lugar.aspx?lugar=" + reader.GetOracleNumber(12).ToString() + "'>" + reader.GetOracleString(2).ToString() + "</a></TD>");
                htmlTbl.Append("<TD>" + reader.GetOracleString(3).ToString() + "</TD>");
                htmlTbl.Append("<TD></TD>");
                htmlTbl.Append("<TD>" + reader.GetOracleNumber(4).ToString() + "|");
                htmlTbl.Append(reader.GetOracleNumber(5).ToString() + "|");
                htmlTbl.Append(reader.GetOracleNumber(6).ToString() + "</TD>");
                htmlTbl.Append("<TD>" + reader.GetOracleNumber(7).ToString() + "|");
                htmlTbl.Append(reader.GetOracleNumber(8).ToString() + "|");
                htmlTbl.Append(reader.GetOracleNumber(9).ToString() + "</TD>");
                htmlTbl.Append("<TD>" + reader.GetOracleString(10).ToString() + "</TD>");
                htmlTbl.Append("<TD>" + reader.GetOracleString(11).ToString() + "</TD>");
                htmlTbl.Append("</TR>");
                i++;
            }
            htmlTbl.Append("</TABLE>");
            tblLugar.Text = htmlTbl.ToString();
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
    protected void Buscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("resultadoBusquedaGral.aspx?palabraClave=" + txtBusqueda.Text.ToUpper());
    }
}
