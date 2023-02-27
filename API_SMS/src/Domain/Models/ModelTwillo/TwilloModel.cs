
using Domain.Models.Enums;

namespace Domain.Models.ModelTwillo
{
    public class TwilloMensageModel : TwilloModel
    {
        protected TwilloMensageModel()
        {
            AccountSid = "AC97d8820f4fbfb3884c78587da93e6937";
            AuthToken = "1667b5c4233391edeabc0f2e2e98c08f";
            ToPhoneNumber = "+5511996888914";
            FromPhoneNumber = "+16193299142";
            ServiceSid = "MGc5b6e7504c14e704058827f77e8d3a4a";

        }
    }
    public class TwilloModel : Entity
    {

        public string Mensagem { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string ServiceSid { get; set; }
        public string ToPhoneNumber { get; set; }
        public string FromPhoneNumber { get; set; }
        public SendTwilloEnum StatusSend { get; set; }
    }
}
