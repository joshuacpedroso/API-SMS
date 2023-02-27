using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Interfaces;
using _4Ucode_sms.Api.VewModel;
using Data.Repository;
using _4Ucode_sms.Api.ViewModel.ViewModelTwilio;
using Twilio.TwiML.Messaging;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using Domain.Models.ModelTwillo;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("Twillo")]
    //[ApiController]
    public class TestUploadTwilloSmsController : MainController
    {
        private readonly ITwilloService _twilloService;
        private readonly IMapper _mapper;


        public TestUploadTwilloSmsController(
            INotificador notificador,
            IMapper mapper,
            IUser user,
            ITwilloService twilloService) : base(notificador,user)
        {
            _mapper = mapper;
            _twilloService = twilloService;
        }


        [HttpPost("post/mensage")]
        public async Task<ActionResult<PostMensageTwilloViewModel>> AddMensage(PostMensageTwilloViewModel postMensageViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _twilloService.SendWhitNumber(_mapper.Map<TwilloMensageModel>(postMensageViewModel));

            return CustomResponse(postMensageViewModel);

        }

        [HttpPost("post")]

        public async Task<ActionResult<PostTwilloViewModel>> Add(PostTwilloViewModel postViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _twilloService.Send(_mapper.Map<TwilloModel>(postViewModel));

            return CustomResponse(postViewModel);

        }








    }
}
