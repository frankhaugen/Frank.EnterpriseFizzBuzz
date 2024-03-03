using Frank.EnterpriseFizzBuzz;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());
builder.Services.AddFizzBuzz();

var app = builder.Build();

await app.RunAsync();