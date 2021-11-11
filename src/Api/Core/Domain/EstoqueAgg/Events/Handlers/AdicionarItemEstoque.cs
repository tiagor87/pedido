using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Events;

namespace UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Events.Handlers
{
    public class AdicionarItemEstoque : INotificationHandler<ProdutoCriado>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public AdicionarItemEstoque(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        
        public Task Handle(ProdutoCriado notification, CancellationToken cancellationToken)
        {
            _estoqueRepository.Adicionar(new EstoqueItem(notification.Produto));
            return Task.CompletedTask;
        }
    }
}