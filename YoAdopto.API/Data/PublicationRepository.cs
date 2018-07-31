using YoAdopto.API.Contracts;
using YoAdopto.API.Models;

namespace YoAdopto.API.Data
{
    public class PublicationRepository : RepositoryBase<Publication>, IPublicationRepository
    {
        public PublicationRepository(DataContext context) : base(context)
        {
        }
    }
}