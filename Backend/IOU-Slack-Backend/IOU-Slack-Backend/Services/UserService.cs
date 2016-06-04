using System.Collections.Generic;
using System.Linq;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;

namespace IOU_Slack_Backend.Services
{
    public class UserService
    {
        public static List<User> GetAllUsers()
        {
            using (var db = new SystemDbContext())
            {
                return db.Users.ToList();
            }
        }

        public void CreateUser(User user)
        {
            using (var db = new SystemDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void DeleteUser(string userId)
        {
            using (var db = new SystemDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user == null)
                    throw HttpResponseExceptionHelper.Create("No user exist with this ID", HttpStatusCode.BadRequest);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}