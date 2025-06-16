using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Splek.Logic.Services;
using Splek.Repository.Models;

namespace Logic
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public GameService Game { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
