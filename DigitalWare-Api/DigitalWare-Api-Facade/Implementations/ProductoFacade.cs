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
    public class ProductoFacade : IProductoFacade
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoFacade(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }

        public async Task<ResponseDto<bool>> Create(ProductoDto request)
        {
            return await this._productoRepository.Create(request);
        }

        public async Task<ResponseDto<bool>> Delete(int id)
        {
            return await this._productoRepository.Delete(id);
        }

        public async Task<ResponseDto<IList<ProductoDto>>> GetAll()
        {
            return await this._productoRepository.GetAll();
        }

        public async Task<ResponseDto<ProductoDto>> GetById(int id)
        {
            return await this._productoRepository.GetById(id);
        }

        public async Task<ResponseDto<bool>> Update(ProductoDto request)
        {
            return await this._productoRepository.Update(request);
        }
    }
}
