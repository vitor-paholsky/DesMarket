using DescontroladaMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.Services;

public interface IProdutoService
{
    Task<Produtos> AdicionarProduto(Produtos produto);
}
