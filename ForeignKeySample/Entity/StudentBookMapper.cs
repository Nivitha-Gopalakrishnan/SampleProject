using System;
using System.Collections.Generic;

namespace ForeignKeySample.Entity
{
    public partial class StudentBookMapper
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsPgstudent { get; set; }
        public bool IsActive { get; set; }

        public virtual Books Book { get; set; }
    }
}
