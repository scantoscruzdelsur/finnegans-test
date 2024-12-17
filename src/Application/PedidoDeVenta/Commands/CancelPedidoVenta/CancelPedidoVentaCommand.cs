namespace Finnegans.Application.PedidoDeVenta.Commands.CancelPedidoVenta;

public record CancelPedidoVentaCommand(int Empresa, string FCNic, string FCRemito, int FCReceptor, int FCCodigo, string FCTipo, string FCFormpag, string AccessToken) : IRequest<Unit>;

