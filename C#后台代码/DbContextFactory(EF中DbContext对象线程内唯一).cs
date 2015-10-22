using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign.MVCUI
{
    public class DbContextFactory
    {
        public static ItcastContext DbContextCreate()
        {
      
            //DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            ItcastContext dbContext = (ItcastContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new ItcastContext();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
       }
    }
}
