using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BongOliver.API.DTOs.UserDTO
{
    public class AuthUserDto
    {
        [Required]
        [MaxLength(256)]
        public String username {get; set;}
        [Required]
        [MaxLength(256)]
        public String password {get; set;}        
    }
    public class UserTokenDto
    {
        public String username {get; set;}
        public String token {get; set;}        
    }
}