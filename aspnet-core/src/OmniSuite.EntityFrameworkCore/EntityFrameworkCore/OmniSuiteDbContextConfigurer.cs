using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace OmniSuite.EntityFrameworkCore;

public static class OmniSuiteDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<OmniSuiteDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<OmniSuiteDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
