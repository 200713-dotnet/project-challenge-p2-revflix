using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RevFlix.Service.Models;

namespace RevFlix.Service.Repositories
{
  public class UserProfileRepository
  {
    private RevFlixDbContext _db;

    public UserProfileRepository(RevFlixDbContext db)
    {
      _db = db;
    }

    public UserProfile Get(string userId) {
      UserProfile userProfile = _db.UserProfile.FirstOrDefault(u => u.UserId == userId);
      userProfile.UserGenres = _db.UserGenre.Include(g => g.Genre).Where(g => g.UserProfile == userProfile).ToList();
      userProfile.WatchList = _db.UserMovie.Include(m => m.Movie).Where(m => m.UserProfile == userProfile).ToList();


      return userProfile;
    }

    public void Update(UserProfile userProfile) {
      _db.UserProfile.Update(userProfile);
      _db.SaveChanges();
    }
  }
}