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

public partial class prueba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.RegisterStartupScript("script", "<script>$(\"#contenedor_formulario\").fadeOut(\"Slow\");</script>");
            this.ddnivel.SelectedIndexChanged += new System.EventHandler(this.ddnivel_SelectedIndexChanged);
            ddnivel.Items.Clear();
            lbl_ddnivel.Visible = false;
            EditarOk.Visible = false;
            ok.Visible = false;
            EliminarOk.Visible = false;
            ddnivel.AutoPostBack = false;
            ddnivel.Visible = false;
            dd.AutoPostBack = true;
            dd.Visible = false;
            //Eliminar.Attributes.Add("onclick", "javascript:return confirm('¿Está seguro?');");
            ddtipo.Visible = false;
            ddctos.Visible = false;
            ddcapacidad.Visible = false;
            ddvoltaje.Visible = false;
            lbl_tipo.Visible = false;
            lbl_ctos.Visible = false;
            lbl_capacidad.Visible = false;
            lbl_voltaje.Visible = false;
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
            command.CommandText = "select codigo, familia, descripcion "
                                + "from tipoelemento";
            OracleDataReader rd = command.ExecuteReader();
            ListItem first = new ListItem();
            first.Value = "";
            first.Text = "Seleccione Equipo";
            dd.Items.Add(first);
            ListItem item_nivel = new ListItem();
            item_nivel.Value = "";
            item_nivel.Text = "Equipamiento";
            ddnivel.Items.Add(item_nivel);
            while (rd.Read())
            {
                ListItem item = new ListItem();
                item.Value = rd.GetOracleValue(0).ToString();
                item.Text = rd.GetOracleValue(2).ToString();
                dd.Items.Add(item);
            }
            rd.Close();    
            command.CommandText = "select a.id_elemento, a.id_hijo, a.id_padre, level, te.descripcion "
                                + "from arbol a, tipoelemento te where a.id_lugar = "
                                + IdLugar
                                + " and a.id_elemento = te.codigo"
                                + " connect by prior a.id_hijo = a.id_padre "
                                + "start with a.id_padre = 1";
            rd = command.ExecuteReader();
            int i = 0;
            while (rd.Read())
            {
                i++;
            }
            int j = 0;
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                String nombre = "";
                Int32 idElemento = 0;
                idElemento = Convert.ToInt32(rd.GetOracleValue(0).ToString());
                if (idElemento >= 101 && idElemento <= 114)
                {
                    command.CommandText = "select nombre from feenergia where id=" + rd.GetOracleValue(1).ToString();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        nombre = reader.GetOracleValue(0).ToString();
                    }
                    reader.Close();
                }
                if (idElemento >= 201 && idElemento <= 206)
                {
                    command.CommandText = "select nombre from feclima where id=" + rd.GetOracleValue(1).ToString();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        nombre = reader.GetOracleValue(0).ToString();
                    }
                    reader.Close();
                }
                ListItem item = new ListItem();
                item.Value = rd.GetOracleValue(1).ToString();
                item.Text = rd.GetOracleValue(4).ToString()+"\t"+nombre;
                ddnivel.Items.Add(item);
            }
            rd.Close();
            connection.Close();
        }
        else
        {
            Page.RegisterStartupScript("script", "<script>$(\"#contenedor_formulario\").fadeIn(\"Slow\");</script>");
        }
    }
    protected void reiniciar()
    {
        ddnivel.Items.Clear();
        dd.Items.Clear();
        ddtipo.Items.Clear();
        ddcapacidad.Items.Clear();
        ddvoltaje.Items.Clear();
        ddctos.Items.Clear();
        ddtipo.Enabled = false;
        ddcapacidad.Enabled = false;
        ddctos.Enabled = false;
        ddvoltaje.Enabled = false;
        lbl_ddnivel.Visible = false;
        EditarOk.Visible = false;
        ok.Visible = false;
        EliminarOk.Visible = false;
        ddnivel.AutoPostBack = false;
        dd.AutoPostBack = true;
        ddnivel.Visible = false;
        dd.Visible = false;
        lbl_nombre.Visible = false;
        txt_nombre.Visible = false;
        //Eliminar.Attributes.Add("onclick", "javascript:return confirm('¿Está seguro?');");
        ddtipo.Visible = false;
        ddctos.Visible = false;
        ddcapacidad.Visible = false;
        ddvoltaje.Visible = false;
        lbl_tipo.Visible = false;
        lbl_ctos.Visible = false;
        lbl_capacidad.Visible = false;
        lbl_voltaje.Visible = false;
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
        command.CommandText = "select codigo, familia, descripcion "
                            + "from tipoelemento";
        OracleDataReader rd = command.ExecuteReader();
        ListItem first = new ListItem();
        first.Value = "";
        first.Text = "Seleccione Equipo";
        dd.Items.Add(first);
        ListItem item_nivel = new ListItem();
        item_nivel.Value = "";
        item_nivel.Text = "Equipamiento";
        ddnivel.Items.Add(item_nivel);
        while (rd.Read())
        {
            ListItem item = new ListItem();
            item.Value = rd.GetOracleValue(0).ToString();
            item.Text = rd.GetOracleValue(2).ToString();
            dd.Items.Add(item);
        }
        rd.Close();
        command.CommandText = "select a.id_elemento, a.id_hijo, a.id_padre, level, te.descripcion "
                                + "from arbol a, tipoelemento te where a.id_lugar = "
                                + IdLugar
                                + " and a.id_elemento = te.codigo"
                                + " connect by prior a.id_hijo = a.id_padre "
                                + "start with a.id_padre = 1";
        rd = command.ExecuteReader();
        int i = 0;
        while (rd.Read())
        {
            i++;
        }
        int j = 0;
        rd = command.ExecuteReader();
        while (rd.Read())
        {
            String nombre = "";
            Int32 idElemento = 0;
            idElemento = Convert.ToInt32(rd.GetOracleValue(0).ToString());
            if (idElemento >= 101 && idElemento <= 114)
            {
                command.CommandText = "select nombre from feenergia where id=" + rd.GetOracleValue(1).ToString();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nombre = reader.GetOracleValue(0).ToString();
                }
                reader.Close();
            }
            if (idElemento >= 201 && idElemento <= 206)
            {
                command.CommandText = "select nombre from feclima where id=" + rd.GetOracleValue(1).ToString();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nombre = reader.GetOracleValue(0).ToString();
                }
                reader.Close();
            }
            ListItem item = new ListItem();
            item.Value = rd.GetOracleValue(1).ToString();
            item.Text = rd.GetOracleValue(4).ToString() + "\t" + nombre;
            ddnivel.Items.Add(item);
        }
        rd.Close();
        connection.Close();
    }
    protected void Agregar_Click(object sender, EventArgs e)
    {
        reiniciar();
        ddnivel.Visible = true;
        lbl_ddnivel.Text = "Seleccione la ubicacion del equipo a agregar: ";
        lbl_ddnivel.Visible = true;
        ok.Visible = true;
        ddtipo.Visible = true;
        ddctos.Visible = true;
        ddcapacidad.Visible = true;
        ddvoltaje.Visible = true;
        dd.Visible = true;
        lbl_tipo.Visible = true;
        lbl_ctos.Visible = true;
        lbl_capacidad.Visible = true;
        lbl_voltaje.Visible = true;
        lbl_nombre.Visible = true;
        txt_nombre.Visible = true;
    }
    protected void Editar_Click(object sender, EventArgs e)
    {
        reiniciar();
        ddnivel.AutoPostBack = true;
        ddnivel.Visible = true;
        lbl_ddnivel.Text = "Seleccione el equipo a editar: ";
        lbl_ddnivel.Visible = true;
        EditarOk.Visible = true;
    }
    protected void EditarOk_Click(object sender, EventArgs e)
    {
        if (ddnivel.SelectedValue != "")
        {
            alerta.Text = "";
            try
            {
                String idelemento = "";
                OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ID_ELEMENTO FROM ARBOL WHERE ID_HIJO = " + ddnivel.SelectedValue;
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idelemento = reader.GetOracleValue(0).ToString();
                }
                command.CommandText = "SELECT FAMILIA FROM TIPOELEMENTO WHERE CODIGO = " + idelemento;
                OracleDataReader rd = command.ExecuteReader();
                String familia = "";
                while (rd.Read())
                {
                    familia = rd.GetOracleValue(0).ToString();
                }
                rd.Close();
                if (familia == "Poder")
                {
                    command.CommandText = "UPDATE FEENERGIA SET TIPO ='" + ddtipo.SelectedValue + "', CTOS='" + ddctos.SelectedValue + "', VOLTAJE='" + ddvoltaje.SelectedValue + "' WHERE ID=" + ddnivel.SelectedValue;
                    command.ExecuteNonQuery();
                }
                if (familia == "Clima")
                {
                    command.CommandText = "UPDATE FECLIMA SET TIPO ='" + ddtipo.SelectedValue + "', CAPACIDAD='" + ddcapacidad.SelectedValue + "' WHERE ID=" + ddnivel.SelectedValue;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                Response.Redirect(Request.RawUrl);
            }
        }
        else
        {
            alerta.Text = "Selecciona un equipo para editar.";
        }
    }
    protected void Ok_Click(object sender, EventArgs e)
    {
        String opcion = ddnivel.SelectedValue;
        String name = dd.Text;
        if (opcion == "")
        {
            opcion = "1";
        }
        if (dd.SelectedValue == "")
        {
            alerta.Text = "Seleccione un equipo";
        }
        else
        {
            try
            {
                OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT MAX(ID_HIJO) FROM ARBOL";
                Int32 count = 0;
                count = Convert.ToInt32(command.ExecuteScalar());
                count = count + 1;
                command.CommandText = "INSERT INTO ARBOL VALUES(" + count + "," + opcion + "," + Lugar.Value + "," + name + ")";
                command.ExecuteNonQuery();
                command.CommandText = "SELECT FAMILIA FROM TIPOELEMENTO WHERE CODIGO = " + name;
                OracleDataReader rd = command.ExecuteReader();
                String familia = "";
                while (rd.Read())
                {
                    familia = rd.GetOracleValue(0).ToString();
                }
                rd.Close();
                if (familia == "Poder")
                {
                    command.CommandText = "INSERT INTO FEENERGIA VALUES(" + count + "," + opcion + "," + name + ",'','','','','','" + ddtipo.SelectedValue + "','" + ddctos.SelectedValue + "','" + ddcapacidad.SelectedValue + "','','" + ddvoltaje.SelectedValue + "','" + txt_nombre.Text + "')";
                    command.ExecuteNonQuery();
                }
                if (familia == "Clima")
                {
                    command.CommandText = "INSERT INTO FECLIMA VALUES(" + count + "," + opcion + "," + name + ",'','','" + ddtipo.SelectedValue + "','" + ddcapacidad.SelectedValue + "','" + txt_nombre.Text + "')";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                Response.Redirect(Request.RawUrl);
            }
        }
    }
    protected void Eliminar_Click(object sender, EventArgs e)
    {
        reiniciar();
        ddnivel.Visible = true;
        EliminarOk.Visible = true;
        lbl_ddnivel.Visible = true;
        lbl_ddnivel.Text = "Seleccione el equipo que desea eliminar: ";
    }
    protected void EliminarOk_Click(object sender, EventArgs e)
    {
        String opcion = ddnivel.SelectedValue;
        if (opcion != "")
        {
            try
            {
                alerta.Text = "";
                OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                OracleCommand comm = connection.CreateCommand();
                command.CommandText = "select id_hijo,id_elemento "
                                    + "from arbol "
                                    + "connect by prior id_hijo = id_padre "
                                    + "start with id_hijo in (select id_hijo "
                                    + "from arbol "
                                    + "where id_hijo =" + opcion + "and id_lugar =" + Lugar.Value + ") order by id_hijo desc";
                OracleDataReader rd = command.ExecuteReader();
                String familia = "";
                while (rd.Read())
                {
                    String hijo = rd.GetOracleValue(0).ToString();
                    comm.CommandText = "DELETE ARBOL WHERE ID_HIJO = " + rd.GetOracleValue(0).ToString();
                    comm.ExecuteNonQuery();
                    comm.CommandText = "SELECT FAMILIA FROM TIPOELEMENTO WHERE CODIGO = " + rd.GetOracleValue(1).ToString();
                    OracleDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        familia = reader.GetOracleValue(0).ToString();
                    }
                    reader.Close();
                    if (familia == "Poder")
                    {
                        command.CommandText = "DELETE FEENERGIA WHERE ID = " + rd.GetOracleValue(0).ToString();
                        command.ExecuteNonQuery();
                    }
                    if (familia == "Clima")
                    {
                        command.CommandText = "DELETE FECLIMA WHERE ID = " + rd.GetOracleValue(0).ToString();
                        command.ExecuteNonQuery();
                    }
                }
                rd.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                Response.Redirect(Request.RawUrl);
            }
        }
        else
        {
            alerta.Text = "Seleccione un equipo para ser eliminado.";
        }
    }
    protected void ddnivel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddnivel.Visible = true;
        lbl_ddnivel.Visible = true;

        String idequipo = ddnivel.SelectedValue;
        String familia = "";
        String codigo = "";
        String tipo = "";
        String circuito = "";
        String voltaje = "";
        String capacidad = "";
        if (idequipo != "")
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["local"]);
            conn.Open();
            try
            {
                ddtipo.Items.Clear();
                ddctos.Items.Clear();
                ddvoltaje.Items.Clear();
                ddcapacidad.Items.Clear();
                OracleCommand command = conn.CreateCommand();
                command.CommandText = "SELECT TE.FAMILIA, TE.CODIGO FROM TIPOELEMENTO TE, ARBOL A WHERE A.ID_ELEMENTO = TE.CODIGO AND A.ID_HIJO = " + ddnivel.SelectedValue;
                OracleDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    familia = rd.GetOracleValue(0).ToString();
                    codigo = rd.GetOracleValue(1).ToString();
                }
                rd.Close();
                if (familia == "Poder")
                {
                    command.CommandText = "SELECT E.TIPO, E.CTOS, E.VOLTAJE, E.CAPACIDADELEC FROM FEENERGIA E, ARBOL A WHERE A.ID_HIJO = E.ID AND A.ID_PADRE = E.IDPADRE AND A.ID_HIJO = " + idequipo;
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Value = reader.GetOracleValue(0).ToString();
                        item.Text = reader.GetOracleValue(0).ToString();
                        ddtipo.Items.Add(item);
                        tipo = reader.GetOracleValue(0).ToString();
                        ListItem ctos = new ListItem();
                        ctos.Value = reader.GetOracleValue(1).ToString();
                        ctos.Text = reader.GetOracleValue(1).ToString();
                        ddctos.Items.Add(ctos);
                        circuito = reader.GetOracleValue(1).ToString();
                        ListItem vol = new ListItem();
                        vol.Value = reader.GetOracleValue(2).ToString();
                        vol.Text = reader.GetOracleValue(2).ToString();
                        ddvoltaje.Items.Add(vol);
                        voltaje = reader.GetOracleValue(2).ToString();
                        ListItem cap = new ListItem();
                        cap.Value = reader.GetOracleValue(3).ToString();
                        cap.Text = reader.GetOracleValue(3).ToString();
                        ddcapacidad.Items.Add(cap);
                        capacidad = reader.GetOracleValue(3).ToString();
                    }
                    command.CommandText = "SELECT TIPO, CTO, VOLTAJE, CAPACIDAD FROM REGLAPODER WHERE ID_ELEMENTO = " + codigo;
                    OracleDataReader odr = command.ExecuteReader();
                    while (odr.Read())
                    {
                        if (odr.GetOracleValue(0).ToString() != "Null")
                        {
                            char[] separador = { '/' };
                            string[] tipos = odr.GetOracleValue(0).ToString().Split(separador);
                            foreach (string t in tipos)
                            {
                                if (t != tipo)
                                {
                                    ListItem item = new ListItem();
                                    item.Value = t;
                                    item.Text = t;
                                    ddtipo.Items.Add(item);
                                }
                            }
                            ddtipo.Enabled = true;
                            lbl_tipo.Visible = true;
                            ddtipo.Visible = true;
                        }
                        else
                        {
                            ddtipo.Items.Clear();
                            ddtipo.Enabled = false;
                        }
                        if (odr.GetOracleValue(1).ToString() != "Null")
                        {
                            char[] separador = { '/' };
                            string[] circuitos = odr.GetOracleValue(1).ToString().Split(separador);
                            foreach (string c in circuitos)
                            {
                                if (c != circuito)
                                {
                                    ListItem item = new ListItem();
                                    item.Value = c;
                                    item.Text = c;
                                    ddctos.Items.Add(item);
                                }
                            }
                            ddctos.Enabled = true;
                            ddctos.Visible = true;
                            lbl_ctos.Visible = true;
                        }
                        else
                        {
                            ddctos.Items.Clear();
                            ddctos.Enabled = false;
                        }
                        if (odr.GetOracleValue(2).ToString() != "Null")
                        {
                            char[] separador = { '/' };
                            string[] volts = odr.GetOracleValue(2).ToString().Split(separador);
                            foreach (string v in volts)
                            {
                                if (voltaje != v)
                                {
                                    ListItem item = new ListItem();
                                    item.Value = v;
                                    item.Text = v;
                                    ddvoltaje.Items.Add(item);
                                }
                            }
                            ddvoltaje.Enabled = true;
                            ddvoltaje.Visible = true;
                            lbl_voltaje.Visible = true;
                        }
                        else
                        {
                            ddvoltaje.Items.Clear();
                            ddvoltaje.Enabled = false;
                        }
                        if (odr.GetOracleValue(3).ToString() != "Null")
                        {
                            char[] separador = { '/' };
                            string[] capacidades = odr.GetOracleValue(3).ToString().Split(separador);
                            foreach (string c in capacidades)
                            {
                                if (capacidad != c)
                                {
                                    ListItem item = new ListItem();
                                    item.Value = c;
                                    item.Text = c;
                                    ddcapacidad.Items.Add(item);
                                }
                            }
                            ddcapacidad.Enabled = true;
                            ddcapacidad.Visible = true;
                            lbl_capacidad.Visible = true;
                        }
                        else
                        {
                            ddcapacidad.Items.Clear();
                            ddcapacidad.Enabled = false;
                        }
                    }
                    odr.Close();
                    reader.Close();
                }
                if (familia == "Clima")
                {
                    command.CommandText = "SELECT C.TIPO, C.CAPACIDAD FROM FECLIMA C, ARBOL A WHERE A.ID_HIJO = C.ID AND A.ID_PADRE = C.IDPADRE AND A.ID_HIJO = " + idequipo;
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Value = reader.GetOracleValue(0).ToString();
                        item.Text = reader.GetOracleValue(0).ToString();
                        ddtipo.Items.Add(item);
                        tipo = reader.GetOracleValue(0).ToString();
                        ListItem cap = new ListItem();
                        cap.Value = reader.GetOracleValue(1).ToString();
                        cap.Text = reader.GetOracleValue(1).ToString();
                        ddcapacidad.Items.Add(cap);
                        capacidad = reader.GetOracleValue(1).ToString();
                    }
                    command.CommandText = "SELECT TIPO, CAPACIDAD FROM REGLACLIMA WHERE ID_ELEMENTO = " + codigo;
                    OracleDataReader odr = command.ExecuteReader();
                    while (odr.Read())
                    {
                        if (odr.GetOracleValue(0).ToString() != "Null")
                        {
                            char[] separador = { '/' };
                            string[] tipos = odr.GetOracleValue(0).ToString().Split(separador);
                            foreach (string t in tipos)
                            {
                                if (t != tipo)
                                {
                                    ListItem item = new ListItem();
                                    item.Value = t;
                                    item.Text = t;
                                    ddtipo.Items.Add(item);
                                }
                            }
                            ddtipo.Enabled = true;
                            lbl_tipo.Visible = true;
                            ddtipo.Visible = true;
                        }
                        else
                        {
                            ddtipo.Items.Clear();
                            ddtipo.Enabled = false;
                        }
                        if (odr.GetOracleValue(1).ToString() != "Null")
                        {
                            char[] separador = { '/' };
                            string[] capacidades = odr.GetOracleValue(1).ToString().Split(separador);
                            foreach (string c in capacidades)
                            {
                                if (c != capacidad)
                                {
                                    ListItem item = new ListItem();
                                    item.Value = c;
                                    item.Text = c;
                                    ddcapacidad.Items.Add(item);
                                }
                            }
                            ddcapacidad.Enabled = true;
                            ddcapacidad.Visible = true;
                            lbl_capacidad.Visible = true;
                        }
                        else
                        {
                            ddcapacidad.Items.Clear();
                            ddcapacidad.Enabled = false;
                        }
                    }
                    odr.Close();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        else
        {
            Editar_Click(null, null);
            alerta.Text = "Seleccione un equipo para editar.";
        }
    }
    protected void dd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dd.SelectedValue == "")
        {
            alerta.Text = "Seleccione un equipo";
        }
        else
        {
            alerta.Text = "";

            ddnivel.Visible = true;
            ok.Visible = true;
            ddtipo.Visible = true;
            ddctos.Visible = true;
            ddcapacidad.Visible = true;
            ddvoltaje.Visible = true;
            dd.Visible = true;
            lbl_tipo.Visible = true;
            lbl_ctos.Visible = true;
            lbl_capacidad.Visible = true;
            lbl_voltaje.Visible = true;
            String opcion = dd.SelectedValue;
            OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["local"]);
            connection.Open();
            try
            {
                OracleCommand command = connection.CreateCommand();
                OracleCommand comm = connection.CreateCommand();
                command.CommandText = "select familia "
                                    + "from tipoelemento "
                                    + "where codigo = "
                                    + opcion;
                OracleDataReader rd = command.ExecuteReader();
                String familia = "";
                while (rd.Read())
                {
                    familia = rd.GetOracleValue(0).ToString();
                }
                rd.Close();
                if (familia == "Poder")
                {
                    String tipo = "";
                    String cto = "";
                    String voltaje = "";
                    String capacidad = "";
                    command.CommandText = "select tipo, cto, voltaje, capacidad "
                                    + "from reglapoder "
                                    + "where id_elemento = "
                                    + opcion;
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        tipo = rd.GetOracleValue(0).ToString();
                        cto = rd.GetOracleValue(1).ToString();
                        voltaje = rd.GetOracleValue(2).ToString();
                        capacidad = rd.GetOracleValue(3).ToString();
                    }
                    rd.Close();
                    if (tipo != "Null")
                    {
                        char[] separador = { '/' };
                        string[] tipos = tipo.Split(separador);
                        ddtipo.Items.Clear();
                        foreach (string t in tipos)
                        {
                            ListItem item = new ListItem();
                            item.Value = t;
                            item.Text = t;
                            ddtipo.Items.Add(item);
                        }
                        ddtipo.Enabled = true;
                        lbl_tipo.Visible = true;
                        ddtipo.Visible = true;
                    }
                    else
                    {
                        ddtipo.Items.Clear();
                        ddtipo.Enabled = false;
                    }
                    if (cto != "Null")
                    {
                        char[] separador = { '/' };
                        string[] circuitos = cto.Split(separador);
                        ddctos.Items.Clear();
                        foreach (string c in circuitos)
                        {
                            ListItem item = new ListItem();
                            item.Value = c;
                            item.Text = c;
                            ddctos.Items.Add(item);
                        }
                        ddctos.Enabled = true;
                        ddctos.Visible = true;
                        lbl_ctos.Visible = true;
                    }
                    else
                    {
                        ddctos.Items.Clear();
                        ddctos.Enabled = false;
                    }
                    if (capacidad != "Null")
                    {
                        char[] separador = { '/' };
                        string[] capacidades = capacidad.Split(separador);
                        ddcapacidad.Items.Clear();
                        foreach (string c in capacidades)
                        {
                            ListItem item = new ListItem();
                            item.Value = c;
                            item.Text = c;
                            ddcapacidad.Items.Add(item);
                        }
                        ddcapacidad.Enabled = true;
                        ddcapacidad.Visible = true;
                        lbl_capacidad.Visible = true;
                    }
                    else
                    {
                        ddcapacidad.Items.Clear();
                        ddcapacidad.Enabled = false;
                    }
                    if (voltaje != "Null")
                    {
                        char[] separador = { '/' };
                        string[] volts = voltaje.Split(separador);
                        ddvoltaje.Items.Clear();
                        foreach (string v in volts)
                        {
                            ListItem item = new ListItem();
                            item.Value = v;
                            item.Text = v;
                            ddvoltaje.Items.Add(item);
                        }
                        ddvoltaje.Enabled = true;
                        ddvoltaje.Visible = true;
                        lbl_voltaje.Visible = true;
                    }
                    else
                    {
                        ddvoltaje.Items.Clear();
                        ddvoltaje.Enabled = false;
                    }
                }
                if (familia == "Clima")
                {
                    ddvoltaje.Items.Clear();
                    ddvoltaje.Enabled = false;
                    ddctos.Items.Clear();
                    ddctos.Enabled = false;
                    String tipo = "";
                    String capacidad = "";
                    command.CommandText = "select tipo, capacidad "
                                    + "from reglaclima "
                                    + "where id_elemento = "
                                    + opcion;
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        tipo = rd.GetOracleValue(0).ToString();
                        capacidad = rd.GetOracleValue(1).ToString();
                    }
                    rd.Close();
                    if (tipo != "Null")
                    {
                        char[] separador = { '/' };
                        string[] tipos = tipo.Split(separador);
                        ddtipo.Items.Clear();
                        foreach (string t in tipos)
                        {
                            ListItem item = new ListItem();
                            item.Value = t;
                            item.Text = t;
                            ddtipo.Items.Add(item);
                        }
                        ddtipo.Enabled = true;
                        ddtipo.Visible = true;
                        lbl_tipo.Visible = true;
                    }
                    else
                    {
                        ddtipo.Items.Clear();
                        ddtipo.Enabled = false;
                    }
                    if (capacidad != "Null")
                    {
                        char[] separador = { '/' };
                        string[] capacidades = capacidad.Split(separador);
                        ddcapacidad.Items.Clear();
                        foreach (string c in capacidades)
                        {
                            ListItem item = new ListItem();
                            item.Value = c;
                            item.Text = c;
                            ddcapacidad.Items.Add(item);
                        }
                        ddcapacidad.Enabled = true;
                        ddcapacidad.Visible = true;
                        lbl_capacidad.Visible = true;
                    }
                    else
                    {
                        ddcapacidad.Items.Clear();
                        ddcapacidad.Enabled = false;
                    }
                }

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
}
