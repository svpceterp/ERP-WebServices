using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ErrorClass
/// </summary>
namespace ERP
{
   

   public class MessageClass
    {
        public string ReurnID { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorNo { get; set; }
        public string Status { get; set; }
    }
}