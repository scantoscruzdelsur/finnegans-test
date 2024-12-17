using System.Net.Http.Json;
using System.Text.Json;
using Finnegans.Domain.Entities;

namespace Finnegans.Application.PedidoDeVenta.Commands.CancelPedidoVenta;

public class CancelPedidoVentaCommandHandler : IRequestHandler<CancelPedidoVentaCommand, Unit>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CancelPedidoVentaCommandHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Unit> Handle(CancelPedidoVentaCommand request, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var idexterna = $"{request.FCNic}_{request.FCReceptor:0000}_{request.FCRemito.Substring(0, 13)}";

        var url = $"https://api.teamplace.finneg.com/api/CDSpedidoVenta/{idexterna}?ACCESS_TOKEN={request.AccessToken}";

        var response = await httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error al obtener el pedido de venta. StatusCode: {response.StatusCode}");
        }

        var pedidoVenta = await response.Content.ReadFromJsonAsync<PedidoVenta>(cancellationToken: cancellationToken);
        if (pedidoVenta == null)
        {
            throw new Exception("Error al deserializar el pedido de venta.");
        }

        pedidoVenta.vinculacionOrigen = pedidoVenta.IdentificacionExterna;
        pedidoVenta.IdentificacionExterna += "_REVERSO";
        pedidoVenta.Fecha = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
        pedidoVenta.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
        pedidoVenta.WorkflowCodigo = "REVERSO";

        int cTDOCCTE = request.FCCodigo switch
        {
            7 => 3,
            9 => 2,
            _ when request.FCTipo == "O" => 5,
            _ when request.FCFormpag == "0" => 0,
            _ when request.FCFormpag == "1" => 1,
            _ => 0
        };

        pedidoVenta.TransaccionSubtipoCodigo = cTDOCCTE switch
        {
            0 => "REVCARTAPORTE",
            1 => "REVCONTADO",
            2 => "REVGUIASDISTRIBUCION",
            3 => "REVCORREO",
            4 => "REVCONTRARREEMBOLSO",
            5 => "REVODS",
            _ => pedidoVenta.TransaccionSubtipoCodigo
        };

        foreach (var item in pedidoVenta.Items)
        {
            item.vinculacionOrigen = pedidoVenta.vinculacionOrigen;
        }

        var jsonAEnviar = JsonSerializer.Serialize(pedidoVenta);
        var postResponse = await httpClient.PostAsJsonAsync("https://api.teamplace.finneg.com/api/CDSpedidoVenta", pedidoVenta, cancellationToken);

        if (!postResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Error al enviar el pedido de venta reverso. StatusCode: {postResponse.StatusCode}");
        }

        return Unit.Value;
    }
}
