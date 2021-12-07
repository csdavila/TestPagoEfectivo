using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PagoEfectivo.PromoCode.Api.Controllers;
using PagoEfectivo.PromoCode.Domain.Interfaces;
using PagoEfectivo.PromoCode.Model.Dtos;
using PagoEfectivo.PromoCode.Model.Requests;
using PagoEfectivo.PromoCode.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PagoEfectivo.PromoCode.Api.UnitTest.Controllers
{
    public class PromoCodeControllerTest
    {
        private readonly PromoCodeController _sut;
        private readonly Mock<ILogger<PromoCodeController>> _logger;
        private readonly Mock<IPromoCodeService> _service;
        public PromoCodeControllerTest()
        {
            this._logger = new Mock<ILogger<PromoCodeController>>();
            this._service = new Mock<IPromoCodeService>();

            this._sut = new PromoCodeController(this._logger.Object, this._service.Object);
        }

        [Fact]
        public async Task Generate()
        {
            GenerateRequest request = new GenerateRequest();
            GenerateResponse expected = new GenerateResponse();

            _service.Setup(x => x.Generate(request)).Returns(Task.FromResult(expected));

            var current = await _sut.Generate(request);

            ((ObjectResult)current).StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)current).Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Redeem()
        {
            RedeemRequest request = new RedeemRequest() { code = Guid.NewGuid().ToString().ToUpperInvariant() };
            RedeemResponse expected = new RedeemResponse();

            _service.Setup(x => x.Redeem(request)).Returns(Task.FromResult(expected));

            var current = await _sut.Redeem(request);

            ((ObjectResult)current).StatusCode.Should().Be((int)HttpStatusCode.OK);
            //((BadRequestResult)current).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            ((ObjectResult)current).Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task All()
        {
            var objectsList = new List<PromoCodeDto>();
            var searchResults = Task.FromResult<IEnumerable<PromoCodeDto>>(objectsList);

            var expected = new List<PromoCodeDto>();

            _service.Setup(x => x.All()).Returns(searchResults);

            var current = await _sut.All();

            ((ObjectResult)current).StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)current).Value.Should().BeEquivalentTo(expected);
        }
    }
}
