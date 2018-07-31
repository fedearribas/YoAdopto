using System;
using System.Threading.Tasks;
using YoAdopto.API.Data;
using YoAdopto.API.Models;

namespace YoAdopto.API.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<User> UserRepository { get; }

        GenericRepository<Publication> PublicationRepository { get; }
           

        GenericRepository<PublicationPhoto> PublicationPhotoRepository { get; }
        
        GenericRepository<PublicationType> PublicationTypeRepository { get; }        

        Task<bool> Save();
    }
}