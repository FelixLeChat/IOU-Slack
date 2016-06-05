using System.Collections.Generic;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;

namespace IOU_Slack_Backend.Services
{
    public class DebtService : AbstractService<Debt>
    {
        public override List<Debt> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override Debt Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Debt element)
        {
            throw new System.NotImplementedException();
        }

        public override void Create(Debt element)
        {
            using (var db = new SystemDbContext())
            {
                if (element.AmountDue == 0)
                    throw HttpResponseExceptionHelper.Create("Do you really want to set up a 0$ Debt ?",
                        HttpStatusCode.BadRequest);

                db.Debts.Add(element);
                db.SaveChanges();
            }
        }

        public override void Update(Debt element)
        {
            throw new System.NotImplementedException();
        }
    }
}