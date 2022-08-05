using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    [Table("User")]
    public class UserEntity: BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; } 
    }
}