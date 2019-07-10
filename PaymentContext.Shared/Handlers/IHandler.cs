using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T : Command
    {
        ICommandResult Handle(T command);
    }
}