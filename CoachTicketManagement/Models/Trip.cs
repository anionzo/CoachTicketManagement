using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Models
{
    public class Trip
    {
        public int IDTRIP { get; set; }
        public int IDTIME { get; set; }
        public int IDBUSLINE { get; set; }
        public int IDEMPLOYEE { get; set; }
        public int IDCOACH { get; set; }
        public int IDDRIVER { get; set; }
        public DateTime DEPARTUREDAY { get; set; }
        public int AMOUNTEMPTYSEAT { get; set; }

    }
}
