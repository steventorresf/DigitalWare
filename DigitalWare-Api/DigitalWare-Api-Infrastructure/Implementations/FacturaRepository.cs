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
    public class FacturaRepository : IFacturaRepository
    {
        private readonly DbContextApi _context;

        public FacturaRepository(DbContextApi context)
        {
            this._context = context;
        }

        public async Task<ResponseDto<bool>> Create(FacturaDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                using(var tran = _context.Database.BeginTransaction())
                {
                    Secuencia secuencia = await _context.Secuencias.FirstOrDefaultAsync(x => x.CodigoSecuencia.Equals("NoFactura"));
                    if (secuencia == null)
                    {
                        response.Error(HttpStatusCode.NotFound, "La secuencia no se encuentra.");
                        return response;
                    }

                    secuencia.NoSecuencia++;
                    await _context.SaveChangesAsync();

                    Factura entity = new Factura
                    {
                        IdFactura = 0,
                        NoFactura = secuencia.NoSecuencia,
                        IdCliente = request.IdCliente,
                        FechaVenta = DateTime.Now
                    };

                    await _context.Facturas.AddAsync(entity);
                    await _context.SaveChangesAsync();

                    entity = await _context.Facturas.FirstOrDefaultAsync(x => x.NoFactura == entity.NoFactura);
                    if(entity == null)
                    {
                        response.Error(HttpStatusCode.NotFound, "El numero de factura no se encuentra.");
                        return response;
                    }

                    IList<FacturaDetalle> facturaDetalle = new List<FacturaDetalle>();

                    foreach (FacturaDetalleDto fd in request.FacturaDetalle)
                    {
                        FacturaDetalle item = new FacturaDetalle
                        {
                            IdFacturaDetalle = 0,
                            IdFactura = entity.IdFactura,
                            IdProducto = fd.IdProducto,
                            Cantidad = fd.Cantidad,
                            ValorUnitario = fd.ValorUnitario
                        };

                        facturaDetalle.Add(item);
                    }

                    await _context.FacturasDetalle.AddRangeAsync(facturaDetalle);
                    await _context.SaveChangesAsync();

                    response.Result = true;

                    tran.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<bool>> Delete(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                using (var tran = _context.Database.BeginTransaction())
                {
                    IList<FacturaDetalle> facturaDetalle = await _context.FacturasDetalle.Where(x => x.IdFactura == id).ToListAsync();
                    if (facturaDetalle.Count > 0)
                    {
                        _context.FacturasDetalle.RemoveRange(facturaDetalle);
                        await _context.SaveChangesAsync();
                    }

                    Factura entity = await _context.Facturas.FindAsync(id);
                    if (entity == null)
                    {
                        response.Error(HttpStatusCode.NotFound, "La factura no fue encontrada.");
                        return response;
                    }

                    _context.Facturas.Remove(entity);
                    await _context.SaveChangesAsync();

                    response.Result = true;

                    tran.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<FacturaDto>> GetByNoFactura(int noFactura)
        {
            var response = new ResponseDto<FacturaDto>();

            try
            {
                Factura entity = await _context.Facturas.FirstOrDefaultAsync(x => x.NoFactura == noFactura);
                if(entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "La factura no fue encontrada");
                    return response;
                }

                Cliente cliente = await _context.Clientes.FindAsync(entity.IdCliente);
                if(cliente == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El cliente no fue encontrado");
                    return response;
                }

                response.Result = new FacturaDto
                {
                    IdFactura = entity.IdFactura,
                    NoFactura = entity.NoFactura,
                    IdCliente = cliente.IdCliente,
                    FechaVenta = entity.FechaVenta,
                    NombreCliente = cliente.Nombre,
                    FacturaDetalle = await (from fd in _context.FacturasDetalle.Where(x => x.IdFactura == entity.IdFactura)
                                            join pr in _context.Productos on fd.IdProducto equals pr.IdProducto
                                            select new FacturaDetalleDto
                                            {
                                                IdFacturaDetalle = fd.IdFacturaDetalle,
                                                IdFactura = fd.IdFactura,
                                                IdProducto = pr.IdProducto,
                                                NombreProducto = pr.Nombre,
                                                Cantidad = fd.Cantidad,
                                                ValorUnitario = fd.ValorUnitario,
                                                ValorTotal = fd.Cantidad * fd.ValorUnitario
                                            }).ToListAsync()
                };
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
