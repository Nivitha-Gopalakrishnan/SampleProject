using System;
using System.Collections.Generic;

namespace ForeignKeySample.Entity
{
    public partial class Students
    {
        public Students()
        {
            StudentsPersonalDetails = new HashSet<StudentsPersonalDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }

        public virtual ICollection<StudentsPersonalDetails> StudentsPersonalDetails { get; set; }
    }
}
