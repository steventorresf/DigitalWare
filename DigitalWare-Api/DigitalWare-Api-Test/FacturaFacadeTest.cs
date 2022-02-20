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
    public class FacturaFacadeTest
    {
        private MockRepository mockRepository;

        private Mock<IFacturaRepository> mockConsultaRepository;

        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockConsultaRepository = this.mockRepository.Create<IFacturaRepository>();
        }

        public FacturaFacade CreateService()
        {
            return new FacturaFacade(mockConsultaRepository.Object);
        }

        [Test]
        public void Create()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = true
            };

            this.mockConsultaRepository.Setup(s => s.Create(It.IsAny<FacturaDto>())).Returns(responseDto);

            var result = service.Create(new FacturaDto());
            Assert.IsNotNull(result);
        }

        [Test]
        public void Delete()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = true
            };

            this.mockConsultaRepository.Setup(s => s.Delete(It.IsAny<int>())).Returns(responseDto);

            var result = service.Delete(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetByNoFactura()
        {
            var service = CreateService();

            var responseDto = new ResponseDto<FacturaDto>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Result = new FacturaDto()
            };

            this.mockConsultaRepository.Setup(s => s.GetByNoFactura(It.IsAny<int>())).Returns(responseDto);

            var result = service.GetByNoFactura(1);
            Assert.IsNotNull(result);
        }
    }
}
