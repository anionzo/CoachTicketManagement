using System;
using System.Collections.Generic;
using System.Text;

namespace CoachTicketManagement.Models
{
    public class Employee : Person
    {
        public virtual int IdTypeOfEmployee { get; set; }
        public virtual int IdPermissionGroup { get; set; }
        public virtual int IdAccount { get; set; }
    }
}
