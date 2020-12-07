using System;
using System.Collections.Generic;

namespace TermProject.Models
{
    public partial class Candidates
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PartyId { get; set; }
        public int StateId { get; set; }

        public virtual Party Party { get; set; }
        public virtual State State { get; set; }
    }
}
