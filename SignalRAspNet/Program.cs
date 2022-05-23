using SignalRAspNet;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR().AddJsonProtocol(options => { options.PayloadSerializerOptions.PropertyNamingPolicy = null; }).AddNewtonsoftJsonProtocol(); ;

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.All;
        options.AllowInputFormatterExceptionMessages = false;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<Hub1>("/hub1", options => { options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;  });
app.Run();
