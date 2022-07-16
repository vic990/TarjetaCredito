using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarjetaCreditoAPI.Models;

namespace TarjetaCreditoAPI
{
    public class ApplicationDbContext : DbContext
    {
              

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }

    }
}
