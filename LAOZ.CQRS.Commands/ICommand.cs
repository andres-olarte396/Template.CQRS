namespace LAOZ.CQRS.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
