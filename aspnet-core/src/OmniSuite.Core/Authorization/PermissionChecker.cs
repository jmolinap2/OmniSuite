using Abp.Authorization;
using OmniSuite.Authorization.Roles;
using OmniSuite.Authorization.Users;

namespace OmniSuite.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
