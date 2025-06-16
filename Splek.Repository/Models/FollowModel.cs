using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Splek.Repository.Models;

namespace Splek.Repository.Models
{
    public class FollowModel
    {
        [Key]
        public int FollowingUserId { get; set; }
        public User FollowingUser { get; set; }
        
        [Key]
        public int FollowedUserId { get; set; }
        public User FollowedUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}