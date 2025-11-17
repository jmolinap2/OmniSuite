using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OmniSuite.Controllers
{
    public abstract class OmniSuiteControllerBase : AbpController
    {
        protected OmniSuiteControllerBase()
        {
            LocalizationSourceName = OmniSuiteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
