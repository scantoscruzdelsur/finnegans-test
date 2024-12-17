using System.Net.Http.Json;
using System.Text.Json;
using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Queries.GetPedidoVenta;

public class GetPedidoVentaQueryHandler : IRequestHandler<GetPedidoVentaQuery, PedidoVenta>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GetPedidoVentaQueryHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<PedidoVenta> Handle(GetPedidoVentaQuery request, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url = $"https://api.teamplace.finneg.com/api/CDSpedidoVenta/{request.IdentificacionExterna}?ACCESS_TOKEN={request.AccessToken}";

        var response = await httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error al obtener el pedido de venta. StatusCode: {response.StatusCode}");
        }

        try
        {
            var pedidoVenta = await response.Content.ReadFromJsonAsync<PedidoVenta>(cancellationToken: cancellationToken);
            if (pedidoVenta == null)
            {
                throw new Exception("No se pudo deserializar la respuesta del servidor.");
            }

            return pedidoVenta;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar el JSON: {ex.Message}");
            throw;
        }
    }                                                                                                                                                         
}
