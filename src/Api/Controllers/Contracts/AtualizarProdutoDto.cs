using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;

namespace UnifesoPoo.Pedido.Api.Controllers.Contracts
{
    public class AtualizarProdutoDto : IAtualizarProduto
    {
        public string Nome { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public long Preco { get; set; }
    }
}