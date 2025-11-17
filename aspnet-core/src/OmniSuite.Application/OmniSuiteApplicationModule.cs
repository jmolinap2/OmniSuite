using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OmniSuite.Authorization;

namespace OmniSuite;

[DependsOn(
    typeof(OmniSuiteCoreModule),
    typeof(AbpAutoMapperModule))]
public class OmniSuiteApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<OmniSuiteAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(OmniSuiteApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
