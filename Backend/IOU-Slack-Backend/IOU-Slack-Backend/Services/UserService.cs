using System.Collections.Generic;
using System.Linq;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;

namespace IOU_Slack_Backend.Services
{
    public class UserService : AbstractService<User>
    {

        public override List<User> GetAll()
        {
            using (var db = new SystemDbContext())
            {
                return db.Users.ToList();
            }
        }

        public override User Get(string id)
        {
            using (var db = new SystemDbContext())
            {
                return db.Users.FirstOrDefault(x => x.UserId == id);
            }
        }

        public override void Delete(User element)
        {
            using (var db = new SystemDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == element.UserId);
                if (user == null)
                    throw HttpResponseExceptionHelper.Create("No user exist with this ID", HttpStatusCode.BadRequest);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public override void Create(User element)
        {
            using (var db = new SystemDbContext())
            {
                db.Users.Add(element);
                db.SaveChanges();
            }
        }

        public override void Update(User element)
        {
            throw new System.NotImplementedException();
        }
    }
}