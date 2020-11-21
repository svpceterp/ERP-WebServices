using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPNameSpace;

/// <summary>
/// Summary description for UserClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class UserClass:UserModuleRoleClass
    {
        public string Password { get; set; }

        public string urole { get; set; }

        

    }


}