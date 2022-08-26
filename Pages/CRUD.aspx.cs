using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Web.UI;


namespace CRUD.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar Nuevo Estudiante";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de Estudiante";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar Estudiante";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar Estudiante";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbnombre.Text = row[1].ToString();
            tbpromedio.Text = row[2].ToString();
            tbtelefono.Text = row[3].ToString();
            tbidtelefono.Text = row[4].ToString();
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@Promedio", SqlDbType.Float).Value = tbpromedio.Text;
            cmd.Parameters.Add("@Telefono", SqlDbType.Int).Value = tbtelefono.Text;
            cmd.Parameters.Add("@Id_Telefono", SqlDbType.Int).Value = tbidtelefono.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@Promedio", SqlDbType.Float).Value = tbpromedio.Text;
            cmd.Parameters.Add("@Telefono", SqlDbType.Int).Value = tbtelefono.Text;
            cmd.Parameters.Add("@Id_Telefono", SqlDbType.Int).Value = tbidtelefono.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}