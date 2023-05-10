using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataReaderWebDemo
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("server=.; integrated security=true; database=TSQL; ");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sales.SQLReaderDemo";
            cmd.Parameters.AddWithValue("@categoryid", TextBox1.Text);

            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            SqlDataReader Dr = cmd.ExecuteReader();

            if (Dr.HasRows == false)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                Dr.Close();
                cn.Close();
                return;
            }

            GridView1.DataSource = Dr;
            GridView1.DataBind();
            
            Dr.Close();
            cn.Close();
        }
    }
}