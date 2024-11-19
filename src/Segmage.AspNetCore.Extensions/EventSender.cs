using Segmage.AspNetCore.Extensions.Exceptions;
using Segmage.Models;

namespace Segmage.AspNetCore.Extensions;

public class EventSender:Segmage.Services.EventSender
{
    public EventSender(AppOptions options) : base(options)
    {
    }

    public override async Task<BaseEvent> BeginExecutionAsync(BaseEvent @event)
    {
        var session =await GetSession();
        if (session == null) throw new SessionNullException("Please set Session Id");
        @event.SessionId = session.Id;
        @event.UserId = session.UserId;
        @event.SessionId = Guid.NewGuid().ToString();
        return @event;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="session"></param>
    public async Task SetSession(SgSession session)
    {
        await SegmageHttpContext.SetSgSession(session);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>SgSession</returns>
    private async Task<SgSession?> GetSession()
    {
        return await SegmageHttpContext.GetSgSession();
    }
}