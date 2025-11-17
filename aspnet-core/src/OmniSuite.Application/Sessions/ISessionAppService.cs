using Abp.Application.Services;
using OmniSuite.Sessions.Dto;
using System.Threading.Tasks;

namespace OmniSuite.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
