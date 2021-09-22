using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Parsers;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Domain.Shared.Repositories;

namespace UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.AppServices
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IProdutoParseFactory _parseFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoAppService(
            IProdutoRepositorio repositorio,
            IProdutoParseFactory parseFactory,
            IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _parseFactory = parseFactory;
            _unitOfWork = unitOfWork;
        }
        
        public IProdutoView Adicionar(IAdicionarProduto adicionarProduto)
        {
            var produto = new Produto(adicionarProduto.Nome, adicionarProduto.Preco);
            
            _repositorio.Adicionar(produto);
            
            _unitOfWork.SaveChanges();
            
            return _parseFactory.GetProdutoParse().Parse(produto);
        }

        public ICollection<IProdutoView> BuscarPeloNome(string nome)
        {
            var produtos = _repositorio.BuscarPeloNome(nome);

            /*
            var result = new List<IProdutoView>();
            for (int i = 0; i < produtos.Count; i++)
            {
                var produto = produtos.ElementAt(i);
                var dto = _parser.Parse(produto);
                result.Add(dto);
            }

            return result;
            */
            
            return produtos.Select(_parseFactory.GetProdutoReportParse().Parse).ToImmutableList();
        }
    }
}