using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.IRepository;
using DescontroladaMarket.Infrastructure.Context;
using DescontroladaMarket.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IProdutosRepository _produtos;
        private ITiposRepository _tipos;
        public IProdutosRepository Produtos
        {
            get
            {
                if (_produtos == null)
                {
                    _produtos = new ProdutosRepository(_repoContext);
                }
                return _produtos;
            }
        }
        public ITiposRepository Tipos
        {
            get
            {
                if (_tipos == null)
                {
                    _tipos = new TiposRepository(_repoContext);
                }
                return _tipos;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;           
        }       

        public Task SaveAsync()
        {
            return _repoContext.SaveChangesAsync();
        }
    }
}
