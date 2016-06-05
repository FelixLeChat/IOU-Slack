using System.Collections.Generic;
using System.Linq;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Models;

namespace IOU_Slack_Backend.Services
{
    public class TransactionService: AbstractService<Transaction>
    {
        public void Pay(PaimentModel paiment, TransactionType transactionType)
        {
            var transaction = Get(paiment.EventId, paiment.PayingUserId);
            if (transaction == null)
                throw HttpResponseExceptionHelper.Create(
                    "No transaction found with Event : " + paiment.EventId + " And user id : " + paiment.PayingUserId,
                    HttpStatusCode.BadRequest);

            if (paiment.Amount < 0)
                throw HttpResponseExceptionHelper.Create("YOU CANNOT CREATE MONEY!!!", HttpStatusCode.BadRequest);

            transaction.AmountDue -= paiment.Amount;
            Update(transaction);
        }

        public override List<Transaction> GetAll()
        {
            using (var db = new SystemDbContext())
            {
                return db.Transactions.ToList();
            }
        }

        public Transaction Get(string eventID, string payerID)
        {
            using (var db = new SystemDbContext())
            {
                return db.Transactions.FirstOrDefault(x => x.EventID == eventID && x.PayingUserId == payerID);
            }
        }

        public override Transaction Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Transaction element)
        {
            throw new System.NotImplementedException();
        }

        public override void Create(Transaction element)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Transaction element)
        {
            if (element == null)
                throw HttpResponseExceptionHelper.Create("Null element given when updating Transaction",
                    HttpStatusCode.BadRequest);

            using (var db = new SystemDbContext())
            {
                var transaction = db.Transactions.FirstOrDefault(x => x.TransactionID == element.TransactionID);
                if (transaction == null)
                    throw HttpResponseExceptionHelper.Create(
                        "Transaction not found with given id : " + element.TransactionID, HttpStatusCode.BadRequest);

                // check for negative amount due or paid debt before updating
                if (transaction.AmountDue < 0)
                    throw HttpResponseExceptionHelper.Create("You paid too much", HttpStatusCode.BadRequest);

                if (transaction.AmountDue == 0)
                    transaction.IsPaid = true;

                // Only save amount Due
                transaction.AmountDue = element.AmountDue;
                db.SaveChanges();
            }
        }
    }
}