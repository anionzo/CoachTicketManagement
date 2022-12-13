using CoachTicketManagement.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Data.Map
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(x => x.Id, "IDCLIENT");
            Map(x => x.Name, "NAMECLIENT");
            Map(x => x.IdWard);
            Map(x => x.Phone, "PHONECLIENT");
            Map(x => x.DateOfBirth, "DATEOFBIRTHCLIENT");
            Map(x => x.Gender, "GENDERCLIENT");
            Map(x => x.IdentityCard, "IDENTITYCARDCLIENT");
            Map(x => x.Email, "EMAILCLIENT");
            Table("TBL_CLIENT");
        }
    }
}
