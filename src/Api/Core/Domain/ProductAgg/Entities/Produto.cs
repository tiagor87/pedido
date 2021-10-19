using System;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;

namespace UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities
{
    public class Produto
    {
        private Produto()
        {
        }
        public Produto(string nome, long preco) : this()
        {
            ExternalId = Guid.NewGuid().ToString();
            Nome = nome;
            Preco = preco;
            QuantidadeDisponivel = 0;
        }

        public long Id { get; private set; }
        public string ExternalId { get; private set; }
        public string Nome { get; private set; }
        public int QuantidadeDisponivel { get; private set; }
        public long Preco { get; private set; }

        public void Atualizar(IAtualizarProduto atualizarProduto)
        {
            Nome = atualizarProduto.Nome;
            Preco = atualizarProduto.Preco;
            QuantidadeDisponivel = atualizarProduto.QuantidadeDisponivel;
        }
    }
}