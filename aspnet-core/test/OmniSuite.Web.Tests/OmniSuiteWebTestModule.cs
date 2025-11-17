using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OmniSuite.EntityFrameworkCore;
using OmniSuite.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OmniSuite.Web.Tests;

[DependsOn(
    typeof(OmniSuiteWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class OmniSuiteWebTestModule : AbpModule
{
    public OmniSuiteWebTestModule(OmniSuiteEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(OmniSuiteWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(OmniSuiteWebMvcModule).Assembly);
    }
}