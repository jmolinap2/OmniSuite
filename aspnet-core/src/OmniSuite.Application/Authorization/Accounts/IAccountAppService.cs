using Abp.Application.Services;
using OmniSuite.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace OmniSuite.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
