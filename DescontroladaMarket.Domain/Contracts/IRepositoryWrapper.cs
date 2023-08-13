using DescontroladaMarket.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.Contracts;

public interface IRepositoryWrapper
{
    IProdutosRepository Produtos { get; }
    Task SaveAsync();
}
