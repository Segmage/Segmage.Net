using Microsoft.AspNetCore.Mvc;
using Segmage;
using Segmage.Core.Extensions;
using Segmage.Models;

var builder = WebApplication.CreateBuilder(args);
var token=builder.Configuration.GetValue<string>("SegmageAccessToken");
builder.Services.AddSegmage(token);

var app = builder.Build();

//test
app.MapGet("/", async ( ) =>
{
    await SegmageApp.DefaultInstance.EventSender.SendLoginEventAsync("loginEventUniqName",new LoginEvent
    {
         UserId = "LoginUserID",SessionId = new Guid()
    });
   
});
app.Run();