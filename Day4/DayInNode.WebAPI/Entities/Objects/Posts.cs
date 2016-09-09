using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayInNode.WebAPI.Entities.Objects {
    [Table("POSTS")]
    public class Posts {
        [Key]
        public int ID { get; set; }
        
        public int Likes { get; set; }
    }
}