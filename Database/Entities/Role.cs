using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BongOliver.API.Database.Entities
{
    public class Role
    {
        // [Key]
        // [System.ComponentModel.DataAnnotations.KeyAttribute()]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        
        [MaxLength(32)]
        public string name { get; set; }

        // public List<RoleUser> RoleUsers {get; set; }

        public Role(){}

        public Role(int id, string name)
        {
            id = id;
            name = name;
        }
    }
}