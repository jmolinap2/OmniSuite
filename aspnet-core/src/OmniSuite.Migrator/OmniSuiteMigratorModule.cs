using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OmniSuite.Configuration;
using OmniSuite.EntityFrameworkCore;
using OmniSuite.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace OmniSuite.Migrator;

[DependsOn(typeof(OmniSuiteEntityFrameworkModule))]
public class OmniSuiteMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public OmniSuiteMigratorModule(OmniSuiteEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(OmniSuiteMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            OmniSuiteConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(OmniSuiteMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
