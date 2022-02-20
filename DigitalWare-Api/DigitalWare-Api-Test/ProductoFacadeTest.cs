using DigitalWare_Api_Dto;
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
    [TestFixture]
    public class ProductoFacadeTest
    {
        private MockRepository mockRepository;

        private Mock<IProductoRepository> mockConsultaRepository;
        
        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockConsultaRepository = this.mockRepository.Create<IProductoRepository>();
        }

        public ProductoFacade CreateService()
        {
            return new ProductoFacade(mockConsultaRepository.Object);
        }

        [Test]
        public async Task Create()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = true
            };

            this.mockConsultaRepository.Setup(s => s.Create(It.IsAny<ProductoDto>())).ReturnsAsync(responseDto);

            var result = await service.Create(new ProductoDto());
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Delete()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = true
            };

            this.mockConsultaRepository.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(responseDto);

            var result = await service.Delete(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<ProductoDto>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<ProductoDto>()
            };

            this.mockConsultaRepository.Setup(s => s.GetAll()).ReturnsAsync(responseDto);

            var result = await service.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetById()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<ProductoDto>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new ProductoDto()
            };

            this.mockConsultaRepository.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(responseDto);

            var result = await service.GetById(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Update()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = true
            };

            this.mockConsultaRepository.Setup(s => s.Create(It.IsAny<ProductoDto>())).ReturnsAsync(responseDto);

            var result = await service.Update(new ProductoDto());
            Assert.IsNotNull(result);
        }

    }
}
