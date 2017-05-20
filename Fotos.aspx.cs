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
using System.Text;
using System.Data.OracleClient;
using System.IO;

public partial class Fotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //subir.Attributes.Add("onClick", "javascript:return confirm('¿Está segur@ que quieres eliminar esta foto?');");
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
            command.CommandText = "SELECT ID, URL, URL_AVATAR, FECHASUBIDA FROM FOTOS WHERE IDLUGAR=" + IdLugar;

            OracleDataReader reader = command.ExecuteReader();
            int i = 0;
            StringBuilder fotos = new StringBuilder();
            fotos.Append("<div id='contenedor_fotos'>");
            while (reader.Read())
            {
                fotos.Append("<div class='foto'><a href='" + reader.GetOracleString(1).ToString() + "' target='aqui1'><img src='" + reader.GetOracleString(2).ToString() + "' width='91' height='72' border='0' /></a>");
                fotos.Append("<div>" + reader.GetOracleValue(3).ToString() + "</div>");
                String idfoto = reader.GetOracleNumber(0).ToString();
                fotos.Append("<a href='eliminarFotos.aspx?idfoto=" + idfoto + "&idlugar=" + Lugar.Value + "&url=" + reader.GetOracleString(1).ToString() + "&urlavatar=" + reader.GetOracleString(2).ToString() + "'>Eliminar Foto</a></div>");
                i++;
            }
            fotos.Append("</div>");
            foto.Text = fotos.ToString();
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
            if (flimage.Value.EndsWith(".JPG") || flimage.Value.EndsWith(".jpg") || flimage.Value.EndsWith(".ico") || flimage.Value.EndsWith(".ICO") || flimage.Value.EndsWith(".gif") || flimage.Value.EndsWith(".GIF") || flimage.Value.EndsWith(".png") || flimage.Value.EndsWith(".PNG"))
            {
                if (flimage.PostedFile.ContentLength <= 204800)
                {

                    string fn = System.IO.Path.GetFileName(flimage.PostedFile.FileName);
                    string fn_mini = System.IO.Path.GetFileNameWithoutExtension(flimage.PostedFile.FileName);
                    string extension = System.IO.Path.GetExtension(flimage.PostedFile.FileName);
                    string ruta = Server.MapPath(Request.PathInfo);
                    string SaveLocation = ruta + "\\" + ConfigurationManager.AppSettings["rutaFotos"] + Lugar.Value + fn;
                    string SaveLocation_mini = ruta + "\\" + ConfigurationManager.AppSettings["rutaFotos"] + Lugar.Value + fn_mini + "_avatar" + extension;
                    string carpeta = Server.MapPath(@"~\entel\upload_foto").Replace(@"\\", @"\");
                    try
                    {
                        DirectoryInfo DIR = new DirectoryInfo(ruta + "\\" + ConfigurationManager.AppSettings["rutaFotos"]);

                        if (!DIR.Exists)
                        {
                            DIR.Create();
                        }
                        flimage.PostedFile.SaveAs(SaveLocation);
                        System.Drawing.Image imagen = System.Drawing.Image.FromStream(flimage.PostedFile.InputStream);
                        System.Drawing.Image miniatura = imagen.GetThumbnailImage(91, 72, null, IntPtr.Zero);
                        miniatura.Save(SaveLocation_mini, System.Drawing.Imaging.ImageFormat.Png);
                        this.lblmessage.Text = "El archivo se ha cargado.";
                        SaveLocation = ConfigurationManager.AppSettings["rutaFotos"] + Lugar.Value + fn;
                        SaveLocation_mini = ConfigurationManager.AppSettings["rutaFotos"] + Lugar.Value + fn_mini + "_avatar" + extension;
                        SaveLocation = SaveLocation.Replace(@"\", "/");
                        SaveLocation_mini = SaveLocation_mini.Replace(@"\", "/");
                        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
                        connection.Open();
                        OracleCommand command = connection.CreateCommand();



                        try
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT INTO FOTOS VALUES(0,'" + SaveLocation + "','" + SaveLocation_mini + "'," + Lugar.Value + ",TO_DATE ('" + DateTime.Today.ToShortDateString() + "', 'DD/MM/YYYY'))";
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
                    this.lblmessage.Text = "El tamaño del archivo debe ser menor a 200KB";

            }
            else
                this.lblmessage.Text = "No se pudo cargar el archivo seleccionado, por favor seleccione una imagen .jpg, .gif o .png";
        }
        else
        {
            this.lblmessage.Text = "Seleccione un archivo que cargar.";
        }
    }
    protected void eliminar_Click(object sender, EventArgs e)
    {
        String IdLugar = Lugar.Value;
        String enlace = ((LinkButton)sender).ID.Replace(@"\", @"\\");
        enlace = Server.MapPath(@"~\entel\" + enlace);
        String url = ((LinkButton)sender).ID;

        File.Delete(enlace);

        OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
        connection.Open();
        OracleCommand command = connection.CreateCommand();



        try
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM FOTOS WHERE URL='" + url + "' AND IDLUGAR=" + IdLugar;
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
