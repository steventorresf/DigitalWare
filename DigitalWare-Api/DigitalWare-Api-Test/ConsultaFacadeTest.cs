using DigitalWare_Api_Dto;
using DigitalWare_Api_Entities;
using DigitalWare_Api_Facade.Implementations;
using DigitalWare_Api_Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Test
{
    public class ConsultaFacadeTest
    {
        private MockRepository mockRepository;

        private Mock<IConsultaRepository> mockConsultaRepository;

        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockConsultaRepository = this.mockRepository.Create<IConsultaRepository>();
        }

        public ConsultaFacade CreateService()
        {
            return new ConsultaFacade(mockConsultaRepository.Object);
        }

        [Test]
        public async Task GetListadoClientesNoMayores()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<Sp_ListadoClientesNoMayores>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<Sp_ListadoClientesNoMayores>()
            };

            this.mockConsultaRepository.Setup(s => s.GetListadoClientesNoMayores()).ReturnsAsync(responseDto);

            var result = await service.GetListadoClientesNoMayores();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetListadoPreciosProductos()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<Sp_ListadoPreciosProductos>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<Sp_ListadoPreciosProductos>()
            };

            this.mockConsultaRepository.Setup(s => s.GetListadoPreciosProductos()).ReturnsAsync(responseDto);

            var result = await service.GetListadoPreciosProductos();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetListadoProductosExistenciaMinima()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<Sp_ListadoProductosExistenciaMinima>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<Sp_ListadoProductosExistenciaMinima>()
            };

            this.mockConsultaRepository.Setup(s => s.GetListadoProductosExistenciaMinima()).ReturnsAsync(responseDto);

            var result = await service.GetListadoProductosExistenciaMinima();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetListadoTotalVendidoPorProducto()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<Sp_ListadoTotalVendidoPorProducto>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<Sp_ListadoTotalVendidoPorProducto>()
            };

            this.mockConsultaRepository.Setup(s => s.GetListadoTotalVendidoPorProducto(It.IsAny<int>())).ReturnsAsync(responseDto);

            var result = await service.GetListadoTotalVendidoPorProducto(2000);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetUltimaFechaCompraCliente()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<Sp_UltimaFechaCompraCliente>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<Sp_UltimaFechaCompraCliente>()
            };

            this.mockConsultaRepository.Setup(s => s.GetUltimaFechaCompraCliente(It.IsAny<int>())).ReturnsAsync(responseDto);

            var result = await service.GetUltimaFechaCompraCliente(1);
            Assert.IsNotNull(result);
        }
    }
}
