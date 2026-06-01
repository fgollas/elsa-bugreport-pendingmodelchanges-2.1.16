# Elsa Bug Reproduction

This project is a minimal reproduction for an Elsa issue related to custom schema migrations.

## Important setup

Before running, update the SQL Server connection string in `Program.cs`.

The current sample uses:

`Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=elsa-test;Integrated Security=True;Connect Timeout=30;Encrypt=False;`

Replace it with your own connection string that points to an existing:

- Microsoft SQL Server (MSSQL) database, or
- MSSQL LocalDB database.

## Run

```bash
dotnet run
```

## Expected behavior
You should see the application crashing with the following output:

```
fail: Microsoft.Extensions.Hosting.Internal.Host[11]
      Hosting failed to start
      System.InvalidOperationException: An error was generated for warning 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning': The model for context 'ElsaContext' has pending changes. Add a new migration before updating the database. See https://aka.ms/efcore-docs-pending-changes. This exception can be suppressed or logged by passing event ID 'RelationalEventId.PendingModelChangesWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
         at Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`1.Log[TLoggerCategory](IDiagnosticsLogger`1 logger, TParam arg)
         at Microsoft.EntityFrameworkCore.Diagnostics.RelationalLoggerExtensions.PendingModelChangesWarning(IDiagnosticsLogger`1 diagnostics, Type contextType)
         at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.ValidateMigrations(Boolean useTransaction, String targetMigration)
         at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.MigrateAsync(String targetMigration, CancellationToken cancellationToken)
         at Elsa.Persistence.EntityFramework.Core.StartupTasks.RunMigrations.ExecuteAsync(CancellationToken cancellationToken)
         at Elsa.Persistence.EntityFramework.Core.StartupTasks.RunMigrations.ExecuteAsync(CancellationToken cancellationToken)
         at Elsa.Runtime.StartupRunner.StartupAsync(CancellationToken cancellationToken)
         at Elsa.Runtime.StartupRunner.StartupAsync(CancellationToken cancellationToken)
         at Elsa.HostedServices.StartupRunnerHostedService.StartAsync(CancellationToken cancellationToken)
         at Microsoft.Extensions.Hosting.Internal.Host.<StartAsync>b__14_1(IHostedService service, CancellationToken token)
         at Microsoft.Extensions.Hosting.Internal.Host.ForeachService[T](IEnumerable`1 services, CancellationToken token, Boolean concurrent, Boolean abortOnFirstException, List`1 exceptions, Func`3 operation)
```