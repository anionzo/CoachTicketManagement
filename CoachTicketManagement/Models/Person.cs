using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Models
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Gender { get; set; }
        public virtual string IdentityCard { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual int IdWard { get; set; }
    }
}
