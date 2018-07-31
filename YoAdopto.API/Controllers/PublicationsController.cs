using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YoAdopto.API.Contracts;
using YoAdopto.API.Dtos;
using YoAdopto.API.Helpers;
using YoAdopto.API.Models;

namespace YoAdopto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private Cloudinary _cloudinary;
        public PublicationsController(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cloudinaryConfig = cloudinaryConfig;

             Account account = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetPublications(PublicationParams publicationParams)
        {
            //var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var userFromRepo = await unitOfWork.UserRepository.GetById(currentUserId);

            //publicationParams.UserId = currentUserId;

            var publications = await unitOfWork.PublicationRepository.GetPaged(filter: p =>
             p.PublicationTypeId == publicationParams.PublicationTypeId,
             includeProperties: "PublicationPhotos",
             pageNumber: publicationParams.PageNumber,
             pageSize: publicationParams.PageSize);

            var publicationsToReturn = mapper.Map<IEnumerable<PublicationForListDto>>(publications);

            Response.AddPagination(publications.CurrentPage, 
                publications.PageSize, 
                publications.TotalCount, 
                publications.TotalPages);

            return Ok(publicationsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublication(int id)
        {
            var publication = await unitOfWork.PublicationRepository.Get(p => p.Id == id);
            if (publication == null)
                return NotFound();
            
            var publicationToReturn = mapper.Map<PublicationForListDto>(publication);
            return Ok(publicationToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublication([FromBody]PublicationForCreationDto publicationForCreationDto)
        {
            var publication = mapper.Map<Publication>(publicationForCreationDto);
            unitOfWork.PublicationRepository.Create(publication);

            foreach(var photoDto in publicationForCreationDto.Photos)
            {                
                var file = photoDto.File;
                var uploadResult = new ImageUploadResult();

                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream),
                            Transformation = new Transformation().Width(1000).Height(1000).Crop("fill").Gravity("face")
                        };
                        
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }

                photoDto.Url = uploadResult.Uri.ToString();
                photoDto.PublicId = uploadResult.PublicId;

                var photo = mapper.Map<PublicationPhoto>(photoDto);
                photo.Publication = publication;
                publication.Photos.Add(photo);
            }
             if (await unitOfWork.Save())
            {
                var publicationToReturn = mapper.Map<PublicationForListDto>(publication);
                return CreatedAtRoute("GetPublication", new { id = publication.Id }, publicationToReturn);
            }
            
            return BadRequest("Hubo un problema al cargar la publicación.");
        }

    }
}