namespace BongOliver.API.DTOs.UserDTO
{
    public class UserDto
    {
        public int id {get; set;}
        public string? firstname {get; set;}
        public string? lastname {get; set;}
        public string? image {get; set;}
        public string gender {get; set;}
        public DateTime? dateOfBirth {get; set;}
        public string username {get; set;}
        public string phoneNumber {get; set;}
        public int role_id {get; set;}
        public DateTime createAt {get; set;}
        public DateTime updateAt {get; set;}
    }
}