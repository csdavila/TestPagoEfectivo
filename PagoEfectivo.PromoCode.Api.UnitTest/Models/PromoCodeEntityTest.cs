using PagoEfectivo.PromoCode.Model.Models;
using FluentAssertions;
using Xunit;

namespace PagoEfectivo.PromoCode.Api.UnitTest.Models
{
    public class PromoCodeEntityTest
    {
        [Fact]
        public void PromoCodeEntityValid()
        {
            PromoCodeEntity entity = new PromoCodeEntity() { Id = 0, Name = string.Empty, Email = string.Empty, Code = string.Empty, Status = 1 };
            var expected = new PromoCodeEntity() { Id = 0, Name = string.Empty, Email = string.Empty, Code = string.Empty, Status = 1 };
            PromoCodeEntity currentEntity = new PromoCodeEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Code = entity.Code,
                Status = entity.Status
            };
            currentEntity.Should().BeEquivalentTo(expected);
        }        
    }
}
