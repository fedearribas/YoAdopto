using System.Collections.Generic;
using System.Linq;
using YoAdopto.API.Models;
using Newtonsoft.Json;
using CryptoHelper;
using System;

namespace YoAdopto.API.Data
{
  public class Seed
  {
    private readonly DataContext _context;
    public Seed(DataContext context)
    {
      this._context = context;
    }

    public void SeedUsers()
    {
        if (_context.Users.Any()) 
        {
            return;
        }

        _context.Users.RemoveRange(_context.Users);
        _context.SaveChanges();

        var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
        var users = JsonConvert.DeserializeObject<List<User>>(userData);

        foreach (var user in users)
        {         
           user.Password = Crypto.HashPassword(user.Password);
            _context.Add(user);
        }

        _context.SaveChanges();
    }

    public void SeedPublicationTypes()
    {
        if (_context.PublicationTypes.Any())
            return;

        _context.PublicationTypes.RemoveRange(_context.PublicationTypes);
        _context.SaveChanges();
        var types = new List<PublicationType> {
            new PublicationType {
                Id = 1,
                Description = "Perdidos",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Active = true
            },
            new PublicationType {
                Id = 2,
                Description = "Encontrados",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Active = true
            },
            new PublicationType {
                Id = 3,
                Description = "Adopciones",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Active = true
            }
        };       

        _context.PublicationTypes.AddRange(types);
        _context.SaveChanges();
    }

    public void SeedPublications()
    {
        if (_context.Publications.Any())
            return;

        _context.Publications.RemoveRange(_context.Publications);
        _context.SaveChanges();

        var publication = new Publication {
            Id = 1,
            Title = "Se perdio Lenteja",
            Description = "Se perdio mi perro Lenteja, por favor si alguien lo vio comuniquese conmigo.",
            PublicationTypeId = 1,
            UserId = 1,
            State = "Buenos Aires",
            City = "Mar del Plata",
            ContactPhone = "555123456",
            ContactEmail = "admin@yoadopto.com",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Active = true,
            Photos = new List<PublicationPhoto> {
                new PublicationPhoto {
                    Id = 1,
                    Description = "test",
                    DateAdded = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Url = "https://images.pexels.com/photos/356378/pexels-photo-356378.jpeg"
                },
                  new PublicationPhoto {
                    Id = 2,
                    Description = "test",
                    DateAdded = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Url = "https://images.theconversation.com/files/229565/original/file-20180727-106505-satvt1.jpg"
                }
            }
        };

        _context.Publications.Add(publication);
        _context.SaveChanges();
    }
    
  }
}