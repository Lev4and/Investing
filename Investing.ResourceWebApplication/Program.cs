using Investing.EntityFramework;
using Investing.HttpClients;
using Investing.ResourceWebApplication;
using Investing.ResourceWebApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddHttpClients();
builder.Services.AddEntityFramework();
builder.Services.AddApiControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseSerilogLogging();
app.UseDatabaseMigration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCorsPolicy();
app.Run();
