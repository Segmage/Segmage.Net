using Segmage;
using Segmage.Core.Extensions;
using Segmage.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSegmage("TEST_INSTANCE", async options =>await options.FromFileAsync("test-conf.json"));
builder.Services.AddSegmage("TEST_INSTANCE-1", async options => await options.FromFileAsync("test-1-conf.json"));

var app = builder.Build();

app.MapGet("/", async () =>
{
    await SegmageApp.DefaultInstance.EventSender.SendLoginEventAsync("loginEventUniqName",new LoginEvent
    {
         UserId = "LoginUserID",SessionId = "SessionId"
    });
});
app.Run();