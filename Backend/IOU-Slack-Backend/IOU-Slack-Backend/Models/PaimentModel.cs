namespace IOU_Slack_Backend.Models
{
    public struct PaimentModel
    {
        public int Amount { get; set; }
        public string ReceivingUserId { get; set; }
        public string PayingUserId { get; set; }
        public string EventId { get; set; }
    }
}