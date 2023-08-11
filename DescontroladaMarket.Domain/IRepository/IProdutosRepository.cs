using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.IRepository;

public interface IProdutosRepository : IRepositoryBase<Produtos>
{
    IEnumerable<Produtos> GetAllProdutos();
    Produtos GetProdutoByName(string name);
    void UpdateProdutos(Produtos produtos);
}
