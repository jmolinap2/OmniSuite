using OmniSuite.Configuration.Dto;
using System.Threading.Tasks;

namespace OmniSuite.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
