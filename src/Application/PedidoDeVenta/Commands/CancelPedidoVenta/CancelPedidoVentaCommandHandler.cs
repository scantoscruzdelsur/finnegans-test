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

        var url = $"https://api.teamplace.finneg.com/api/CDSpedidoVenta/{request.IdentificacionExterna}?ACCESS_TOKEN={request.AccessToken}";

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

        if (string.IsNullOrEmpty(pedidoVenta.TransaccionSubtipoCodigo))
        {
            throw new Exception("Error, SubtipoCodigo no puede estar vacio o ser null");
        }

        pedidoVenta.vinculacionOrigen = pedidoVenta.IdentificacionExterna;
        pedidoVenta.IdentificacionExterna += "_REVERSO";
        pedidoVenta.Fecha = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
        pedidoVenta.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
        pedidoVenta.WorkflowCodigo = "REVERSO";

        switch (pedidoVenta.TransaccionSubtipoCodigo)
        {
            case "CARTAPORTE":
                pedidoVenta.TransaccionSubtipoCodigo = "REVCARTAPORTE";
                break;
            case "CONTADO":
                pedidoVenta.TransaccionSubtipoCodigo = "REVCONTADO";
                break;
            case "GUIADISTRIBUCION":
                pedidoVenta.TransaccionSubtipoCodigo = "REVGUIASDISTRIBUCION";
                break;
            case "CORREO":
                pedidoVenta.TransaccionSubtipoCodigo = "REVCORREO";
                break;
            case "CONTRARREEMBOLSO":
                pedidoVenta.TransaccionSubtipoCodigo = "REVCONTRARREEMBOLSO";
                break;
            case "ODS":
                pedidoVenta.TransaccionSubtipoCodigo = "REVODS";
                break;
            case "GUIAINTERNA":
                pedidoVenta.TransaccionSubtipoCodigo = "REVGUIAINTERNA";
                break;
        }


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

        // Pegarle al SP que está modificando flor

        // En el caso de que esté todo Ok, auditar la acción con la tabla de auditoría (AuditoriaAnulacionYModificacion)


        return Unit.Value;
    }
}
