using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace Envio.Api.Service
{
    public interface IEnvioService
    {
        public MessageResource SendSMS(string message);
    }
}