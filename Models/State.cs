using System;
using System.Collections.Generic;

namespace TermProject.Models
{
    public partial class State
    {
        public State()
        {
            Candidates = new HashSet<Candidates>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidates> Candidates { get; set; }
    }
}
