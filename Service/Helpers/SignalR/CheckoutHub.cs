using Microsoft.AspNetCore.SignalR;

namespace Service.Helpers.SignalR
{
    public class CheckoutHub : Hub
    {
        public async Task NotifyOrderStatusChanged(int checkoutId, string status)
        {
            await Clients.All.SendAsync("ReceiveOrderStatusUpdate", checkoutId, status);
        }

        public async Task JoinUserGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        public async Task LeaveUserGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
    }
}
