namespace Finnegans.Application.PedidoDeVenta.Queries.GetPedidoVenta;
public class GetPedidoVentaQueryValidator : AbstractValidator<GetPedidoVentaQuery>
{
    public GetPedidoVentaQueryValidator()
    {
        RuleFor(x => x.IdentificacionExterna)
            .NotEmpty()
            .WithMessage("La identificación externa es requerida.");

        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithMessage("El token de acceso es requerido.");
    }
}
