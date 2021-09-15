using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Parsers;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Repositories;

namespace UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.AppServices
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IParser<Produto, IProdutoView> _parser;

        public ProdutoAppService(IProdutoRepositorio repositorio, IParser<Produto, IProdutoView> parser)
        {
            _repositorio = repositorio;
            _parser = parser;
        }
        
        public IProdutoView Adicionar(IAdicionarProduto adicionarProduto)
        {
            var produto = new Produto(adicionarProduto.Nome, adicionarProduto.Preco);
            _repositorio.Adicionar(produto);
            return _parser.Parse(produto);
        }

        public ICollection<IProdutoView> BuscarPeloNome(string nome)
        {
            var produtos = _repositorio.BuscarPeloNome(nome);
            return produtos.Select(produto => _parser.Parse(produto)).ToImmutableList();
        }
    }
}