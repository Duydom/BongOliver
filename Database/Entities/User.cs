using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BongOliver.API.Database.Entities
{
    public class User
    {
        [Key]
        public int id {get; set;}
        [Required]
        [StringLength(128)]
        public string? firstname {get; set;}
        [Required]
        [StringLength(128)]
        public string? lastname {get; set;}
        public string? image {get; set;}
        public string gender {get; set;}
        public DateTime? dateOfBirth {get; set;}

        [Required]
        [StringLength(32)]
        public string username {get; set;}

        [Required]
        [StringLength(16)]
        public string phoneNumber {get; set;}
        public int role_id {get; set;}
        // public List<Role> role {get; set;}
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public DateTime createAt {get; set;}
        public DateTime updateAt {get; set;}
        // public string token {get; set;}
    }
}