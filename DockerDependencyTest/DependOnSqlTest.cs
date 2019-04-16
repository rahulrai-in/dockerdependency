using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using Xunit;

namespace DockerDependencyTest
{
    public class DependOnSqlTest
    {
        // Run EF Migrations\DBUp script to prepare database before running your tests.
        const string ConnectionString = "Data Source=database;Initial Catalog=master;PersistSecurityInfo=True;User ID=sa;Password=P@ssW0rd!";

        [Fact]
        public async Task ConnectToSqlTest()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                const string query = "SELECT 1 AS Data";
                var result = (await conn.QueryAsync<int>(query)).FirstOrDefault();
                result.Should().Be(1);
            }
        }
    }
}