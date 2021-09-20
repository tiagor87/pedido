namespace UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts
{
    public interface IProdutoView
    {
        long Id { get; }
        string Nome { get; }
        string Preco { get; }
        int QuantidadeDisponivel { get; }
    }
}