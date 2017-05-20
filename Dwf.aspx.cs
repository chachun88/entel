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
using System.IO;
using System.Data.OracleClient;
using System.Text;

public partial class Dwf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        String IdLugar = "";
        try
        {
            if (Request.QueryString["IdLugar"] != null)
            {
                IdLugar = Request.QueryString["IdLugar"];
                Lugar.Value = IdLugar;
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
            command.CommandText = "SELECT ID, URL, NOMBRE FROM DWF WHERE IDLUGAR=" + IdLugar;

            OracleDataReader reader = command.ExecuteReader();
            int i = 0;
            StringBuilder dwf = new StringBuilder();
            dwf.Append("<div>");
            while (reader.Read())
            {
                dwf.Append("<p>" + reader.GetOracleValue(2).ToString() + "&nbsp;&nbsp;&nbsp;");
                String dwfid = reader.GetOracleNumber(0).ToString();
                String dwfurl = reader.GetOracleValue(1).ToString();
                dwf.Append("<a href='eliminarDwf.aspx?dwf=" + dwfid + "&dwfurl=" + dwfurl + "&idlugar=" + IdLugar + "'>Eliminar DWF</a></p></div>");
                i++;
            }
            dwf.Append("</div>");
            if (i >= 3)
            {
                subir.Enabled = false;
                lblmessage.Text = "Para subir más planos, elimine archivos ya existentes, recuerde que puede subir como máximo 3 planos.";
            }
            d.Text = dwf.ToString();
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
    protected void subir_Click(object sender, EventArgs e)
    {
        if ((flimage.PostedFile != null) && (flimage.PostedFile.ContentLength > 0))
        {
            if (flimage.Value.EndsWith(".DWF") || flimage.Value.EndsWith(".dwf"))
            {
                if (flimage.PostedFile.ContentLength <= 409600)
                {
                    string fn = System.IO.Path.GetFileName(flimage.PostedFile.FileName);
                    string nombre = System.IO.Path.GetFileNameWithoutExtension(flimage.PostedFile.FileName);
                    string SaveLocation = Server.MapPath(@"~\entel\dwf") + "\\" + Lugar.Value + fn;
                    DirectoryInfo DIR = new DirectoryInfo(@Server.MapPath(@"~\entel\dwf"));

                    if (!DIR.Exists)
                    {
                        DIR.Create();
                    }
                    try
                    {
                        flimage.PostedFile.SaveAs(SaveLocation);
                        this.lblmessage.Text = "El archivo se ha cargado.";
                        nombreArchivo.Value = fn;
                        SaveLocation = @"../dwf/" + Lugar.Value + fn;


                        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
                        connection.Open();
                        OracleCommand command = connection.CreateCommand();



                        try
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT INTO DWF VALUES(0,'" + SaveLocation + "'," + Lugar.Value + ",TO_DATE ('" + DateTime.Today.ToShortDateString() + "', 'DD/MM/YYYY'),'"+nombre+"')";
                            command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                            //Response.Redirect(Request.RawUrl);
                            Page.RegisterStartupScript("script", "<script>top.document.location = top.document.location;</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);

                    }
                }
                else
                    this.lblmessage.Text = "El tamaño del archivo debe ser menor a 400kb";

            }
            else
                this.lblmessage.Text = "No se pudo cargar el archivo seleccionado, por favor seleccione un archivo .dwf";
        }
        else
        {
            this.lblmessage.Text = "Seleccione un archivo que cargar.";
        }
    }
    protected void eliminar_Click(object sender, EventArgs e)
    {
        String IdLugar = Lugar.Value;
        String enlace = nombreArchivo.Value.Replace(@"..", string.Empty);
        enlace = enlace.Replace("/", "\\");
        enlace = Server.MapPath(@"~\entel\" + enlace);
        String url = nombreArchivo.Value;

        File.Delete(enlace);

        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();
        OracleCommand command = connection.CreateCommand();



        try
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM DWF WHERE URL='" + url + "' AND IDLUGAR=" + IdLugar;
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            connection.Close();
            Response.Redirect(Request.RawUrl);
        }
    }
}
