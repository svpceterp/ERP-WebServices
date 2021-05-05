using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    public class ConnectionDB
    {
        // Connection Code for Live 

        //public static SqlConnection OpenConnection()
        //{

        //    ERPConnectionClass erpconnection = new ERPConnectionClass();

        //    return erpconnection.OpenConnection();
        //}

       static SqlConnection conn = new SqlConnection();
        public ConnectionDB()
        {

            conn = OpenConnection();
        }
        public static SqlConnection OpenConnection()
        {
        SqlConnection conn = GetConnection(@"117.239.42.21\WEBSERVERDB,1433", "ERPDBliv", "liverp", "tpdc123#");
        return conn;
        }
        public static SqlConnection GetConnection(string ServerName = null, string DataBase = null, string UserName = null, string Password = null)
        {
            string ConnectionString = @"Data Source = " + ServerName + "; Initial Catalog = " + DataBase + "; User Id = " + UserName + "; Password=" + Password;

            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            try
            {
                if (sqlconn.State == ConnectionState.Open)
                {
                    sqlconn.Close();
                }
                sqlconn.Open();


            }
            catch (Exception er)
            {
                // msg = er.Message.ToString();
                sqlconn = null;
            }

            return sqlconn;
        }


        public static DataTable GetDataTable(string sql)
        {
            try
            {
                DataTable ptab;
                DataSet ds = new DataSet();
                using (conn)
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    ptab = ds.Tables["ptab"];
                }
                return ptab;


            }
            catch
            {

                return null;
            }

        }

        public static string RunSQL(string sql)
        {
            try
            {

                string x = "0";

                SqlDataReader dr;
                using (SqlConnection cn=OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);

                    //if (conn.State == ConnectionState.Open)
                    //    con.Close();

                    //    conn.Open();

                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        x = dr[0].ToString();
                    }
                    else
                    {
                        x = "0";
                    }
                }


                return x;
            }
            catch (Exception er) { return er.Message.ToString(); }
        }
        public static int ExecuteTCLCommand(string sql)
        {
            int x = 0;
            try
            {
                using (SqlConnection cn = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    x = cmd.ExecuteNonQuery();
                }
                return x;
            }
            catch
            {
                return 0;
            }

        }
        public static DateTime GetDateTime()
        {
            DateTime dt = DateTime.UtcNow.AddHours(5.50);

            return dt;

        }

        public static bool IsItNumberInt(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            // Regex isnumber = new Regex(@"((\d+)((\.\d{1,2})?))$");
            return !isnumber.IsMatch(inputvalue);
        }
        public static bool IsItNumber(string inputvalue)
        {
            //  Regex isnumber = new Regex("[^0-9]");
            Regex isnumber = new Regex(@"((\d+)((\.\d{1,2})?))$");
            return !isnumber.IsMatch(inputvalue);
        }
        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { return false; } // just dismiss errors but return false

        }
        public static List<string> GetACYrear()
        {
            List<string> acyrlist = new List<string>();

            int startYear = DateTime.Now.Year - 4;
            int endYear = DateTime.Now.Year + 4;


            for (int i = startYear; i <= endYear; i++)
            {
                acyrlist.Add(i.ToString() + " - " + (i + 1).ToString());

            }

            return acyrlist;

        }

    }

