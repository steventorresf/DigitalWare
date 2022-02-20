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
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbContextApi _context;

        public ProductoRepository(DbContextApi context)
        {
            this._context = context;
        }

        public async Task<ResponseDto<bool>> Create(ProductoDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Producto entity = new Producto
                {
                    IdProducto = 0,
                    Nombre = request.Nombre,
                    ValorUnitario = request.ValorUnitario
                };

                await _context.Productos.AddAsync(entity);
                await _context.SaveChangesAsync();

                response.Result = true;
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
                Producto entity = await _context.Productos.FindAsync(id);
                if (entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El producto no fue encontrado.");
                    return response;
                }

                _context.Productos.Remove(entity);
                await _context.SaveChangesAsync();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<IList<ProductoDto>>> GetAll()
        {
            var response = new ResponseDto<IList<ProductoDto>>();

            try
            {
                response.Result = await _context.Productos
                    .Select(x => new ProductoDto
                    {
                        IdProducto = x.IdProducto,
                        Nombre = x.Nombre,
                        ValorUnitario = x.ValorUnitario
                    })
                    .OrderBy(x => x.Nombre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<ProductoDto>> GetById(int id)
        {
            var response = new ResponseDto<ProductoDto>();

            try
            {
                Producto entity = await _context.Productos.FindAsync(id);
                if (entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El producto no fue encontrado.");
                    return response;
                }

                response.Result = new ProductoDto
                {
                    IdProducto = entity.IdProducto,
                    Nombre = entity.Nombre,
                    ValorUnitario = entity.ValorUnitario
                };
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<bool>> Update(ProductoDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Producto entity = await _context.Productos.FindAsync(request.IdProducto);
                if (entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El producto no fue encontrado.");
                    return response;
                }

                entity.Nombre = request.Nombre;
                entity.ValorUnitario = request.ValorUnitario;

                await _context.SaveChangesAsync();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
