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
using System.Configuration;
using System.Data.OracleClient;
using System.Web.Configuration;


public partial class Video : System.Web.UI.Page
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
            command.CommandText = "SELECT URL FROM (SELECT URL FROM VIDEOS WHERE IDLUGAR=" + IdLugar + " ORDER BY ID DESC) WHERE ROWNUM=1";

            OracleDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                nombreArchivo.Text = reader.GetOracleString(0).ToString();
                nombreArchivoUno.Text = reader.GetOracleString(0).ToString();
                nombreArchivoDos.Text = reader.GetOracleString(0).ToString();
                i++;
            }
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
        //DateTime fecha = System.IO.Directory.GetLastAccessTime(Server.MapPath(@"~\entel\video"));
        //string[] files = System.IO.Directory.GetFiles(Server.MapPath(@"~\entel\video"), "*.*");
        //foreach (string file in files)
        //{
        //    DateTime tiempo = System.IO.File.GetLastAccessTime(file);
        //    if (tiempo.CompareTo(fecha) == 0) {
        //        string nombreArchivo = System.IO.Path.GetFileName(file);
        //        this.nombreArchivo.Text = nombreArchivo;
        //        this.nombreArchivoUno.Text = nombreArchivo;
        //        this.nombreArchivoDos.Text = nombreArchivo;
        //    }
        //}
    }
    protected void subir_Click(object sender, EventArgs e)
    {
        if ((flimage.PostedFile != null) && (flimage.PostedFile.ContentLength > 0))
        {
            if (flimage.Value.EndsWith(".MP4") || flimage.Value.EndsWith(".mp4") || flimage.Value.EndsWith(".FLV") || flimage.Value.EndsWith(".flv"))
            {
                if (flimage.PostedFile.ContentLength <= 734003200)
                {
                    string fn = System.IO.Path.GetFileName(flimage.PostedFile.FileName);
                    string SaveLocation = Server.MapPath(ConfigurationManager.AppSettings["rutaVideos"]) + "\\" + Lugar.Value + fn;
                    DirectoryInfo DIR = new DirectoryInfo(@Server.MapPath(ConfigurationManager.AppSettings["rutaVideos"]));

                    if (!DIR.Exists)
                    {
                        DIR.Create();
                    }
                    try
                    {
                        flimage.PostedFile.SaveAs(SaveLocation);
                        this.lblmessage.Text = "El archivo se ha cargado.";
                        this.nombreArchivo.Text = fn;
                        this.nombreArchivoUno.Text = fn;
                        this.nombreArchivoDos.Text = fn;
                        SaveLocation = "../" + ConfigurationManager.AppSettings["rutaVideos"].Replace(@"\","/") + Lugar.Value + fn;


                        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
                        connection.Open();
                        OracleCommand command = connection.CreateCommand();



                        try
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT INTO VIDEOS VALUES(0,'" + SaveLocation + "'," + Lugar.Value + ",TO_DATE ('" + DateTime.Today.ToShortDateString() + "', 'DD/MM/YYYY'))";
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
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);

                    }
                }
                else
                    this.lblmessage.Text = "El tamaño del archivo debe ser menor a 250MB";

            }
            else
                this.lblmessage.Text = "No se pudo cargar el archivo seleccionado, por favor seleccione un video .mp4, o .flv";
        }
        else
        {
            this.lblmessage.Text = "Seleccione un archivo que cargar.";
        }
    }
    protected void eliminar_Click(object sender, EventArgs e)
    {
        String IdLugar = Lugar.Value;
        
        String enlace = nombreArchivo.Text.Replace(@"..", string.Empty);
        enlace = enlace.Replace("/", "\\");
        String ruta = Server.MapPath(Request.PathInfo);
        enlace = ruta + enlace;
        String url = nombreArchivo.Text;

        File.Delete(enlace);

        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();
        OracleCommand command = connection.CreateCommand();



        try
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM VIDEOS WHERE URL='" + url + "' AND IDLUGAR=" + IdLugar;
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
