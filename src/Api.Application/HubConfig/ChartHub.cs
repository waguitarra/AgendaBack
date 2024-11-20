using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Api.Application.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task SendMessage(string usuario, string mensagem)
        {
            await Clients.All.SendAsync("ReceiveMessage", usuario, mensagem);
        }

    }
}
