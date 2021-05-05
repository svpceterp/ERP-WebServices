using System;
/// <summary>
/// Summary description for UserRoleClass
/// </summary>
/// 
namespace nsManageUser
{
    public class clsUserModuleRole : clsRole
    {
        public string UserModuleRole { get; set; }

        public static string GetUserModuleRole(string uid, string ModuleCode = "ERP")
        {

            string MRole = "Guest";
            try
            {
               
                string sql = "select dbo.funGetUserModuleRole('" + uid + "','" + ModuleCode + "') as ModuleRole";
                MRole = ConnectionDB.RunSQL(sql);

            }
            catch (Exception er)
            {

                MRole = "Error : " + er.Message.ToString();
            }
            return MRole;
        }


    }
}