using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore_Assignment_2.Models
{
    public enum BadgeTier
    {
        Standard = 0,
        VIP = 1
    }

    internal class Badge
    {
        public int Id { get; set; }
        public int BadgeNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    }
}
