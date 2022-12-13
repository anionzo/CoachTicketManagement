using System;
using System.Collections.Generic;
using System.Text;

namespace CoachTicketManagement.Models
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual int IdEmployee { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Permission { get; set; }
    }
}
