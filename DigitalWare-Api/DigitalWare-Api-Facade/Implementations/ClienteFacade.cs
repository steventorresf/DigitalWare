using DigitalWare_Api_Dto;
using DigitalWare_Api_Facade.Interfaces;
using DigitalWare_Api_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Facade.Implementations
{
    public class ClienteFacade : IClienteFacade
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteFacade(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<ResponseDto<bool>> Create(ClienteDto request)
        {
            return await this._clienteRepository.Create(request);
        }

        public async Task<ResponseDto<bool>> Delete(int id)
        {
            return await this._clienteRepository.Delete(id);
        }

        public async Task<ResponseDto<IList<ClienteDto>>> GetAll()
        {
            return await this._clienteRepository.GetAll();
        }

        public async Task<ResponseDto<ClienteDto>> GetById(int id)
        {
            return await this._clienteRepository.GetById(id);
        }

        public async Task<ResponseDto<bool>> Update(ClienteDto request)
        {
            return await this._clienteRepository.Update(request);
        }
    }
}
