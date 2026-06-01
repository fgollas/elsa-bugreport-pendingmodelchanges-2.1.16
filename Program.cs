// See https://aka.ms/new-console-template for more information

using Elsa.Persistence.EntityFramework.Core;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;

Console.WriteLine("Reproducing Elsa Custom Schema migrations issue!");

var hostBuilder = Host.CreateDefaultBuilder();

hostBuilder.ConfigureServices(s => s.AddElsa(configure: elsa =>
{
    elsa.UseEntityFrameworkPersistence(opts =>
    {
        Elsa.Persistence.EntityFramework.SqlServer.DbContextOptionsBuilderExtensions.UseSqlServer(
            opts,
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=elsa-test;Integrated Security=True;Connect Timeout=30;Encrypt=False;",
            typeof(SqlServerElsaContextFactory)
            , new ElsaDbContextOptions() { SchemaName = "Custom-Schema" }
        );
    });
}));

var host = hostBuilder.Build();

await host.RunAsync();