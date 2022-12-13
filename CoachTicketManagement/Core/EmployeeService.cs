using CoachTicketManagement.Data;
using CoachTicketManagement.Models;
using CoachTicketManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Core
{
    public class EmployeeService
    {
        #region Singleton
        private static EmployeeService instance;
        public static EmployeeService Instance
        {
            get { if (instance == null) instance = new EmployeeService(); return instance; }
            private set { instance = value; }
        }
        private EmployeeService() { }
        #endregion

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using(var session = NHibernateHelper.OpenSession())
            {
                employees = session.Query<Employee>().ToList();
            }    
            return employees;
        }
        public string CheckPermissionByID(int idEmployee)
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                return session.CreateSQLQuery("select pg.NAMEGROUP from tbl_Employee e, tbl_PermissionGroup pg where e.IDEMPLOYEE = :idEmployee and e.IDPermissionGroup = pg.IDPERMISSIONGROUP").SetParameter("idEmployee", idEmployee).UniqueResult<string>();
            }    
        }

    }
}
