﻿using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UnifesoPoo.Pedido.Api.Controllers.Contracts;
using UnifesoPoo.Pedido.Api.Core.Domain.Shared.Exceptions;

namespace UnifesoPoo.Pedido.Api.Controllers.Middlewares
{
    public class LoggerHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerHandlingMiddleware> _logger;

        public LoggerHandlingMiddleware(RequestDelegate next, ILogger<LoggerHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation("[{Type}] {Path}", "Request", context.Request.Path);
                await _next.Invoke(context);
                _logger.LogInformation("[{Type}] {Path}", "Response", context.Request.Path);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "[{Type}] {Path}", "Response", context.Request.Path);
                throw;
            }
        }
    }
}