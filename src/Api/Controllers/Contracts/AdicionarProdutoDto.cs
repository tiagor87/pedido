using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;

namespace UnifesoPoo.Pedido.Api.Controllers.Contracts
{
    public class AdicionarProdutoDto : IAdicionarProduto
    {
        public string Nome { get; set; }
        public long Preco { get; set; }
    }
}