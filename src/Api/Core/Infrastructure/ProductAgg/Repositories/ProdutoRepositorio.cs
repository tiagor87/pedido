using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Infrastructure.Shared;

namespace UnifesoPoo.Pedido.Api.Core.Infrastructure.ProductAgg.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly PedidoDbContext _context;

        public ProdutoRepositorio(PedidoDbContext context)
        {
            _context = context;
        }
        
        public void Adicionar(Produto produto)
        {
            _context.Set<Produto>().Add(produto);
        }

        public ICollection<Produto> BuscarPeloNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return _context.Set<Produto>().ToImmutableList();
            }
            return _context.Set<Produto>()
                .Where(produto => produto.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToImmutableList();
        }
    }
}