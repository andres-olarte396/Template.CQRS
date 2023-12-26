using LAOZ.CQRS.Commands;

namespace LAOZ.CQRS.Handlers
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Handler<T>() where T : Command;
    }
}
