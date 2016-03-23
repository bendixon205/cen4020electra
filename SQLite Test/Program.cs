using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

/*
 * 
 * DATABASE INFORMATION
 * Filename: cardb.db
 * Table: create table carinv(id INTEGER PRIMARY KEY, model varchar(10), year int, color varchar(10),engine double,
 *                              mpg double, handling varchar(50), controls varchar(50), safety varchar(50), exterior varchar(50),
 *                              interior varchar(50), audio varchar(50), convenience varchar(50), maintprogram varchar(50),
 *                              warranty varchar(50), package varchar (25), orderstatus varchar(25), delivered varchar(15),
 *                              lastmaint varchar(15), nextmaint varchar(15), amountofmaint int, customer varchar(25));
 * 
 * !!!!IMPORTANT!!!!
 * Do NOT place database file, cardb.db in root C drive (Database becomes Read-Only)
 * Data Souce should be in 'c:\\User\\<your profile>\\CEN4020\\cardb.db' or any other location
 * Make sure to change the filepath in code to the respective location of database
 * 
 * ACCOMPLISHED SO FAR:
 * Add to inventory
 * Delete from inventory
 * Display some or all of inventory
 *      Gave display ability to display requested rows
 * Update inventory fields
 * 
 */

namespace SQLite_Test
{
    class Program
    {
        //Add an inventory to the database
        //Parameters are set to empty if there is no input for them
        public void addinventory(string model = " ", string year = " ", string color = " ", string engine = "0", string mpg = "0",
                                string handling = " ", string controls = " ", string safety = " ", string exterior = " ",
                                string interior = " ", string audio = " ", string convenience = " ", string maintprogram = " ",
                                string warranty = " ", string package = " ", string orderstatus = " ", string delivered = " ",
                                string lastmaint = " ", string nextmaint = " ", string amountofmaint = "0", string customer = " ")
        {
            //Creates a connection to the database
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            //Opens connection to database
            connection.Open();

            //Stores SQL INSERT command into a string
            string sql = "insert into carinv(id, model, year, color, engine, mpg, handling, controls, safety, exterior, interior, "
                        + "audio, convenience, maintprogram, warranty, package, orderstatus, delivered, lastmaint, nextmaint, amountofmaint, customer) "
                        + "values(NULL," + "'" + model + "'," + year + "," + "'" + color + "'," + engine + "," + mpg + ","
                        + "'" + handling + "'," + "'" + controls + "'," + "'" + safety + "'," + "'" + exterior + "'," + "'" + interior + "'," + "'" + audio + "',"
                        + "'" + convenience + "'," + "'" + maintprogram + "'," + "'" + warranty + "'," + "'" + package + "'," + "'" + orderstatus + "'," + "'" + delivered + "',"
                        + "'" + lastmaint + "'," + "'" + nextmaint + "'," + amountofmaint + ",'" + customer + "')";

            Console.WriteLine(sql); //Output to see if the string is correct INSERT command (Does not alter database)

            //Creates SQL command using a string
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);

            //Executes the string stored in the SQL command
            cmd.ExecuteNonQuery();

            //Closes connectiont to database (REQUIRED TO DO THIS)
            connection.Close();
        }

        //Displays the values in the database
        public void displayinventory(bool id = false, bool model = false, bool year = false, bool color = false, bool engine = false,
                                       bool mpg = false, bool handling = false, bool controls = false, bool safety = false, bool exterior = false,
                                        bool interior = false, bool audio = false, bool convenience = false, bool maintprogram = false, bool warranty = false,
                                        bool package = false, bool orderstatus = false, bool delivered = false, bool lastmaint = false, bool nextmaint = false,
                                        bool amountofmaint = false, bool customer = false, string selectcolumn = "", string rowvalue = "")
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "select * from carinv " + RowSelection(selectcolumn, rowvalue);

            Console.WriteLine(sql); //Output to see if the string is correct INSERT command (Does not alter database)

            SQLiteCommand cmd = new SQLiteCommand(sql, connection);

            //Creates an object that "reads" the database
            SQLiteDataReader reader = cmd.ExecuteReader();

            //Outputs the Table to the console screen
            while (reader.Read())
            {
                //Displays column only if it is requested for output
                Console.Write(id ? "ID: " + reader["id"] + "\t" : "");
                Console.Write(model ? "MODEL: " + reader["model"] + "\t" : "");
                Console.Write(year ? "YEAR: " + reader["year"] + "\t" : "");
                Console.Write(color ? "COLOR: " + reader["color"] + "\t" : "");
                Console.Write(engine ? "ENGINE: " + reader["engine"] + "\t" : "");
                Console.Write(mpg ? "MPG: " + reader["mpg"] + "\t" : "");
                Console.Write(handling ? "HANDLING: " + reader["handling"] + "\t" : "");
                Console.Write(controls ? "CONTROLS: " + reader["controls"] + "\t" : "");
                Console.Write(safety ? "SAFETY: " + reader["safety"] + "\t" : "");
                Console.Write(exterior ? "EXTERIOR: " + reader["exterior"] + "\t" : "");
                Console.Write(interior ? "INTERIOR: " + reader["interior"] + "\t" : "");
                Console.Write(audio ? "AUDIO: " + reader["audio"] + "\t" : "");
                Console.Write(convenience ? "CONVENIENCE: " + reader["convenience"] + "\t" : "");
                Console.Write(maintprogram ? "MAINTENANCE PROG: " + reader["maintprogram"] + "\t" : "");
                Console.Write(warranty ? "WARRANTY: " + reader["warranty"] + "\t" : "");
                Console.Write(package ? "PACKAGE: " + reader["package"] + "\t" : "");
                Console.Write(orderstatus ? "ORDER STATUS: " + reader["orderstatus"] + "\t" : "");
                Console.Write(delivered ? "DELIVERED: " + reader["delivered"] + "\t" : "");
                Console.Write(lastmaint ? "LAST MAINTENANCE: " + reader["lastmaint"] + "\t" : "");
                Console.Write(nextmaint ? "NEXT MAINTENANCE: " + reader["nextmaint"] + "\t" : "");
                Console.Write(amountofmaint ? "# OF MAINTENANCE: " + reader["amountofmaint"] + "\t" : "");
                Console.Write(customer ? "CUSTOMER: " + reader["customer"] + "\t" : "");

                Console.Write("\n");
            }

            connection.Close();
        }
        //Need to confirm this function works for all cases
        public string RowSelection(string selectcolumn, string rowvalue)
        {
            if (selectcolumn == "")
                return "";
            else if (rowvalue.All(Char.IsLetter))
                return "where " + selectcolumn + " = '" + rowvalue + "'";
            else
                return "where " + selectcolumn + " = " + rowvalue;
        }

        //Delete model from database
        //OVERLOAD deleteinventory - delete string from database
        public void deleteinventory(string column, string row)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "delete from carinv where " + column + " = '" + row + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //OVERLOAD deleteinventory - delete int from database
        public void deleteinventory(string column, int row)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "delete from carinv where " + column.ToString() + " = " + row.ToString();
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //OVERLOAD deleteinventory - delete double from database
        public void deleteinventory(string column, double row)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "delete from carinv where " + column.ToString() + " = " + row.ToString();
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Updates the table
        //OVERLOAD - Input customer name, updating a string
        public void updateinventory(string column, string name, string newvalue)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "update carinv set " + column + " = '" + newvalue + "' where customer = '" + name + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //OVERLOAD - Input car ID, updating a string
        public void updateinventory(string column, int name, string newvalue)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "update carinv set " + column + " = '" + newvalue + "' where id = '" + name.ToString() + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //OVERLOAD - Input customer name, update an integer
        public void updateinventory(string column, string name, int newvalue)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "update carinv set " + column + " = " + newvalue.ToString() + " where customer = '" + name + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //OVERLOAD - Input car id, updating an integer
        public void updateinventory(string column, int name, int newvalue)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "update carinv set " + column + " = " + newvalue.ToString() + " where id = '" + name.ToString() + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //OVERLOAD - Input customer name, update a double
        public void updateinventory(string column, string name, double newvalue)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "update carinv set " + column + " = " + newvalue.ToString() + " where customer = '" + name + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //OVERLOAD - Input car id, updating a double
        public void updateinventory(string column, int name, double newvalue)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\Users\\2592\\CEN4020\\cardb.db;Version=3;");
            connection.Open();
            string sql = "update carinv set " + column + " = " + newvalue.ToString() + " where id = '" + name.ToString() + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        //Main Code
        static void Main(string[] args)
        {

            Program n = new Program();

            /*
             * n.addinventory(use above template as to how the table was delared, or if you know the name of the column use formnat '<columnname>:"<value>"' and put in all applicable values);
             * n.deleteinventory(<column name>, <value to be deleted>);
             * n.updateinventory(<column name>, <row, either rowid or customer name>, <new value>)
             * n.display(use above template as to how the table was declared, arguements are boolean values, if there are no 'true' values, then a column is defaulted to not display the value);
             */
            //n.addinventory("COROLLA", "2013", color:"BLUE");
            //n.addinventory("PRIUS", "2010", color:"WHITE");
            n.updateinventory("color", 5, "BLACK");
            //n.deleteinventory("model", "test");
            //n.deleteinventory("id", 8);
            //n.deleteinventory("year", 2010);

            n.displayinventory(true, true, mpg:true, engine:true, rowvalue:"1.8", selectcolumn:"", customer:true, color:true);
        }
    }
}
