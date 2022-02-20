using DigitalWare_Api_Dto;
using DigitalWare_Api_Entities;
using DigitalWare_Api_Facade.Interfaces;
using DigitalWare_Api_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Facade.Implementations
{
    public class ConsultaFacade : IConsultaFacade
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaFacade(IConsultaRepository consultaRepository)
        {
            this._consultaRepository = consultaRepository;
        }

        public async Task<ResponseDto<IList<Sp_ListadoClientesNoMayores>>> GetListadoClientesNoMayores()
        {
            return await this._consultaRepository.GetListadoClientesNoMayores();
        }

        public async Task<ResponseDto<IList<Sp_ListadoPreciosProductos>>> GetListadoPreciosProductos()
        {
            return await this._consultaRepository.GetListadoPreciosProductos();
        }

        public async Task<ResponseDto<IList<Sp_ListadoProductosExistenciaMinima>>> GetListadoProductosExistenciaMinima()
        {
            return await this._consultaRepository.GetListadoProductosExistenciaMinima();
        }

        public async Task<ResponseDto<IList<Sp_ListadoTotalVendidoPorProducto>>> GetListadoTotalVendidoPorProducto(int anio)
        {
            return await this._consultaRepository.GetListadoTotalVendidoPorProducto(anio);
        }

        public async Task<ResponseDto<IList<Sp_UltimaFechaCompraCliente>>> GetUltimaFechaCompraCliente(int idCliente)
        {
            return await this._consultaRepository.GetUltimaFechaCompraCliente(idCliente);
        }
    }
}
