using CareerOrientation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace CareerOrientation.Services.Tests.Fixtures
{
    public class LocalDbInitializerFixture : IDisposable, IAsyncDisposable
    {
        private readonly string _dbName = "career_orientation_tests_db";
        private readonly string _dbUsername = "career_orientation";
        private readonly string _dbPassword = "knowledge";

        public LocalDbInitializerFixture()
        {
            DeleteDB();
            CreateDB();
        }

        public ValueTask DisposeAsync()
        {
            Dispose();
            return ValueTask.CompletedTask;
        }

        public void Dispose()
        {
            DeleteDB();
        }

        public ApplicationDbContext GetDbContextLocalDb(bool beginTransaction = true)
        {
            return GetDbContextLocalDb(null, beginTransaction);
        }

        public ApplicationDbContext GetDbContextLocalDb(ILoggerFactory? loggerFactory, bool beginTransaction = true)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql($"Server=localhost;Port=5434;Database={_dbName};User Id={_dbUsername};Password={_dbPassword};")
                .Options;

            var context = new ApplicationDbContext(options, loggerFactory);
            if (beginTransaction)
            {
                context.Database.BeginTransaction();
            }
            return context;
        }

        private void CreateDB()
        {
            ExecuteCommand(Master, $"CREATE DATABASE \"{_dbName}\"");

            using (var context = GetDbContextLocalDb(beginTransaction: false))
            {
                context.Database.Migrate();
                // Good place to put test data
                context.SaveChanges();
            }
        }

        private void DeleteDB()
        {
            ExecuteCommand(Master, $"DROP DATABASE IF EXISTS \"{_dbName}\" WITH (force)");
        }

        private void ExecuteCommand(string connectionString, string query)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string Master =>
            new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Port = 5434,
                Database = "postgres",
                Username = _dbUsername,
                Password = _dbPassword
            }.ConnectionString;
    }
}
