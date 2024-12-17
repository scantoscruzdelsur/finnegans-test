using Finnegans.Application.Common.Interfaces;

namespace Finnegans.Application.PedidoDeVenta.Commands.UpdatePedidoVenta;

public class UpdatePedidoVentaCommandHandler : IRequestHandler<UpdatePedidoVentaCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdatePedidoVentaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdatePedidoVentaCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Unit.Value);
    }
}
