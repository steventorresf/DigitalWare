using DigitalWare_Api_Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Infrastructure.Interfaces
{
    public interface IFacturaRepository
    {
        Task<ResponseDto<bool>> Create(FacturaDto request);
        Task<ResponseDto<bool>> Delete(int id);
        Task<ResponseDto<FacturaDto>> GetByNoFactura(int noFactura);
    }
}
