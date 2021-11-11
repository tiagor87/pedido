using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Entities;

namespace UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Repositories
{
    public interface IEstoqueRepository
    {
        void Adicionar(EstoqueItem estoqueItem);
        Estoque Carregar();
    }
}