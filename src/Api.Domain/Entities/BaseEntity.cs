using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        // [Key]
        private DateTime? _createdAt;
        public int Id { get; set; }
        public DateTime? CreatedAt { get{ return _createdAt; } set { _createdAt  =  (value == null? DateTime.UtcNow : value); } }

        public DateTime? UpdateAt { get; set; }
    }
}