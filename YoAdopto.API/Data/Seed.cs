using System.Collections.Generic;
using System.Linq;
using YoAdopto.API.Models;
using Newtonsoft.Json;
using CryptoHelper;

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
  }
}