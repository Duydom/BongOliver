namespace BongOliver.API.DTOs.UserDTO
{
    public class UserUpdateDto
    {
        public string? firstname {get; set;}
        public string? lastname {get; set;}
        public string? image {get; set;}
        public string gender {get; set;}
        public DateTime? dateOfBirth {get; set;}
        public string phoneNumber {get; set;}
    }
}