using System.Net.Http.Json;
using System.Text.Json;
using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Queries.GetPedidosPorFecha;

public class GetPedidosPorFechaQueryHandler : IRequestHandler<GetPedidosPorFechaQuery, List<PedidoVenta>>
{
    private readonly IHttpClientFactory _httpClientFactory;


    public GetPedidosPorFechaQueryHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<PedidoVenta>> Handle(GetPedidosPorFechaQuery request, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url = $"https://api.teamplace.finneg.com/api/CDSpedidoVenta/list?updatedSince={request.UpdatedSince}&ACCESS_TOKEN={request.AccessToken}";

        var response = await httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error al obtener los pedidos de venta. StatusCode: {response.StatusCode}");
        }

        try
        {
            var pedidos = await response.Content.ReadFromJsonAsync<List<PedidoVenta>>(cancellationToken: cancellationToken);
            if (pedidos == null)
            {
                throw new Exception("No se pudo deserializar la respuesta del servidor.");
            }
            return pedidos;

        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar el JSON: {ex.Message}");
            throw;
        }
    }
}
