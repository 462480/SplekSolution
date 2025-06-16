using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Splek.Repository.Models
{
    public class Game
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            public string Body { get; set; }

            [ForeignKey("User")]
            public int UserId { get; set; }

            public int Likes { get; set; }
            public int Dislikes { get; set; }

            public DateTime CreatedAt { get; set; }

            // Navigation property (optioneel)
            public User User { get; set; }
        }
}
