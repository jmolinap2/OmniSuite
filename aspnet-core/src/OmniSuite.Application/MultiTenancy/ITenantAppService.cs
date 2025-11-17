using Abp.Application.Services;
using OmniSuite.MultiTenancy.Dto;

namespace OmniSuite.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

