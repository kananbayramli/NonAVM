using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerse.DataAccess.Persistance;

public class ECommerseDbContext : IdentityDbContext
{
    public ECommerseDbContext(DbContextOptions<ECommerseDbContext> options) : base(options)
    {

    }

}
