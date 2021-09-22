using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ADONETCRUDAPI2.ConnectionString
{
    public class ConnectionString
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["API"].ConnectionString;
        }
    }
}