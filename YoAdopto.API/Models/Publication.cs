using System;
using System.Collections.Generic;

namespace YoAdopto.API.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationTypeId { get; set; }
        public PublicationType PublicationType { get; set; }
        public ICollection<PublicationPhoto> Photos { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool PublicationEnded { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
    }
}