﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnifesoPoo.Pedido.Api.Controllers.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.AppServices;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;

namespace UnifesoPoo.Pedido.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoAppService _appService;

        public ProdutosController(ProdutoAppService appService)
        {
            _appService = appService;
        }
        
        [HttpPost]
        public IActionResult Add(AdicionarProdutoDto adicionarProdutoDto)
        {
            var produto = _appService.Adicionar(adicionarProdutoDto);
            return Created(Request.Path, produto);
        }

        [HttpGet]
        public IActionResult Query(string nome)
        {
            var produtos = _appService.BuscarPeloNome(nome);
            return Ok(produtos);
        }
        
        
    }
}
