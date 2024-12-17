using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Queries.GetPedidosPorFecha;

public record GetPedidosPorFechaQuery(string UpdatedSince, string AccessToken) : IRequest<List<PedidoVenta>>;


