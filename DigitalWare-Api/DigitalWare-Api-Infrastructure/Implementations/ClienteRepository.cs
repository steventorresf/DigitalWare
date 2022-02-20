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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContextApi _context;

        public ClienteRepository(DbContextApi context)
        {
            this._context = context;
        }

        public async Task<ResponseDto<bool>> Create(ClienteDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Cliente entity = new Cliente
                {
                    IdCliente = 0,
                    Identificacion = request.Identificacion,
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Telefono = request.Telefono
                };

                await _context.Clientes.AddAsync(entity);
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
                Cliente entity = await _context.Clientes.FindAsync(id);
                if (entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El cliente no fue encontrado.");
                    return response;
                }

                _context.Clientes.Remove(entity);
                await _context.SaveChangesAsync();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<IList<ClienteDto>>> GetAll()
        {
            var response = new ResponseDto<IList<ClienteDto>>();

            try
            {
                response.Result = await _context.Clientes
                    .Select(x => new ClienteDto
                    {
                        IdCliente = x.IdCliente,
                        Identificacion = x.Identificacion,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Telefono = x.Telefono
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

        public async Task<ResponseDto<ClienteDto>> GetById(int id)
        {
            var response = new ResponseDto<ClienteDto>();

            try
            {
                Cliente entity = await _context.Clientes.FindAsync(id);
                if(entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El cliente no fue encontrado.");
                    return response;
                }

                response.Result = new ClienteDto
                {
                    IdCliente = entity.IdCliente,
                    Identificacion = entity.Identificacion,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    Telefono = entity.Telefono
                };
            }
            catch (Exception ex)
            {
                response.Error(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseDto<bool>> Update(ClienteDto request)
        {
            var response = new ResponseDto<bool>();

            try
            {
                Cliente entity = await _context.Clientes.FindAsync(request.IdCliente);
                if(entity == null)
                {
                    response.Error(HttpStatusCode.NotFound, "El cliente no fue encontrado.");
                    return response;
                }

                entity.Identificacion = request.Identificacion;
                entity.Nombre = request.Nombre;
                entity.Apellido = request.Apellido;
                entity.Telefono = request.Telefono;

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
