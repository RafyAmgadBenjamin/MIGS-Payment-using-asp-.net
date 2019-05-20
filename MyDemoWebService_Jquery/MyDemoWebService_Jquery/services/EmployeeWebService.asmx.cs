using MyDemoWebService_Jquery.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyDemoWebService_Jquery.services
{
    /// <summary>
    /// Summary description for EmployeeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeWebService : System.Web.Services.WebService
    {
        List<EmployeeUtil> list = new List<EmployeeUtil>();

        
        public EmployeeWebService()
        {            
            list.Add(new EmployeeUtil { Id = 1, Name = "Peter", Salary = 22000 });
            list.Add(new EmployeeUtil { Id = 2, Name = "Mark", Salary = 24000 });
            list.Add(new EmployeeUtil { Id = 3, Name = "James", Salary = 28000 });
            list.Add(new EmployeeUtil { Id = 4, Name = "Simon", Salary = 29000 });
            list.Add(new EmployeeUtil { Id = 5, Name = "David", Salary = 19000 });
        }

        [WebMethod]
       public List<EmployeeUtil> GetAllEmployees()
        {
            return list;
        }

        [WebMethod]
        public EmployeeUtil GetEmployeeDetails(string employeeId)
        {
            int empId = Int32.Parse(employeeId);
            EmployeeUtil emp = list.Single(e => e.Id == empId);
            return emp;
        }
    }
}
