using Microsoft.EntityFrameworkCore;
using YoAdopto.API.Models;

namespace YoAdopto.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }         
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationPhoto> PublicationPhotos { get; set; }
        public DbSet<PublicationType> PublicationTypes { get; set; }        

        protected override void OnModelCreating(ModelBuilder builder)
        {            
        }
    }
}