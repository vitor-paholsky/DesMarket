using DescontroladaMarket.Domain.IRepository;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Infrastructure.Base;
using DescontroladaMarket.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Infrastructure.Repository;

public class TiposRepository : RepositoryBase<Tipos>, ITiposRepository
{
    public TiposRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}
