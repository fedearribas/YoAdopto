using System;

namespace YoAdopto.API.Models
{
    public class PublicationType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }        
    }
}