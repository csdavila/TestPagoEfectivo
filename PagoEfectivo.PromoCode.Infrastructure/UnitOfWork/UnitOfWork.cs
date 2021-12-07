using Microsoft.Extensions.Logging;
using PagoEfectivo.PromoCode.Infrastructure.Data;
using PagoEfectivo.PromoCode.Infrastructure.Interfaces;
using PagoEfectivo.PromoCode.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace PagoEfectivo.PromoCode.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IPromoCodeRepository PromoCodes { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            PromoCodes = new PromoCodeRepository(context, _logger);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
