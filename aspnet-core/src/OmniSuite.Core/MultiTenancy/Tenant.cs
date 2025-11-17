using Abp.MultiTenancy;
using OmniSuite.Authorization.Users;

namespace OmniSuite.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
