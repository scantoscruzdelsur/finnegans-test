namespace Finnegans.Application.PedidoDeVenta.Commands.CancelPedidoVenta;
public class CancelPedidoVentaCommandValidator : AbstractValidator<CancelPedidoVentaCommand>
{
    public CancelPedidoVentaCommandValidator()
    {
        RuleFor(v => v.IdentificacionExterna)
            .NotEmpty().WithMessage("IdentificacionExterna is required.")
            .MaximumLength(200).WithMessage("IdentificacionExterna must not exceed 200 characters.");
        RuleFor(v => v.AccessToken)
            .NotEmpty().WithMessage("AccessToken is required.")
            .MaximumLength(200).WithMessage("AccessToken must not exceed 200 characters.");
    }
}
