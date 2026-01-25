using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Usuario.Commands.VerifyOtp
{
    public interface IVerifyOtpCommandHandler
    {
        Task<object> Execute(VerifyOtpRequest request);
    }
}
