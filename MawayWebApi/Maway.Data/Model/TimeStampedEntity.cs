using System;
using System.Collections.Generic;
using System.Text;

namespace Maway.Data.Model
{
    public class TimeStampedEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
