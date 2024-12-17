using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Queries.GetPedidoVenta;

public record GetPedidoVentaQuery(string IdentificacionExterna, string AccessToken) : IRequest<PedidoVenta>;
