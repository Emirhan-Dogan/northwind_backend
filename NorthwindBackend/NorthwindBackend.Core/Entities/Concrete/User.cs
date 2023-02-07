using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    [Table("Users")]
    public class User : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")] 
        public string LastName { get; set; }
        
        [Column("Email")] 
        public string Email { get; set; }
        
        [Column("Status")] 
        public bool Status { get; set; }
        
        [Column("PasswordSalt")] 
        public byte[] PasswordSalt { get; set; }
        
        [Column("PasswordHash")] 
        public byte[] PasswordHash { get; set; }
    }
}
