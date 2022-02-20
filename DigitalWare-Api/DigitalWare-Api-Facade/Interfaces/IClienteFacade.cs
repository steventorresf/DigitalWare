using DigitalWare_Api_Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Facade.Interfaces
{
    public interface IClienteFacade
    {
        Task<ResponseDto<bool>> Create(ClienteDto request);
        Task<ResponseDto<bool>> Delete(int id);
        Task<ResponseDto<IList<ClienteDto>>> GetAll();
        Task<ResponseDto<ClienteDto>> GetById(int id);
        Task<ResponseDto<bool>> Update(ClienteDto request);
    }
}
