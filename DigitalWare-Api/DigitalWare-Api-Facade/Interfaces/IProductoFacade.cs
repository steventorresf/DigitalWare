using DigitalWare_Api_Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Facade.Interfaces
{
    public interface IProductoFacade
    {
        Task<ResponseDto<bool>> Create(ProductoDto request);
        Task<ResponseDto<bool>> Delete(int id);
        Task<ResponseDto<IList<ProductoDto>>> GetAll();
        Task<ResponseDto<ProductoDto>> GetById(int id);
        Task<ResponseDto<bool>> Update(ProductoDto request);
    }
}
