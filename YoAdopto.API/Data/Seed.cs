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
    
  }
}