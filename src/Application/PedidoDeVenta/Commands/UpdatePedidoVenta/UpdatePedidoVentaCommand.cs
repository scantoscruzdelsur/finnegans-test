namespace Finnegans.Application.PedidoDeVenta.Commands.UpdatePedidoVenta;


public record UpdatePedidoVentaCommand(string IdentificaccionExterna, string AccessToken) : IRequest<Unit>
{
}
