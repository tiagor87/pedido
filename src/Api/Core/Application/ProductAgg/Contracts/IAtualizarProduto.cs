namespace UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts
{
    public interface IAtualizarProduto
    {
        string Nome { get; }
        int QuantidadeDisponivel { get; }
        long Preco { get; }
    }
}