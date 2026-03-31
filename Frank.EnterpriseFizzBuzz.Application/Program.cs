using Frank.EnterpriseFizzBuzz.Hosting;
using Frank.EnterpriseFizzBuzz.Rules;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());
builder.Services.AddFizzBuzz<ulong>(ruleSet =>
{
    ruleSet.Add<FizzRule>();
    ruleSet.Add<BuzzRule>();
    ruleSet.Add<FooRule>();
});

var app = builder.Build();

await app.RunAsync();