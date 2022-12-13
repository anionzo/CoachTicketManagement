using CoachTicketManagement.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Data.Map
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Id(x => x.Id, "IDACCOUNT");
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.IdEmployee);
            Table("tbl_Account");
        }
    }
}
