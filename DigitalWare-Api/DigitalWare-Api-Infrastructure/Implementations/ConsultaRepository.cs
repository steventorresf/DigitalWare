using DigitalWare_Api_Dto;
using DigitalWare_Api_Entities;
using DigitalWare_Api_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Infrastructure.Implementations
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly DbContextApi _context;

        public ConsultaRepository(DbContextApi context)
        {
            this._context = context;
        }

        public async Task<ResponseDto<IList<Sp_ListadoClientesNoMayores>>> GetListadoClientesNoMayores()
        {
            var response = new ResponseDto<IList<Sp_ListadoClientesNoMayores>>();

            try
            {
                response.Result = await _context.Sp_ListadoClientesNoMayores.FromSqlRaw("Sp_ListadoClientesNoMayores").ToListAsync();
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<IList<Sp_ListadoPreciosProductos>>> GetListadoPreciosProductos()
        {
            var response = new ResponseDto<IList<Sp_ListadoPreciosProductos>>();

            try
            {
                response.Result = await _context.Sp_ListadoPreciosProductos.FromSqlRaw("Sp_ListadoPreciosProductos").ToListAsync();
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<IList<Sp_ListadoProductosExistenciaMinima>>> GetListadoProductosExistenciaMinima()
        {
            var response = new ResponseDto<IList<Sp_ListadoProductosExistenciaMinima>>();

            try
            {
                response.Result = await _context.Sp_ListadoProductosExistenciaMinima.FromSqlRaw("Sp_ListadoProductosExistenciaMinima").ToListAsync();
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<IList<Sp_ListadoTotalVendidoPorProducto>>> GetListadoTotalVendidoPorProducto(int anio)
        {
            var response = new ResponseDto<IList<Sp_ListadoTotalVendidoPorProducto>>();

            try
            {
                response.Result = await _context.Sp_ListadoTotalVendidoPorProducto.FromSqlRaw("Sp_ListadoTotalVendidoPorProducto {0}", anio).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<IList<Sp_UltimaFechaCompraCliente>>> GetUltimaFechaCompraCliente(int idCliente)
        {
            var response = new ResponseDto<IList<Sp_UltimaFechaCompraCliente>>();

            try
            {
                response.Result = await _context.Sp_UltimaFechaCompraCliente.FromSqlRaw("Sp_UltimaFechaCompraCliente {0}", idCliente).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
