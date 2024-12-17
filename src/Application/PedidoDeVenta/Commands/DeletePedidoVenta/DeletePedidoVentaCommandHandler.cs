using Finnegans.Application.Common.Interfaces;

namespace Finnegans.Application.PedidoDeVenta.Commands.DeletePedidoVenta;


public class DeletePedidoVentaCommandHandler : IRequestHandler<DeletePedidoVentaCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeletePedidoVentaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePedidoVentaCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Unit.Value);
    }
}
