using AutoMapper;
using Domain.Interfaces;
using Data.Repository;
using Domain.Models;
using Domain.Models.ModelTwillo;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.Http;
using Domain.Models.Enums;

namespace Service.Services
{
    public class TwilloService : BaseService, ITwilloService
    {
        private readonly IMapper _mapper;
        private readonly ITwilloRepository _twilloRepository;

        public TwilloService(INotificador notificador,
                            ITwilloRepository twilloRepository,
                            IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _twilloRepository = twilloRepository;

        }


        public async Task<bool> SendWhitNumber(TwilloMensageModel twilloMensageModel)
        {
            var Mensagem = SendTwillo(twilloMensageModel);

             if (Mensagem.Status != MessageResource.StatusEnum.Accepted)
            {
                twilloMensageModel.StatusSend = SendTwilloEnum.Failure;
                Notificar($"Mensagem enviada com sucesso! SID: {Mensagem.ErrorMessage}");
                await _twilloRepository.Adicionar(twilloMensageModel);

                return false;
            }

            twilloMensageModel.StatusSend = SendTwilloEnum.Success;
            await _twilloRepository.Adicionar(twilloMensageModel);
            return true;


            MessageResource SendTwillo(TwilloMensageModel twilloMensageModel)
            {
                TwilioClient.Init(twilloMensageModel.AccountSid, twilloMensageModel.AuthToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(twilloMensageModel.ToPhoneNumber));
                messageOptions.From = twilloMensageModel.FromPhoneNumber;
                messageOptions.MessagingServiceSid = twilloMensageModel.ServiceSid;
                messageOptions.Body = twilloMensageModel.Mensagem;


                return MessageResource.Create(messageOptions);
                //Console.WriteLine($"Mensagem enviada com sucesso! SID: {messageResource.ErrorMessage.Count<>}");
            }


        }

        public async Task<bool> Send(TwilloModel postTwilloUserModel)
        {
            var Mensagem = SendTwillo(postTwilloUserModel);

            if (Mensagem.Status != MessageResource.StatusEnum.Accepted)
            {
                postTwilloUserModel.StatusSend = SendTwilloEnum.Failure;

                await _twilloRepository.Adicionar(postTwilloUserModel);
                Notificar($"Mensagem enviada com sucesso! SID: {Mensagem.ErrorMessage}");
                return false;
            }

            postTwilloUserModel.StatusSend = SendTwilloEnum.Success;
            await _twilloRepository.Adicionar(postTwilloUserModel);
            return true;

             MessageResource SendTwillo(TwilloModel postTwilloUserModel)
            {
                TwilioClient.Init(postTwilloUserModel.AccountSid, postTwilloUserModel.AuthToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(postTwilloUserModel.ToPhoneNumber));
                messageOptions.From = postTwilloUserModel.FromPhoneNumber;
                messageOptions.MessagingServiceSid = postTwilloUserModel.ServiceSid;
                messageOptions.Body = postTwilloUserModel.Mensagem;


                return MessageResource.Create(messageOptions);
                //Console.WriteLine($"Mensagem enviada com sucesso! SID: {messageResource.ErrorMessage.Count<>}");
            }
        }



    }
}
