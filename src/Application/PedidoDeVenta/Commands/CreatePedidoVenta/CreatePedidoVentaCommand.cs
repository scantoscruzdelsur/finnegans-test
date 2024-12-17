using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Commands.CreatePedidoVenta;

public record CreatePedidoVentaCommand(string AccessToken, PedidoVenta PedidoVenta) : IRequest<PedidoVenta>;
