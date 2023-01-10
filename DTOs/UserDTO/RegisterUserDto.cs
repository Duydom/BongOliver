using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BongOliver.API.DTOs.UserDTO
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(256)]
        public string username {get; set;}
        [Required]
        [StringLength(256)]
        public string password {get; set;}
        [Required]
        [StringLength(256)]
        public string cfpassword {get; set;}
        [Required]
        [StringLength(128)]
        public string? firstname {get; set;}
        [Required]
        [StringLength(128)]
        public string? lastname {get; set;}
        [Required]
        public string? image {get; set;}
        [Required]
        [StringLength(6)]
        public string gender {get; set;}
        [Required]
        public DateTime? dateOfBirth {get; set;}
        [Required]
        [StringLength(16)]
        public string phoneNumber {get; set;}
    }
}