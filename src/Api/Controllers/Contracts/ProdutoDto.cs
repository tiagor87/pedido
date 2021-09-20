using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;

namespace UnifesoPoo.Pedido.Api.Controllers.Contracts
{
    public class ProdutoDto : IProdutoView
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}