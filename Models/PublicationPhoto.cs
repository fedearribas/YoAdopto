using System;

namespace YoAdopto.API.Models
{
    public class PublicationPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
        public Publication Publication { get; set; }
        public int PublicationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}