using DescontroladaMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Infrastructure.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
            : base(options)
    {
    }
    public DbSet<Produtos>? Produtos { get; set; }
}
