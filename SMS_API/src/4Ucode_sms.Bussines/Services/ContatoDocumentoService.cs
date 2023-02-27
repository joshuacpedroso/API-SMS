using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Bussines.Interfaces;
using Data.Repository;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace _4Ucode_sms.Bussines.Services
{
    public class ContatoDocumentoService : BaseService, IContatoDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IContatoDocumentoRepository _baseUploadRepository;

        public ContatoDocumentoService(IContatoDocumentoRepository documento,INotificador notificador, IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _baseUploadRepository = documento;  
        }

        public Task GetDocuments<UploadDocumentResponse>(Guid operatorId)
        {
            throw new NotImplementedException();
        }

        public async Task Adicionar(ContatoDocumento documento)
        {

            await _baseUploadRepository.Adicionar(documento);







        }

        public Task Encapsular(string filePath)
        {

            ArrayList array = new ArrayList();
            var file = new StreamReader(filePath);
            string? line;
            while ((line = file.ReadLine()) != null)
            {
                int count = 0;
                foreach (char item in line)
                {
                    count++;
                }
                if (count == 13)
                {
                    string replacement = "";
                    string pattern = @"^.{2}";
                    string result = Regex.Replace(line, pattern, replacement);
                    line = result;
                }


                ContatoDocumento Contato = new ContatoDocumento()
                {
                    numero = line,
                };

                


                Adicionar(Contato);


               
            }

            file.Close();
            return Task.CompletedTask;

            
        }
    }
}
