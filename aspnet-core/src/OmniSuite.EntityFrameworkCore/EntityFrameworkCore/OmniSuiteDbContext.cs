using Abp.Zero.EntityFrameworkCore;
using OmniSuite.Authorization.Roles;
using OmniSuite.Authorization.Users;
using OmniSuite.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace OmniSuite.EntityFrameworkCore;

public class OmniSuiteDbContext : AbpZeroDbContext<Tenant, Role, User, OmniSuiteDbContext>
{
    /* Define a DbSet for each entity of the application */

    public OmniSuiteDbContext(DbContextOptions<OmniSuiteDbContext> options)
        : base(options)
    {
    }
}
