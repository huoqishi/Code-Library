using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign.MVCUI
{
    public class dbContext
    {
        //线程内唯一
        public static IDbConnection Conn
        {
            get
            {
                //DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
                IDbConnection conn = (MySqlConnection)CallContext.GetData("Conn");
                if (conn == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
                    conn = new MySqlConnection(connectionString);
                    CallContext.SetData("Conn", conn);
                }
                return conn;
            }
        }

    }
}
