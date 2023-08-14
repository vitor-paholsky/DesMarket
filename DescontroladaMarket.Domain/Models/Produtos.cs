using Flunt.Notifications;

namespace DescontroladaMarket.Domain.Models;

public class Produtos
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoVenda { get; set; }
    public string Descricao { get; set; }
    public double? Quantidade { get; set; }
    public bool Tipo { get; set;}
    public DateTime DataCadastro { get; set; }
}
