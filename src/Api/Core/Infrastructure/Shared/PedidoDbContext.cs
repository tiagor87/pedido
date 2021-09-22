using Microsoft.EntityFrameworkCore;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.Shared.Repositories;

namespace UnifesoPoo.Pedido.Api.Core.Infrastructure.Shared
{
    public class PedidoDbContext : DbContext, IUnitOfWork
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }
        
        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}