﻿using System.Collections.Immutable;
using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Infrastructure.Shared;

namespace UnifesoPoo.Pedido.Api.Core.Infrastructure.EstoqueAgg.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly PedidoDbContext _context;

        public EstoqueRepository(PedidoDbContext context)
        {
            _context = context;
        }
        public Estoque Carregar()
        {
            var itens = _context.EstoqueItens.ToImmutableList();
            return new Estoque(itens);
        }

        public void Adicionar(EstoqueItem estoqueItem)
        {
            _context.EstoqueItens.Add(estoqueItem);
        }
    }
}