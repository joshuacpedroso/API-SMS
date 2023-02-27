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
    public class ConteudoClienteService : BaseService, IConteudoClienteService
    {
        private readonly IMapper _mapper;
        private readonly IConteudoClienteRepository _conteudoClienteRepository;
        public ConteudoClienteService(INotificador notificador,
                                        IConteudoClienteRepository conteudoClienteRepository,
                                        IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _conteudoClienteRepository = conteudoClienteRepository;

        }

        public async Task Adicionar(ConteudoCliente conteudoCliente)
        {
            await _conteudoClienteRepository.Adicionar(conteudoCliente);


        }

        public Task Remover(Guid id)
        {
            return _conteudoClienteRepository.Remover(id);
        }
    }
}
