using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademtManagementEFApp.Helpers
{
    public class SqlHelper
    {
        private static readonly string _connectionString = "Server=DESKTOP-MFDQNKF\\SQLEXPRESS;Database=AcademyDB;Trusted_Connection=True;TrustServerCertificate=True";
        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
