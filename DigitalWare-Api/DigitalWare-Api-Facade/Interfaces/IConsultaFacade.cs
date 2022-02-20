using DigitalWare_Api_Dto;
using DigitalWare_Api_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Facade.Interfaces
{
    public interface IConsultaFacade
    {
        Task<ResponseDto<IList<Sp_ListadoClientesNoMayores>>> GetListadoClientesNoMayores();
        Task<ResponseDto<IList<Sp_ListadoPreciosProductos>>> GetListadoPreciosProductos();
        Task<ResponseDto<IList<Sp_ListadoProductosExistenciaMinima>>> GetListadoProductosExistenciaMinima();
        Task<ResponseDto<IList<Sp_ListadoTotalVendidoPorProducto>>> GetListadoTotalVendidoPorProducto(int anio);
        Task<ResponseDto<IList<Sp_UltimaFechaCompraCliente>>> GetUltimaFechaCompraCliente(int idCliente);
    }
}
