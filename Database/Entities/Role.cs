using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BongOliver.API.Database.Entities
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        
        [MaxLength(32)]
        public string name { get; set; }

        public List<User> users {get; set;}

        public Role(){}

        public Role(int id, string name)
        {
            id = id;
            name = name;
        }
    }
}