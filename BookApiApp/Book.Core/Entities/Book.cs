﻿using Book.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Entities
{
    public class Book : BaseAuditableEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
