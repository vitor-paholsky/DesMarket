using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontroladaMarket.Domain.Services;

public class ProdutoService : Notifiable<Notification>, IProdutoService
{
    public async Task<Produtos> AdicionarProduto(Produtos produto)
    {
        var contract = new ProdutoContract(produto);
        AddNotifications(contract);

        if (!contract.IsValid)
        {
            throw new ArgumentException(Notifications.FirstOrDefault()?.Key);
        }

        return produto;
    }
}
