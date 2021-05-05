using System;
/// <summary>
/// Summary description for RoleClass
/// </summary>
/// 
namespace nsManageUser
{
    public class clsRole :clsLogin
    {
      

        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public string RoleTitle { get; set; }
        public int Priority { get; set; }

    }
}