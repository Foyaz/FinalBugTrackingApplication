using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalBugTracker.Models.TicketClasses
{
    public class TicketComment
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public string Body { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? Updated { get; set; }

        public string UpdateReason { get; set; }
    }
  
}