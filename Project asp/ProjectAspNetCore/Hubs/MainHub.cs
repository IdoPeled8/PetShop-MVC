

namespace ProjectAspNetCore.Hubs
{
    public class MainHub : Hub
    {
        private static Collection<string> chatHistory = new Collection<string>();

        public async Task MessageAll(string userName, string message,string sendTime)
        {
            sendTime = DateTime.Now.ToString("g");
            string fullMessage = $"{sendTime} - {userName}: {message}";
            chatHistory.Add(fullMessage);
            await Clients.All.SendAsync("NewMessage", userName, message,sendTime);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ChatHistory", chatHistory);
            await base.OnConnectedAsync();
        }

        public async Task AddComments(string comment)
        {
            await Clients.All.SendAsync("newComment", comment);
        }

        public async Task RemoveComments(string comment)
        {
            await Clients.All.SendAsync("removeComment", comment);
        }
    }
}
