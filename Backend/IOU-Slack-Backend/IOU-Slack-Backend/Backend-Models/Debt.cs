﻿
namespace IOU_Slack_Backend
{
    public class Debt
    {
        public int ID { get; set; }

        public int EventID { get; set; }
        public string UserID { get; set; }

        public double AmountDue { get; set; }
    }
}