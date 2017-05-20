using System;
using System.Data.OracleClient;
//using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs ex)
    {
    }
    protected void Buscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("resultadoBusquedaGral.aspx?palabraClave="+txtBusqueda.Text.ToUpper());
    }
}
