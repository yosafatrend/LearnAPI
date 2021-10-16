using System;
using System.Collections.Generic;

#nullable disable

namespace LearnAPI2.Models
{
    public partial class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsComplete { get; set; }
        public DateTime? DueAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string CreatedByEmail { get; set; }

        public virtual User CreatedByEmailNavigation { get; set; }
    }
}
