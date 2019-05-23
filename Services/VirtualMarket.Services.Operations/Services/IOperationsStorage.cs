using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Services.Operations.Dto;

namespace VirtualMarket.Services.Operations.Services
{
    public interface IOperationsStorage
    {
        Task<OperationDto> GetAsync(Guid id);
        Task SetAsync(Guid id, Guid userId, string name, OperationState state,
            string resource, string code = null, string reason = null);
    }
}
