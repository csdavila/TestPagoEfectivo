using Microsoft.Extensions.DependencyInjection;
using PagoEfectivo.PromoCode.Domain.Interfaces;
using PagoEfectivo.PromoCode.Domain.Services;
using PagoEfectivo.PromoCode.Infrastructure.Interfaces;
using PagoEfectivo.PromoCode.Infrastructure.Repositories;
using PagoEfectivo.PromoCode.Infrastructure.UnitOfWork;

namespace PagoEfectivo.PromoCode.Infrastucture.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region EF5
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            #region Services
            services.AddScoped<IPromoCodeService, PromoCodeService>();
            #endregion
        }
    }
}
