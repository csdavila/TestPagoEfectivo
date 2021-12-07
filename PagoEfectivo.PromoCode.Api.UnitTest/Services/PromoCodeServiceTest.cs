using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PagoEfectivo.PromoCode.Domain.Services;
using PagoEfectivo.PromoCode.Infrastructure.Interfaces;
using PagoEfectivo.PromoCode.Infrastructure.UnitOfWork;
using PagoEfectivo.PromoCode.Model.Dtos;
using PagoEfectivo.PromoCode.Model.Models;
using PagoEfectivo.PromoCode.Model.Requests;
using PagoEfectivo.PromoCode.Model.Responses;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PagoEfectivo.PromoCode.Api.UnitTest.Services
{
    public class PromoCodeServiceTest
    {
        private readonly PromoCodeService _sut;
        private readonly Mock<IUnitOfWork> _IUnitOfWork;
        private readonly Mock<IMapper> _IMapper;
        private readonly Mock<ILogger<PromoCodeService>> _ILogger;
        public PromoCodeServiceTest()
        {
            _IUnitOfWork = new Mock<IUnitOfWork>();
            _ILogger = new Mock<ILogger<PromoCodeService>>();
            _IMapper = new Mock<IMapper>();
            _sut = new PromoCodeService(_ILogger.Object, _IMapper.Object, _IUnitOfWork.Object);
        }

        [Fact]
        public async Task GetAll()
        {
            var objectsList = new List<PromoCodeEntity>();
            var searchResults = Task.FromResult<IEnumerable<PromoCodeEntity>>(objectsList);

            var expected = new List<PromoCodeDto>();

            _IUnitOfWork.Setup( x=> x.PromoCodes.All()).Returns(searchResults);
            _IMapper.Setup(x=>x.Map(searchResults, objectsList)).Returns(objectsList);

            var result = await _sut.All();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
