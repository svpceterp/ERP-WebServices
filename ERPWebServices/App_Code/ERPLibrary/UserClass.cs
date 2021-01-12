using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERP;

/// <summary>
/// Summary description for UserClass
/// </summary>
/// 
namespace ERP
{
    public class UserClass:UserModuleRoleClass
    {
        public string Password { get; set; }

        public string UserRole { get; set; }

        public string ProfEmailID { get; set; }

    }


}