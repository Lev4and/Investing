using Investing.HttpClients;
using Investing.ResourceWebApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClients();
builder.Services.AddApiControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCorsPolicy();
app.Run();
