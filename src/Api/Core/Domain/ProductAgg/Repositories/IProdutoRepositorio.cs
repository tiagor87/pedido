﻿using System.Collections.Generic;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;

namespace UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Repositories
{
    public interface IProdutoRepositorio
    {
        void Adicionar(Produto produto);
        ICollection<Produto> Buscar(string nome);
        Produto ObterPeloId(string id);
    }
}