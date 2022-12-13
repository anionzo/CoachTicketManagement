using CoachTicketManagement.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Data.Map
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id, "IDEMPLOYEE");
            Map(x => x.Name, "NAMEEMPLOYEE");
            Map(x => x.DateOfBirth, "DATEOFBIRTHEMPLOYEE");
            Map(x => x.Gender, "GENDEREMPLOYEE");
            Map(x => x.IdentityCard, "IDENTITYCARDEMPLOYEE");
            Map(x => x.Phone, "PHONEEMPLOYEE");
            Map(x => x.Email, "EMAILEMPLOYEE");
            Map(x => x.IdWard);
            Map(x => x.IdTypeOfEmployee, "IDTYPE");
            Map(x => x.IdPermissionGroup);
            Map(x => x.IdAccount);
            Table("tbl_Employee");
        }
    }
}
