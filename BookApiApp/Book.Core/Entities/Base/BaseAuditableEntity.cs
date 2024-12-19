﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Entities.Base
{
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt  { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
