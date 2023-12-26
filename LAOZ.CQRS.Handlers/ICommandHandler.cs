using LAOZ.CQRS.Commands;

namespace LAOZ.CQRS.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Handle(TCommand command);
    }
}
