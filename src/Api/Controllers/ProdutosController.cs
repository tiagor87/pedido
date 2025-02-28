﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using UnifesoPoo.Pedido.Api.Controllers.Contracts;
using UnifesoPoo.Pedido.Api.Controllers.Extensions;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.AppServices;

namespace UnifesoPoo.Pedido.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
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
            return produto.AsResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public IActionResult Query(string nome)
        {
            var produtos = _appService.Buscar(nome);
            return produtos.AsResponse(HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var produto = _appService.ObterPeloId(id);
            return produto.AsResponse(HttpStatusCode.OK);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(string id, AtualizarProdutoDto atualizarProduto)
        {
            var produto = _appService.Atualizar(id, atualizarProduto);
            return produto.AsResponse(HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(string id)
        {
            _appService.Deletar(id);
            return NoContent();
        }

    }
}
