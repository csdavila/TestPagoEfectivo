using Microsoft.EntityFrameworkCore;
using PagoEfectivo.PromoCode.Model.Models;

namespace PagoEfectivo.PromoCode.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<PromoCodeEntity> PromoCode { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
