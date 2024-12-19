using System.Net.Http.Json;
using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Commands.CreatePedidoVenta;

public class CreatePedidoVentaCommandHandler : IRequestHandler<CreatePedidoVentaCommand, PedidoVenta>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CreatePedidoVentaCommandHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<PedidoVenta> Handle(CreatePedidoVentaCommand request, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url = $"https://api.teamplace.finneg.com/api/CDSpedidoVenta?ACCESS_TOKEN={request.AccessToken}";

        var response = await httpClient.PostAsJsonAsync(url, request.PedidoVenta, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error al crear el pedido de venta. StatusCode: {response.StatusCode}");
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Created)
        {
            var createdPedidoVenta = await response.Content.ReadFromJsonAsync<PedidoVenta>(cancellationToken: cancellationToken);
            return createdPedidoVenta ?? throw new Exception("Error al deserializar el pedido de venta creado.");
        }

        throw new Exception("Error inesperado al crear el pedido de venta.");
    }
}
