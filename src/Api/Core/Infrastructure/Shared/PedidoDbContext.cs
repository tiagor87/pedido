using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.Shared;
using UnifesoPoo.Pedido.Api.Core.Domain.Shared.Repositories;

namespace UnifesoPoo.Pedido.Api.Core.Infrastructure.Shared
{
    public class PedidoDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public PedidoDbContext(DbContextOptions<PedidoDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<EstoqueItem> EstoqueItens { get; set; }
        
        void IUnitOfWork.SaveChanges()
        {
            var entities = ChangeTracker.Entries<IAggregateRoot>().Select(x => x.Entity).ToList();
            var domainEvents = entities.SelectMany(x => x.GetDomainEvents()).ToList();

            foreach (var entity in entities)
            {
                entity.ClearDomainEvents();
            }

            foreach (var domainEvent in domainEvents)
            {
                _mediator.Publish(domainEvent).GetAwaiter().GetResult();
            }

            base.SaveChanges();
        }
    }
}