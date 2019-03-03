using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dscan.Models;

namespace Dscan
{
    public class DscanContext : DbContext
    {
        public DscanContext (DbContextOptions<DscanContext> options)
            : base(options)
        {
        }

        public DbSet<Dscan.Models.DscanModel> DscanModel { get; set; }
    }
}
