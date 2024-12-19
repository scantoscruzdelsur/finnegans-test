using Finnegans.Application.PedidoDeVenta.Commands.CancelPedidoVenta;
using Finnegans.Application.PedidoDeVenta.Commands.CreatePedidoVenta;
using Finnegans.Application.PedidoDeVenta.Commands.DeletePedidoVenta;
using Finnegans.Application.PedidoDeVenta.Commands.UpdatePedidoVenta;
using Finnegans.Application.PedidoDeVenta.Queries.GetPedidosPorFecha;
using Finnegans.Application.PedidoDeVenta.Queries.GetPedidoVenta;
using Finnegans.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finnegans.Web.Endpoints;

public class PedidoVentaEndpoint : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGet("api/PedidoVenta/Fecha/{updatedSince}", GetPedidosPorFecha)
            .WithName("GetPedidosPorFecha");

        app.MapGet("api/PedidoVenta/{id}", GetPedidoVenta)
            .WithName("GetPedidoVenta");

        app.MapPost("api/PedidoVenta", CreatePedidoVenta)
            .WithName("CreatePedidoVenta");

        app.MapPut("api/PedidoVenta/{id}", UpdatePedidoVenta)
            .WithName("UpdatePedidoVenta");

        app.MapDelete("api/PedidoVenta/{id}", DeletePedidoVenta)
            .WithName("DeletePedidoVenta");

        app.MapPut("api/PedidoVenta/Cancel/{id}", CancelPedidoVenta)
            .WithName("CancelPedidoVenta");

    }

    public Task<List<PedidoVenta>> GetPedidosPorFecha(ISender sender, string updatedSince, [FromHeader] string accessToken)
    {
        var query = new GetPedidosPorFechaQuery(updatedSince, accessToken);
        return sender.Send(query);
    }

    public Task<PedidoVenta> GetPedidoVenta(ISender sender, string id, [FromHeader] string accessToken)
    {
        var query = new GetPedidoVentaQuery(id, accessToken);
        return sender.Send(query);
    }

    public async Task<IResult> CreatePedidoVenta(ISender sender, [FromHeader] string accessToken, [FromBody] CreatePedidoVentaCommand command)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            return Results.BadRequest("El token de acceso es requerido.");
        }

        if (command == null)
        {
            return Results.BadRequest("El cuerpo de la solicitud es inválido.");
        }

        if (command == null || command.PedidoVenta == null)
        {
            return Results.BadRequest("El pedido de venta no puede ser nulo.");
        }

        command = command with { AccessToken = accessToken };

        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdatePedidoVenta(ISender sender, string id, [FromHeader] string accessToken, UpdatePedidoVentaCommand command)
    {
        if (id != command.IdentificaccionExterna && string.IsNullOrEmpty(accessToken))
        {
            Results.BadRequest();
        }

        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> CancelPedidoVenta(ISender sender, string id, [FromHeader] string accessToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            return Results.BadRequest("El token de acceso es requerido.");
        }

        if (string.IsNullOrWhiteSpace(id))
        {
            return Results.BadRequest("El ID es requerido.");
        }

        var command = new CancelPedidoVentaCommand(id, accessToken);
        await sender.Send(command);
        return Results.NoContent();
    }


    public async Task<IResult> DeletePedidoVenta(ISender sender, string id, [FromHeader] string accessToken)
    {
        await sender.Send(new DeletePedidoVentaCommand(id, accessToken));
        return Results.NoContent();
    }
}
