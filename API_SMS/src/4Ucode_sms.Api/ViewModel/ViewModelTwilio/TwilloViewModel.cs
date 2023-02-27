using Domain.Models.Enums;

namespace _4Ucode_sms.Api.ViewModel.ViewModelTwilio
{
    public class PostMensageTwilloViewModel
    {
        public string Mensagem { get; set; }
    }

    public class PostTwilloViewModel
    {
        //public Guid Id { get; set; }
        public string Mensagem { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string ServiceSid { get; set; }
        public string ToPhoneNumber { get; set; }
        public string FromPhoneNumber { get; set; }
        public SendTwilloEnum StatusSend { get; set; }
    }

}