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
    public class ClienteFacadeTest
    {
        private MockRepository mockRepository;

        private Mock<IClienteRepository> mockClienteRepository;

        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockClienteRepository = this.mockRepository.Create<IClienteRepository>();
        }

        public ClienteFacade CreateService()
        {
            return new ClienteFacade(mockClienteRepository.Object);
        }

        [Test]
        public async Task Create()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = true
            };

            this.mockClienteRepository.Setup(s => s.Create(It.IsAny<ClienteDto>())).ReturnsAsync(responseDto);

            var result = await service.Create(new ClienteDto());
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

            this.mockClienteRepository.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(responseDto);

            var result = await service.Delete(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<IList<ClienteDto>>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new List<ClienteDto>()
            };

            this.mockClienteRepository.Setup(s => s.GetAll()).ReturnsAsync(responseDto);

            var result = await service.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetById()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<ClienteDto>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new ClienteDto()
            };

            this.mockClienteRepository.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(responseDto);

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

            this.mockClienteRepository.Setup(s => s.Create(It.IsAny<ClienteDto>())).ReturnsAsync(responseDto);

            var result = await service.Update(new ClienteDto());
            Assert.IsNotNull(result);
        }
    }
}
