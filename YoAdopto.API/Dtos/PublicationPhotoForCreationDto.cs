using System;
using Microsoft.AspNetCore.Http;

namespace YoAdopto.API.Dtos
{
    public class PublicationPhotoForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public PublicationPhotoForCreationDto()
        {
            this.DateAdded = DateTime.Now;
        }
    }
}