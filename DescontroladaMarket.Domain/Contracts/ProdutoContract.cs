using DescontroladaMarket.Domain.Models;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.Contracts;

// Contrato de produtos que utiliza a lib do André Baltieri Flunt Validations
public class ProdutoContract : Contract<Produtos>
{
    public ProdutoContract(Produtos produto)
    {
        Requires()
            .IsGreaterThan(produto.Nome, 2, "Nome do produto deve ter ao menos 3 caracteres")
            .IsGreaterThan(produto.Descricao, 2, "Descrição do produto deve ter ao menos 3 caracteres")
            ; 
    }
}