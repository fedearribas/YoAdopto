using System.Collections.Generic;

namespace YoAdopto.API.Dtos
{
    public class PublicationForListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationTypeId { get; set; }
        public ICollection<string> PhotoUrls { get; set; }
        public int UserId { get; set; }        
        public string State { get; set; }
        public string City { get; set; }
        public bool PublicationEnded { get; set; }
    }
}