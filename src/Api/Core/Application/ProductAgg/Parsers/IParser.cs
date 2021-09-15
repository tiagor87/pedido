namespace UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Parsers
{
    public interface IParser<TFrom, TTo>
    {
        TTo Parse(TFrom from);
    }
}