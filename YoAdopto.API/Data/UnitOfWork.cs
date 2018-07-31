using System;
using YoAdopto.API.Models;

namespace YoAdopto.API.Data
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context = new DataContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<Publication> publicationRepository;        
        private GenericRepository<PublicationPhoto> publicationPhotoRepository;
        private GenericRepository<PublicationType> publicationTypeRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Publication> PublicationRepository
        {
            get
            {

                if (this.publicationRepository == null)
                {
                    this.publicationRepository = new GenericRepository<Publication>(context);
                }
                return publicationRepository;
            }
        }        

        public GenericRepository<PublicationPhoto> PublicationPhotoRepository
        {
            get
            {

                if (this.publicationPhotoRepository == null)
                {
                    this.publicationPhotoRepository = new GenericRepository<PublicationPhoto>(context);
                }
                return publicationPhotoRepository;
            }
        }

        public GenericRepository<PublicationType> PublicationTypeRepository
        {
            get
            {

                if (this.publicationTypeRepository == null)
                {
                    this.publicationTypeRepository = new GenericRepository<PublicationType>(context);
                }
                return publicationTypeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }    
}