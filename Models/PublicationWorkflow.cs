using System;

namespace YoAdopto.API.Models
{
    public class PublicationWorkflow
    {
        public int Id { get; set; }
        public int PublicationTypeId { get; set; }
        public PublicationType PublicationType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
    }
}