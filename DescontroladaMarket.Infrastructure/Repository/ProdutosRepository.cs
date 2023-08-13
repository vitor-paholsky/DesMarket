using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.IRepository;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Infrastructure.Base;
using DescontroladaMarket.Infrastructure.Context;

namespace DescontroladaMarket.Domain.Repository;

public class ProdutosRepository : RepositoryBase<Produtos>, IProdutosRepository
{
    public ProdutosRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Produtos> GetAllProdutos() => FindAll().ToList().OrderBy(produtos => produtos.Id);
}