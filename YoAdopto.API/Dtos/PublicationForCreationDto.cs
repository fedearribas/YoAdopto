using System.Collections.Generic;

namespace YoAdopto.API.Dtos
{
    public class PublicationForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationTypeId { get; set; }
        public ICollection<PublicationPhotoForCreationDto> Photos { get; set; }
        public int UserId { get; set; }
        public string State { get; set; }
        public string City { get; set; }        
    }
}