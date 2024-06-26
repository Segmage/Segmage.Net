using Microsoft.AspNetCore.Mvc;
using Segmage;
using Segmage.Core.Extensions;
using Segmage.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSegmage("TEST_INSTANCE-1", async options =>
{
    options=await AppOptions.FromFileAsync("test-1-conf.json");
});

var app = builder.Build();

//test
app.MapGet("/", async ( ) =>
{
    await SegmageApp.DefaultInstance.EventSender.SendLoginEventAsync("loginEventUniqName",new LoginEvent
    {
         UserId = "LoginUserID",SessionId = "SessionId"
    });
});
app.Run();