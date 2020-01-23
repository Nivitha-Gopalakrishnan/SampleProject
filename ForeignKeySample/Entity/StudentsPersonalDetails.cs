using System;
using System.Collections.Generic;

namespace ForeignKeySample.Entity
{
    public partial class StudentsPersonalDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Department { get; set; }
        public DateTime Year { get; set; }

        public virtual Students User { get; set; }
    }
}
