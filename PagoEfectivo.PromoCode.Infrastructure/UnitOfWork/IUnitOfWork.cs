using PagoEfectivo.PromoCode.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace PagoEfectivo.PromoCode.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPromoCodeRepository PromoCodes { get; }

        Task<int> CompleteAsync();
    }
}
