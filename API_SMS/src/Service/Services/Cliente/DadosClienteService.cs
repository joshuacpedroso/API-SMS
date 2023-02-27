using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DadosClienteService : BaseService, IDadosClienteService
    {
        private readonly IMapper _mapper;
        private readonly IDadosClienteRepository _dadosClienterepository;
        public DadosClienteService(INotificador notificador, 
                                    IDadosClienteRepository dadosClienterepository,
                                    IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _dadosClienterepository = dadosClienterepository;

        }

        public async Task Adicionar(DadosCliente dadosCliente)
        {
            if (_dadosClienterepository.Buscar(f => f.NomeCliente == dadosCliente.NomeCliente).Result.Any())
            {
                Notificar("Já existe um cliente com este nome infomado.");
                return;
            }


            await _dadosClienterepository.Adicionar(dadosCliente);


        }

        public async Task Remover(Guid id)
        {

            if (_dadosClienterepository.ObterConteudoCliente(id).Result.ConteudoCliente.Any())
            {
                Notificar("O Cliente possui cadastrados nos sistema!");
                return;
            }
            await _dadosClienterepository.Remover(id);
        }
    }
}
