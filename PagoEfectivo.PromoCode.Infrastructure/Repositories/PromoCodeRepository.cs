using Microsoft.Extensions.Logging;
using PagoEfectivo.PromoCode.Infrastructure.Data;
using PagoEfectivo.PromoCode.Infrastructure.Interfaces;
using PagoEfectivo.PromoCode.Model.Models;

namespace PagoEfectivo.PromoCode.Infrastructure.Repositories
{
    public class PromoCodeRepository : GenericRepository<PromoCodeEntity>, IPromoCodeRepository
    {
        public PromoCodeRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
    }
}
