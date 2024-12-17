namespace Finnegans.Application.PedidoDeVenta.Commands.CancelPedidoVenta;

public record CancelPedidoVentaCommand(string IdentificacionExterna, string AccessToken) : IRequest<Unit>;


