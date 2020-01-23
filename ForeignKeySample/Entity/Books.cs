using System;
using System.Collections.Generic;

namespace ForeignKeySample.Entity
{
    public partial class Books
    {
        public Books()
        {
            StudentBookMapper = new HashSet<StudentBookMapper>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }

        public virtual ICollection<StudentBookMapper> StudentBookMapper { get; set; }
    }
}
