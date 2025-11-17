using Abp.Authorization;
using Abp.Runtime.Session;
using OmniSuite.Configuration.Dto;
using System.Threading.Tasks;

namespace OmniSuite.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : OmniSuiteAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
