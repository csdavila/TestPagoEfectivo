using PagoEfectivo.PromoCode.Model.Dtos;
using PagoEfectivo.PromoCode.Model.Requests;
using PagoEfectivo.PromoCode.Model.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PagoEfectivo.PromoCode.Domain.Interfaces
{
    public interface IPromoCodeService
    {
        Task<GenerateResponse> Generate(GenerateRequest request);

        Task<RedeemResponse> Redeem(RedeemRequest request);

        Task<IEnumerable<PromoCodeDto>> All();
    }
}
