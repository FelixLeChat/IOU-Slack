using System;

namespace IOU_Slack_Backend
{
    public class Transaction
    {
        public int Id { get; set; }
        public string GroupId { get; set; }
        public string ReceivingUserId { get; set; }
        public string PayingUserId { get; set; }
        public double Amount { get; set; }
        public double AmountDue { get; set; }
        public DateTime DueDate { get; set; }
    }
}