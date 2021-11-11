using System.Net;
using Microsoft.AspNetCore.Mvc;
using UnifesoPoo.Pedido.Api.Controllers.Contracts;

namespace UnifesoPoo.Pedido.Api.Controllers.Extensions
{
    public static class ResponseExtensionMethod
    {
        public static IActionResult AsResponse(this object data, HttpStatusCode statusCode)
        {
            return new ObjectResult(new ResponseDto(data))
            {
                StatusCode = (int) statusCode
            };
        }
    }
}