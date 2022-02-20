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
    public class FacturaFacade : IFacturaFacade
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaFacade(IFacturaRepository facturaRepository)
        {
            this._facturaRepository = facturaRepository;
        }

        public async Task<ResponseDto<bool>> Create(FacturaDto request)
        {
            return await _facturaRepository.Create(request);
        }

        public async Task<ResponseDto<bool>> Delete(int id)
        {
            return await _facturaRepository.Delete(id);
        }

        public async Task<ResponseDto<FacturaDto>> GetByNoFactura(int noFactura)
        {
            return await _facturaRepository.GetByNoFactura(noFactura);
        }
    }
}
