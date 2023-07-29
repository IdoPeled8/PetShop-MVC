

namespace ProjectAspNetCore.Hubs
{
    public class ChatHub : Hub
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
    }
}
