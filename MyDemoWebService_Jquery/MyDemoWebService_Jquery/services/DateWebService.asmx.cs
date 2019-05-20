using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyDemoWebService_Jquery
{
    /// <summary>
    /// Summary description for DateWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DateWebService : System.Web.Services.WebService
    {

        [WebMethod]        
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
