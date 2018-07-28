using System;
using System.Collections.Generic;

namespace YoAdopto.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Publication> Publications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public bool Active { get; set; }
    }
}