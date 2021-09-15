using Microsoft.AspNetCore.Server.IIS.Core;

namespace UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities
{
    public class Produto
    {
        private static long _id = 0;
        public Produto(string nome, long preco)
        {
            Id = ++_id;
            Nome = nome;
            Preco = preco;
            QuantidadeDisponivel = 0;
        }

        public long Id { get; }
        public string Nome { get; }
        public int QuantidadeDisponivel { get; }
        public long Preco { get; }
    }
}