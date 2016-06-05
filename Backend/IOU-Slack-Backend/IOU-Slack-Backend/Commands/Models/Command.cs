using IOU_Slack_Backend.Dtos;

namespace IOU_Slack_Backend.Commands.Models
{
    public abstract class Command
    {
        public CommandType Type { get; set; }

        public const string ValidationToken = "QV9RtOG4wtlriresDpig08zx";
        public string[] Parameters { get; set; }

        public CommandRequest CommandRequest { get; set; }
        public CommandResponse CommandResponse { get; set; }

        public Command(string[] parameters, CommandRequest commandRequest)
        {
            this.Parameters = parameters;
            this.CommandRequest = commandRequest;

            this.CommandResponse = new CommandResponse();
        }

        public bool ValidateToken()
        {
            return this.CommandRequest.Token == Command.ValidationToken;
        }

        public abstract void Execute();
    }
}