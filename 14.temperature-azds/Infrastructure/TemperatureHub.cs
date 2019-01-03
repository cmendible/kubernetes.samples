using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Temperature.Infrastructure
{
    public class TemperatureHub : Hub
    {
        public async Task SendMessage(object message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}