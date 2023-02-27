

using Domain.Models;
using Domain.Models.ModelTwillo;

namespace Domain.Interfaces
{
    public interface ITwilloService
    {
        Task<bool> SendWhitNumber(TwilloMensageModel twilloMensageModel);
        Task<bool> Send(TwilloModel postTwilloUserModel);



    }
}
