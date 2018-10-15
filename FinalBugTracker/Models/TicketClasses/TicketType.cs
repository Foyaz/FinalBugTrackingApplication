using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalBugTracker.Models.TicketClasses
{
    public class TicketType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }
    }
}