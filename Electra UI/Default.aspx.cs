using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SQLite;

public partial class _Default : Page
{
    public DataTable fillDataTable(string table)
    {
        DataTable dt = new DataTable();
        SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\Ben\\CEN4020\\cardb.db;Version=3;");
        //Opens connection to database
        connection.Open();

        string sql = "SELECT * FROM carinv WHERE color=\"RED\"";

        //Creates SQL command using a string
        SQLiteCommand cmd = new SQLiteCommand(sql, connection);

        //Executes the string stored in the SQL command
        dt.Load(cmd.ExecuteReader());

        //Closes connectiont to database (REQUIRED TO DO THIS)
        connection.Close();
        return dt;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = fillDataTable("carinv");
        GridView1.DataBind();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtMake_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}