using UnifesoPoo.Pedido.Api.Controllers.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Parsers;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;

namespace UnifesoPoo.Pedido.Api.Controllers.Parsers
{
    public class ProdutoParser : IParser<Produto, IProdutoView>
    {
        public IProdutoView Parse(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.ExternalId,
                Nome = produto.Nome,
                Preco = produto.Preco.ToString(),
                QuantidadeDisponivel = produto.QuantidadeDisponivel,
                Status = produto.Status
            };
        }
    }

    public class ProdutoReportParser : IParser<Produto, IProdutoView>
    {
        public IProdutoView Parse(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.ExternalId,
                Nome = produto.Nome.ToUpper(),
                Preco = (produto.Preco / 100M).ToString("C"),
                QuantidadeDisponivel = produto.QuantidadeDisponivel,
                Status = produto.Status
            };
        }
    }
}