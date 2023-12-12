using Segmage;
using Segmage.Core.Extensions;
using Segmage.Credential;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSegmage("TEST_INSTANCE", async options =>await options.FromFileAsync("test-conf.json"));
builder.Services.AddSegmage("TEST_INSTANCE-1", async options =>await options.FromFileAsync("test-1-conf.json"));

var app = builder.Build();

app.MapGet("/", async () =>
{
    
});
app.Run();