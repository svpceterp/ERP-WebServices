using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP;
/// <summary>
/// Summary description for RoleClass
/// </summary>
public class RoleClass:PersonalClass
{
    public int RoleID { get; set; }
    public string RoleCode { get; set; }
    public string RoleTitle { get; set; }
    public int Priority { get; set; }
}