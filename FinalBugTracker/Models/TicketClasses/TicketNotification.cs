using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalBugTracker.Models.TicketClasses
{
    public class TicketNotification
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}