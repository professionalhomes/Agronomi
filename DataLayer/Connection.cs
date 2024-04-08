using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class Connection
    {
        public static string stringConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
    }
}