using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Parsers;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;

namespace UnifesoPoo.Pedido.Api.Controllers.Parsers
{
    public class ProdutoParseFactory : IProdutoParseFactory
    {
        public IParser<Produto, IProdutoView> GetProdutoParse()
        {
            return new ProdutoParser();
        }

        public IParser<Produto, IProdutoView> GetProdutoReportParse()
        {
            return new ProdutoReportParser();
        }
    }
}