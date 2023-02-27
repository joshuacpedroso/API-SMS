using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Envio.Api.Service
{
    public class EnvioService : IEnvioService
    {
        public MessageResource SendSMS(string message)
        {
            var accountSid = "ACb84dbc0af0fe2e76d4d00288f3e9c78e";
            var authToken = "ec4e43bca750d8e7c4f38db887d13816";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+5511996888914"));
            messageOptions.MessagingServiceSid = "MGe56cb70b6fb04bcd5a859a92dfac9980";
            messageOptions.Body = message;

            return MessageResource.Create(messageOptions);
        }
    }
}
