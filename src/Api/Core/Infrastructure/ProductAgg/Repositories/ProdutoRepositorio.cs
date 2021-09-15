using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Repositories;

namespace UnifesoPoo.Pedido.Api.Core.Infrastructure.ProductAgg.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> _produtos = new List<Produto>();
        public void Adicionar(Produto produto)
        {
            _produtos.Add(produto);
        }

        public ICollection<Produto> BuscarPeloNome(string nome)
        {
            return _produtos.Where(produto => produto.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToImmutableList();
        }
    }
}