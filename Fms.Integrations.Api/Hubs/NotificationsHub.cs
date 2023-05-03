using System.Threading.Tasks;
using Fms.Integrations.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using SignalRSwaggerGen.Enums;

namespace Fms.Integrations.Api.Hubs;


public interface INotificationsHubClient  
{  
    Task Notify(NotificationModel notification);  
}
[SignalRHub, Route("/notify")]
public class NotificationsHub: Hub<INotificationsHubClient>  
{  
    [SignalRMethod("Send", Operation.Get, tag:"demo")]
    public async Task SendMessageToCaller([FromQuery]string user,[FromQuery] string message)
        => await Clients.Caller.Notify(new NotificationModel("notify","content"));
}