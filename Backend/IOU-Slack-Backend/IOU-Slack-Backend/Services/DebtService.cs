using System.Collections.Generic;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;
using System.Linq;
using System;

namespace IOU_Slack_Backend.Services
{
    public class DebtService : AbstractService<Debt>
    {
        public List<Debt> GetUnpaidDebts(string eventID)
        {
            using (var db = new SystemDbContext())
            {
                return db.Debts.Where(x => x.AmountDue > 0 && x.EventID == eventID).ToList();
            }
        } 

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

        public void ReimburseDebt(int eventID, string userID, double payedAmount)
        {
            using (var db = new SystemDbContext())
            {
                var debt = db.Debts.Single(d => d.ID == eventID && d.UserID == userID);

                if (debt != null)
                {
                    var updatedAmount = debt.AmountDue - payedAmount;

                    if (updatedAmount < 0)
                    {
                        throw HttpResponseExceptionHelper.Create(
                            string.Format("You can't reimburse more than your {0}$ debt", debt.AmountDue),
                            HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        debt.AmountDue = updatedAmount;
                        db.SaveChanges();
                    }
                }
            }
        }

        public override void Update(Debt element)
        {
            throw new NotImplementedException();
        }
    }
}