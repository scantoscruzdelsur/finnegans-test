namespace Finnegans.Application.PedidoDeVenta.Commands.DeletePedidoVenta;
public record DeletePedidoVentaCommand(string IdentificacionExterna, string AccessToken) : IRequest<Unit>
{
}
