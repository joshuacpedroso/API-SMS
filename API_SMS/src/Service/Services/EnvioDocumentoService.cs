using AutoMapper;
using Data.Repository;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enums;
using Domain.Models.ModelTwillo;
using EnumsNET;
using NPOI.SS.Formula.Functions;
using NPOI.Util;

namespace Service.Services
{
    public class EnvioDocumentoService : BaseService, IEnvioDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IEnvioDocumentoRepository _envioDocumentoRepository;
        private readonly IContatoDocumentoRepository _contatoDocumentoRepository;
        private readonly ITwilloService _twilloService;

        public EnvioDocumentoService(IEnvioDocumentoRepository documento,
                                        INotificador notificador,
                                        ITwilloService twilloService,
                                        IEnvioDocumentoRepository envioDocumentoRepository,
                                        IContatoDocumentoRepository contatoDocumentoRepository,
                                        IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _envioDocumentoRepository = documento;  
            _twilloService = twilloService;
            _contatoDocumentoRepository = contatoDocumentoRepository;
        }

        public async Task<bool> AdicionarEnvios(List<EnvioDocumento> documentos)
        {
            try
            {
               
                foreach (var documento in documentos)
                {

                    var send = await Enviar(documento);
                    if (send == null)
                    {
                        return false;
                    }

                   
                    continue;
                }
            }
            catch (Exception ex)
            {
                Notificar("Ocorreu um erro ao adicionar os documentos: " + ex.Message);

                
            }

            return false;

        }


        private async Task<bool> Enviar(EnvioDocumento documento)
        {
            var count = 0;

            string testeCliente = "e1b5aa55-525c-4c77-b9e6-66936b7c5584";

            documento.IdCliente = Guid.Parse(testeCliente) ;

            documento.Enviado = EnvioEnum.Failure;

            var contatoDocumento = await _contatoDocumentoRepository.ObterPorId(documento.NumeroId);
            if (contatoDocumento == null)
            {
                Notificar("Numero não encontrado");
                return false;
            }

            foreach (char item in contatoDocumento.numero)
            {
                count++;
            }
            if (count == 11)
            {
                contatoDocumento.numero = String.Concat("+55", contatoDocumento.numero);
            }
            if (count == 13)
            {
                contatoDocumento.numero = String.Concat("+", contatoDocumento.numero);
            }

            var novoEnvio = new TwilloModel
            {
                Mensagem = documento.TextoEnvio,
                ToPhoneNumber = contatoDocumento.numero.ToString(),
                AccountSid = "AC97d8820f4fbfb3884c78587da93e6937",
                AuthToken = "1667b5c4233391edeabc0f2e2e98c08f",
                FromPhoneNumber = "+16193299142",
                ServiceSid = "MGc5b6e7504c14e704058827f77e8d3a4a",

            };


            var envio = await _twilloService.Send(novoEnvio);


            if (novoEnvio.StatusSend == SendTwilloEnum.Success)
            {
                documento.Enviado = EnvioEnum.Success;
                await _envioDocumentoRepository.Adicionar(documento);
                return true;
            }

            return false;

        }


        public async Task Adicionar(EnvioDocumento documento)
        {
            await _envioDocumentoRepository.Adicionar(documento);
        }
    }
}
