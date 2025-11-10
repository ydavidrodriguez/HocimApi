using AutoMapper;
using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.GettraceabilityRfx
{
    public interface IGettraceabilityRfx
    {
        Task<object> Execute(Guid IdRfx);

    }
}
