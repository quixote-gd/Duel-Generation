using System;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;

namespace DbMigration
{
    public class Run
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }


        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        public static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddPostgres10_0()
                    // Set the connection string
                    .WithGlobalConnectionString("Server = 127.0.0.1; Port = 5432; Database = generate; User Id = postgres; Password = root;")
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(CreateLogTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        public static void UpdateDatabase(IServiceProvider serviceProvider)
        {

            try
            {
                // Instantiate the runner
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

                // Execute the migrations
                runner.MigrateUp();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
