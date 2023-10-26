using Microsoft.AspNetCore.Mvc;

using DaprTimeout.Actors;
using DaprTimeout.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDaprClient();
builder.Services.AddControllers().AddDapr();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDaprSidekick(builder.Configuration);
}

RegisterActors(builder.Services);

var app = builder.Build();
app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapActorsHandlers();
});

app.Run();

void RegisterActors(IServiceCollection services)
{
    services.AddTransient<IActorFactory<ITimeoutActor>, ActorFactory<ITimeoutActor, TimeoutActor>>(); //possibility of automated Registration
    services.AddActors(opt =>
    {
        opt.Actors.RegisterActor<TimeoutActor>();
    });
}