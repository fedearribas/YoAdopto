using System;
using System.Collections.Generic;
using YoAdopto.API.Models;

namespace YoAdopto.API.Dtos
{
    public class UserToReturnDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }        
        public ICollection<Publication> Publications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public bool Active { get; set; }
    }
}