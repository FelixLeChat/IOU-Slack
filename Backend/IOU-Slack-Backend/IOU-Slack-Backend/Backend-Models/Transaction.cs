using System;

namespace IOU_Slack_Backend
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionID { get; set; }
        public string ReceivingUserId { get; set; }
        public string PayingUserId { get; set; }
        public float Amount { get; set; }
        public float AmountDue { get; set; }
        public string EventID { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}