using Abp.Modules;
using Abp.Reflection.Extensions;
using OmniSuite.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OmniSuite.Web.Host.Startup
{
    [DependsOn(
       typeof(OmniSuiteWebCoreModule))]
    public class OmniSuiteWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OmniSuiteWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OmniSuiteWebHostModule).GetAssembly());
        }
    }
}
